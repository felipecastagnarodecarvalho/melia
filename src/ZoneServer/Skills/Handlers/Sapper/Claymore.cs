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
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.Monsters;
using static Melia.Zone.Skills.SkillUseFunctions;
using Melia.Shared.Data.Database;

namespace Melia.Zone.Skills.Handlers.Sapper
{
	/// <summary>
	/// Handler for the Sapper skill Claymore.
	/// </summary>
	[SkillHandler(SkillId.Sapper_Claymore)]
	public class Claymore : IGroundSkillHandler
	{
		private Mob trap;

		/// <summary>
		/// Handles the skill, creates an trap object on the floor on
		/// the first usage and explodes it on the second usage attempt
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

			if (trap != null)
			{
				this.ExplodeTrap(caster, skill);
				return;
			}

			this.PlaceTrap(caster, skill, farPos);
		}

		/// <summary>
		/// Handles the trap triggering explosion effect
		/// </summary>
		/// <param name="caster"></param>
		/// <param name="skill"></param>
		private async void ExplodeTrap(ICombatEntity caster, Skill skill)
		{
			var character = caster as Character;

			skill.IncreaseOverheat();
			caster.SetAttackState(true);

			await Task.Delay(200);

			Send.ZC_NORMAL.Skill_88(character, character, null);
			Send.ZC_NORMAL.Skill_88(character, caster, null);

			Send.ZC_SKILL_READY(caster, null, caster.Position, caster.Position);
			Send.ZC_NORMAL.UpdateSkillEffect(caster, 0, caster.Position, trap.Direction, trap.Position);
			Send.ZC_SKILL_MELEE_GROUND(caster, skill, trap.Position, ForceId.GetNew(), null);

			await Task.Delay(350);

			Send.ZC_DEAD(trap, trap.Position);

			caster.Map.RemoveMonster(trap);

			Send.ZC_NORMAL.Skill_122(character, "SAPPER_TRAP_Sapper_Claymore");

			var splashParam = skill.GetSplashParameters(trap, trap.Position, trap.Position, length: 200, width: 0, angle: 60);
			var splashArea = skill.GetSplashArea(SplashType.Fan, splashParam);

			this.Attack(skill, caster, splashArea);

			trap = null;
		}

		/// <summary>
		/// Places the trap object (mob) on the floor
		/// </summary>
		/// <param name="caster"></param>
		/// <param name="skill"></param>
		/// <param name="farPos"></param>
		private async void PlaceTrap(ICombatEntity caster, Skill skill, Position farPos)
		{
			var character = caster as Character;

			await Task.Delay(TimeSpan.FromMilliseconds(200));

			Send.ZC_NORMAL.Skill_88(character, caster, skill);
			Send.ZC_NORMAL.Skill_122(character, "SAPPER_TRAP_Sapper_Claymore");

			farPos = farPos.GetRelative(caster.Direction, 12);

			var trapObject = new Mob(57197, MonsterType.NPC);

			trapObject.Position = farPos;
			trapObject.Direction = caster.Direction;

			trapObject.Components.Add(new BuffComponent(trapObject));

			caster.Map.AddMonster(trapObject);
			Send.ZC_ENTER_MONSTER(trapObject);
			Send.ZC_OWNER(character, trapObject);
			Send.ZC_FACTION(character.Connection, trapObject, FactionType.Trap);
			Send.ZC_NORMAL.Skill_99(character, trapObject);
			Send.ZC_NORMAL.Skill_C8(character, trapObject);

			trap = trapObject;

			Send.ZC_SKILL_READY(caster, skill, caster.Position, caster.Position);
			Send.ZC_NORMAL.UpdateSkillEffect(caster, caster.Handle, caster.Position, caster.Position.GetDirection(trapObject.Position), trapObject.Position);
			Send.ZC_SKILL_MELEE_GROUND(caster, skill, trapObject.Position, ForceId.GetNew(), null);

			trap.StartBuff(BuffId.Cover_Buff, TimeSpan.FromMinutes(60));

			await Task.Delay(TimeSpan.FromMilliseconds(800));

			Send.ZC_NORMAL.Skill_17A(character);
			Send.ZC_NORMAL.Skill_40(character, skill.Id, "SKL_CLAYMORE_SHOT");
		}

		/// <summary>
		/// Executes the actual attack after a delay.
		/// </summary>
		/// <param name="skill"></param>
		/// <param name="caster"></param>
		/// <param name="splashArea"></param>
		private void Attack(Skill skill, ICombatEntity caster, ISplashArea splashArea)
		{
			var targets = caster.Map.GetAttackableEntitiesIn(caster, splashArea);

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