﻿using System;
using System.Threading.Tasks;
using Melia.Shared.L10N;
using Melia.Shared.Tos.Const;
using Melia.Shared.World;
using Melia.Zone.Network;
using Melia.Zone.Skills.Handlers.Base;
using Melia.Zone.Skills.SplashAreas;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.CombatEntities.Components;
using Melia.Zone.Skills.Combat;
using System.Collections.Generic;
using System.Threading;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.Buffs;

namespace Melia.Zone.Skills.Handlers.Enchanter
{
	/// <summary>
	/// Handler for the Wugushi skill Golden Frog.
	/// </summary>
	[SkillHandler(SkillId.Wugushi_JincanGu)]
	public class GoldenFrog : IGroundSkillHandler
	{
		/// <summary>
		/// Handles the skill, creates an area of effect that damages the enemies inside
		/// </summary>
		/// <param name="skill"></param>
		/// <param name="caster"></param>
		/// <param name="originPos"></param>
		/// <param name="farPos"></param>
		/// <param name="designatedTarget"></param>
		public void Handle(Skill skill, ICombatEntity caster, Position originPos, Position farPos, ICombatEntity designatedTarget)
		{
			if (!caster.TrySpendSp(skill))
			{
				caster.ServerMessage(Localization.Get("Not enough SP."));
				return;
			}

			if (!caster.Position.InRange2D(farPos, skill.Data.MaxRange))
			{
				caster.ServerMessage(Localization.Get("Too far away."));
				return;
			}

			skill.IncreaseOverheat();
			caster.SetAttackState(true);

			Send.ZC_SKILL_READY(caster, skill, caster.Position, caster.Position);
			Send.ZC_NORMAL.UpdateSkillEffect(caster, caster.Handle, farPos, caster.Position.GetDirection(farPos), Position.Zero);
			Send.ZC_SKILL_MELEE_GROUND(caster, skill, farPos, ForceId.GetNew(), null);

			// Start the task
			Task.Run(() => AreaOfEffect(skill, caster, farPos));
		}

		/// <summary>
		/// Area of effect that ticks dealing damage on the enemies inside
		/// </summary>
		/// <param name="skill"></param>
		/// <param name="caster"></param>
		/// <param name="position"></param>
		async Task AreaOfEffect(Skill skill, ICombatEntity caster, Position position)
		{
			await Task.Delay(200);

			var character = caster as Character;
			var effectId = ForceId.GetNew();

			Send.ZC_NORMAL.GroundEffect_6(character, "I_cleric_jincangu_force_mash#Dummy_effect_shoot", 0.4f, "", 1, position);
			Send.ZC_NORMAL.GroundEffect_59(character, "Archer_JincanGu_Abil", skill.Id, position, effectId, true);

			await Task.Delay(400);

			Send.ZC_NORMAL.Skill_E3(character, null, "STAGE_1");

			// Radius seems precise
			var radius = 100;
			var center = position.GetRelative(position, radius);
			var splashArea = new Circle(center, radius);

			Debug.ShowShape(caster.Map, splashArea, edgePoints: false);

			using (var cancellationTokenSource = new CancellationTokenSource())
			{
				cancellationTokenSource.CancelAfter(TimeSpan.FromSeconds(15));

				while (!cancellationTokenSource.IsCancellationRequested)
				{
					// Attack targets
					var targets = caster.Map.GetAttackableEntitiesIn(caster, splashArea);

					var hits = new List<SkillHitInfo>();

					foreach (var target in targets.LimitRandom(10))
					{
						if (!target.Components.Get<BuffComponent>().Has(BuffId.JincanGu_Abil_Debuff))
						{
							target.StartBuff(BuffId.JincanGu_Abil_Debuff, TimeSpan.FromSeconds(60), caster, skill);
						}
					}

					await Task.Delay(200);
				}

				Send.ZC_NORMAL.GroundEffect_59(character, "Archer_JincanGu_Abil", skill.Id, position, effectId, false);
			}
		}
	}
}
