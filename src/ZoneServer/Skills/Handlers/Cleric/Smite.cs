﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Melia.Shared.L10N;
using Melia.Shared.Tos.Const;
using Melia.Shared.World;
using Melia.Zone.Network;
using Melia.Zone.Skills.Combat;
using Melia.Zone.Skills.Handlers.Base;
using Melia.Zone.Skills.SplashAreas;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.CombatEntities.Components;
using Yggdrasil.Logging;
using static Melia.Zone.Skills.SkillUseFunctions;

namespace Melia.Zone.Skills.Handlers.Cleric
{
	/// <summary>
	/// Handler for the Swordsman skill Thrust.
	/// </summary>
	[SkillHandler(SkillId.Cleric_Smite)]
	public class ClericSmite : IGroundSkillHandler
	{
		/// <summary>
		/// Handles skill, damaging targets.
		/// </summary>
		/// <param name="skill"></param>
		/// <param name="caster"></param>
		/// <param name="originPos"></param>
		/// <param name="farPos"></param>
		public void Handle(Skill skill, ICombatEntity caster, Position originPos, Position farPos, ICombatEntity target)
		{
			if (!caster.TrySpendSp(skill))
			{
				caster.ServerMessage(Localization.Get("Not enough SP."));
				return;
			}

			skill.IncreaseOverheat();
			caster.Components.Get<CombatComponent>().SetAttackState(true);

			caster.Components.Get<BuffCollection>().Start(BuffId.Smite_Buff, TimeSpan.FromSeconds(60));

			Send.ZC_SKILL_MELEE_GROUND(caster, skill, farPos, null);

			var height = skill.Properties.GetFloat(PropertyName.WaveLength);
			var width = height / 2;
			originPos = caster.Position;
			farPos = originPos.GetRelative(caster.Direction, height);
			var splashArea = new Square(originPos, caster.Direction, height, width);

			Send.ZC_SKILL_READY(caster, skill, originPos, farPos);
			Send.ZC_SKILL_MELEE_GROUND(caster, skill, farPos, null);

			this.Attack(skill, caster, splashArea);
		}

		/// <summary>
		/// Executes the actual attack after a delay.
		/// </summary>
		/// <param name="skill"></param>
		/// <param name="caster"></param>
		/// <param name="splashArea"></param>
		private async void Attack(Skill skill, ICombatEntity caster, ISplashArea splashArea)
		{
			var damageDelay = TimeSpan.FromMilliseconds(270);
			var skillHitDelay = TimeSpan.Zero;

			await Task.Delay(damageDelay);

			Debug.ShowShape(caster.Map, splashArea, edgePoints: false);

			var targets = caster.Map.GetAttackableEntitiesIn(caster, splashArea);
			var hits = new List<SkillHitInfo>();

			foreach (var target in targets)
			{
				var damage = SCR_CalculateDamage(caster, target, skill);
				target.TakeDamage(damage, caster);

				var hit = new SkillHitInfo(caster, target, skill, damage, damageDelay, skillHitDelay);
				hits.Add(hit);
			}

			Send.ZC_SKILL_HIT_INFO(caster, hits);
		}
	}
}