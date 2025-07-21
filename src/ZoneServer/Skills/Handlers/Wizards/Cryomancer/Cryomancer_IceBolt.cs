using System;
using System.Threading.Tasks;
using Melia.Shared.Data.Database;
using Melia.Shared.Game.Const;
using Melia.Shared.L10N;
using Melia.Shared.World;
using Melia.Zone.Network;
using Melia.Zone.Skills.Combat;
using Melia.Zone.Skills.Handlers.Base;
using Melia.Zone.Skills.SplashAreas;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Characters;
using Yggdrasil.Util;
using static Melia.Shared.Util.TaskHelper;
using static Melia.Zone.Skills.SkillUseFunctions;

namespace Melia.Zone.Skills.Handlers.Wizards.Cryomancer
{
	/// <summary>
	/// Handler for the Archer skill Ice Bolt.
	/// </summary>
	[SkillHandler(SkillId.Cryomancer_IceBolt)]
	public class Cryomancer_IceBolt : ITargetSkillHandler, IDynamicCasted
	{
		private const int FreezeChange = 30;

		/// <summary>
		/// Called when the user starts casting the skill.
		/// </summary>
		/// <param name="skill"></param>
		/// <param name="caster"></param>
		public void StartDynamicCast(Skill skill, ICombatEntity caster)
		{
			Send.ZC_PLAY_SOUND_Gendered(caster, "voice_wiz_m_icebolt_cast", "voice_wiz_icebolt_cast");
			skill.Vars.SetBool("HasFinishedSkillCast", false);

			if (caster is Character casterCharacter)
				Send.ZC_NORMAL.UnkDynamicCastStart(casterCharacter, skill.Id);
		}

		/// <summary>
		/// Called when the user stops casting the skill.
		/// </summary>
		/// <param name="skill"></param>
		/// <param name="caster"></param>
		public void EndDynamicCast(Skill skill, ICombatEntity caster)
		{
			Send.ZC_STOP_SOUND_Gendered(caster, "voice_wiz_m_icebolt_cast", "voice_wiz_icebolt_cast");
			skill.Vars.SetBool("HasFinishedSkillCast", true);

			if (caster is Character casterCharacter)
				Send.ZC_NORMAL.UnkDynamicCastEnd(casterCharacter, skill.Id, 0.5f);
		}

		/// <summary>
		/// Handles skill, damaging targets.
		/// </summary>
		/// <param name="skill"></param>
		/// <param name="caster"></param>
		/// <param name="target"></param>
		public void Handle(Skill skill, ICombatEntity caster, ICombatEntity target)
		{
			// An attempt to prevent the client of directing casting the skill
			if (!skill.Vars.GetBool("HasFinishedSkillCast"))
				return;

			if (!caster.TrySpendSp(skill))
			{
				caster.ServerMessage(Localization.Get("Not enough SP."));
				return;
			}

			var originPos = caster.Position;
			var farPos = target.Position;

			if (!caster.InSkillUseRange(skill, farPos))
			{
				caster.ServerMessage(Localization.Get("Too far away."));
				return;
			}

			skill.IncreaseOverheat();
			caster.TurnTowards(farPos);
			caster.SetAttackState(true);

			var splashParam = skill.GetSplashParameters(caster, originPos, farPos, length: 90, width: 50, angle: 160);
			var splashArea = skill.GetSplashArea(SplashType.Circle, splashParam);

			Send.ZC_SKILL_READY(caster, skill, originPos, Position.Zero);
			Send.ZC_NORMAL.UpdateSkillEffect(caster, target.Handle, originPos, caster.Position.GetDirection(farPos), Position.Zero);

			CallSafe(this.Attack(skill, caster, splashArea));

			skill.Vars.SetBool("HasFinishedSkillCast", false);
		}

		/// <summary>
		/// Executes the actual attack after a delay.
		/// </summary>
		/// <param name="skill"></param>
		/// <param name="caster"></param>
		/// <param name="splashArea"></param>
		private async Task Attack(Skill skill, ICombatEntity caster, ISplashArea splashArea)
		{
			var hitDelay = TimeSpan.FromMilliseconds(100);

			await Task.Delay(hitDelay);

			var targets = caster.Map.GetAttackableEntitiesIn(caster, splashArea);

			var hitTargets = targets.LimitCossets(5, caster.Position);

			foreach (var target in hitTargets)
			{
				var modifier = SkillModifier.MultiHit(2);

				var skillHitResult = SCR_SkillHit(caster, target, skill, modifier);
				target.TakeDamage(skillHitResult.Damage, caster);

				var hit = new HitInfo(caster, target, skill, skillHitResult);
				hit.ForceId = ForceId.GetNew();
				hit.ResultType = HitResultType.Unk16;

				if (RandomProvider.Get().Next(100) < FreezeChange)
					target.StartBuff(BuffId.Cryomancer_Freeze, skill.Level, 0, TimeSpan.FromSeconds(5), caster);

				Send.ZC_NORMAL.PlayForceEffect(hit.ForceId, caster, caster, target, "I_force110_ice", 0.5f, null, null, 0, null, "SLOW", 300);
				Send.ZC_HIT_INFO(caster, target, hit);
			}

			await Task.Delay(TimeSpan.FromMilliseconds(500));

			Send.ZC_NORMAL.Skill_45(caster);
			Send.ZC_NORMAL.Skill_46(caster, skill.Id);
			Send.ZC_NORMAL.SkillCancelCancel(caster, skill.Id);
		}
	}
}
