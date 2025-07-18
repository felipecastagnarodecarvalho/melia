using System;
using Melia.Shared.Data.Database;
using Melia.Shared.Game.Const;
using Melia.Shared.L10N;
using Melia.Shared.World;
using Melia.Zone.Network;
using Melia.Zone.Skills.Combat;
using Melia.Zone.Skills.Handlers.Base;
using Melia.Zone.Skills.SplashAreas;
using Melia.Zone.World.Actors;
using Yggdrasil.Util;
using static Melia.Zone.Skills.SkillUseFunctions;

namespace Melia.Zone.Skills.Handlers.Archers.Cryomancer
{
	/// <summary>
	/// Handler for the Archer skill Ice Pike.
	/// </summary>
	[SkillHandler(SkillId.Cryomancer_IciclePike)]
	public class Cryomancer_IciclePike : IGroundSkillHandler, IDynamicCasted
	{
		private const int FreezeChange = 50;

		/// <summary>
		/// Called when the user starts casting the skill.
		/// </summary>
		/// <param name="skill"></param>
		/// <param name="caster"></param>
		public void StartDynamicCast(Skill skill, ICombatEntity caster)	{ }

		/// <summary>
		/// Called when the user stops casting the skill.
		/// </summary>
		/// <param name="skill"></param>
		/// <param name="caster"></param>
		public void EndDynamicCast(Skill skill, ICombatEntity caster) { }

		/// <summary>
		/// Handles skill, damaging targets.
		/// </summary>
		/// <param name="skill"></param>
		/// <param name="caster"></param>
		/// <param name="originPos"></param>
		/// <param name="farPos"></param>
		/// <param name="target"></param>
		public void Handle(Skill skill, ICombatEntity caster, Position originPos, Position farPos, ICombatEntity target)
		{
			if (!caster.TrySpendSp(skill))
			{
				caster.ServerMessage(Localization.Get("Not enough SP."));
				return;
			}

			if (!caster.InSkillUseRange(skill, farPos))
			{
				caster.ServerMessage(Localization.Get("Too far away."));
				return;
			}

			originPos = caster.Position;
			skill.IncreaseOverheat();
			caster.TurnTowards(farPos);
			caster.SetAttackState(true);

			var splashArea = new Circle(farPos, 100);

			Send.ZC_SKILL_READY(caster, skill, farPos, Position.Zero);
			Send.ZC_SKILL_MELEE_GROUND(caster, skill, farPos, null);
			Send.ZC_NORMAL.UpdateSkillEffect(caster, 0, farPos, caster.Position.GetDirection(farPos), Position.Zero);

			this.Attack(skill, caster, splashArea);
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

			var hitTargets = targets.LimitRandom(7);

			foreach (var target in hitTargets)
			{
				var skillHitResult = SCR_SkillHit(caster, target, skill);
				target.TakeDamage(skillHitResult.Damage, caster);

				var hit = new HitInfo(caster, target, skill, skillHitResult);
				hit.ForceId = ForceId.GetNew();
				hit.ResultType = HitResultType.Unk16;

				if (RandomProvider.Get().Next(100) < FreezeChange)
					target.StartBuff(BuffId.Cryomancer_Freeze, skill.Level, 0, TimeSpan.FromSeconds(5), caster);

				Send.ZC_HIT_INFO(caster, target, hit);
			}
		}
	}
}
