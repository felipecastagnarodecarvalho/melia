﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Melia.Shared.Data.Database;
using Melia.Shared.L10N;
using Melia.Shared.Tos.Const;
using Melia.Shared.World;
using Melia.Zone.Network;
using Melia.Zone.Skills.Combat;
using Melia.Zone.Skills.Handlers.Base;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.Characters.Components;
using static Melia.Zone.Skills.SkillUseFunctions;
using static Mysqlx.Crud.Order.Types;

namespace Melia.Zone.Skills.Handlers.Ardito
{
	/// <summary>
	/// Handler for the Ardito skill Granata.
	/// </summary>
	[SkillHandler(SkillId.Arditi_Granata)]
	public class Granata : IGroundSkillHandler
	{
		/// <summary>
		/// Handles skill, damaging targets.
		/// </summary>
		/// <param name="skill"></param>
		/// <param name="caster"></param>
		/// <param name="originPos"></param>
		/// <param name="farPos"></param>
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

			// Ability "Granata: Aim"
			if (!caster.Components.Get<AbilityComponent>().IsActive(AbilityId.Arditi20))
			{
				// TODO: Implement this
			}

			skill.IncreaseOverheat();
			caster.SetAttackState(true);

			var character = caster as Character;
			character.Rotate(originPos.GetDirection(farPos));

			Send.ZC_SKILL_READY(caster, skill, originPos, farPos);
			Send.ZC_NORMAL.UpdateSkillEffect(caster, 0, originPos, originPos.GetDirection(farPos), Position.Zero);
			Send.ZC_SKILL_MELEE_GROUND(caster, skill, farPos, ForceId.GetNew(), null);

			this.Attack(skill, caster, originPos, farPos);
		}

		private async void Attack(Skill skill, ICombatEntity caster, Position originPos, Position farPos)
		{
			await Task.Delay(200);

			Send.ZC_NORMAL.Skill_6(caster as Character, "I_archer_Lachrymator_force_mash_short#Dummy_R_HAND", 0.6f, "F_scout_Granata_explosion", 3f, farPos);

			var splashParam = skill.GetSplashParameters(caster, originPos, farPos, length: 50, width: 50, angle: 0);
			var splashArea = skill.GetSplashArea(SplashType.Circle, splashParam);

			var targets = caster.Map.GetAttackableEntitiesIn(caster, splashArea);

			Debug.ShowShape(caster.Map, splashArea, edgePoints: false);

			foreach (var target in targets.LimitBySDR(caster, skill))
			{
				var skillHitResult = SCR_SkillHit(caster, target, skill);
				target.TakeDamage(skillHitResult.Damage, caster);

				var hit = new HitInfo(caster, target, skill, skillHitResult);

				Send.ZC_HIT_INFO(caster, target, skill, hit);
			}
		}
	}
}
