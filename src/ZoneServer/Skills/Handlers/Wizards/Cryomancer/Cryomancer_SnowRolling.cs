using System;
using System.Linq;
using System.Threading.Tasks;
using Melia.Shared.Game.Const;
using Melia.Shared.L10N;
using Melia.Shared.Util;
using Melia.Shared.World;
using Melia.Zone.Network;
using Melia.Zone.Skills.Combat;
using Melia.Zone.Skills.Handlers.Base;
using Melia.Zone.Skills.SplashAreas;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.Monsters;
using static Melia.Zone.Skills.SkillUseFunctions;

namespace Melia.Zone.Skills.Handlers.Wizards.Cryomancer
{
	/// <summary>
	/// Handler for the Cryomancer skill Snow Rolling.
	/// </summary>
	/// <remarks>
	/// TODO: Implement the sub-attack feature - once the caster attacks the ice wall it should spread particles that damage enemies.
	/// </remarks>
	[SkillHandler(SkillId.Cryomancer_SnowRolling)]
	public class Cryomancer_SnowRolling : IGroundSkillHandler, IDynamicCasted
	{
		/// <summary>
		/// Called when the user starts casting the skill.
		/// </summary>
		/// <param name="skill"></param>
		/// <param name="caster"></param>
		public void StartDynamicCast(Skill skill, ICombatEntity caster)
		{
			if (caster is not Character casterCharacter)
				return;

			Send.ZC_NORMAL.UnkDynamicCastStart(casterCharacter, skill.Id);
			Send.ZC_PLAY_SOUND_Gendered(caster, "voice_wiz_m_snowrolling_shot", "voice_wiz_snowrolling_shot");
		}

		/// <summary>
		/// Called when the user stops casting the skill.
		/// </summary>
		/// <param name="skill"></param>
		/// <param name="caster"></param>
		public void EndDynamicCast(Skill skill, ICombatEntity caster)
		{
			if (caster is not Character casterCharacter)
				return;

			Send.ZC_NORMAL.UnkDynamicCastEnd(casterCharacter, skill.Id, 1);
			Send.ZC_STOP_SOUND_Gendered(caster, "voice_wiz_m_snowrolling_shot", "voice_wiz_snowrolling_shot");
		}

		/// <summary>
		/// Handles skill, creates the ice wall.
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

			originPos = caster.Position;
			skill.IncreaseOverheat();
			caster.SetAttackState(true);

			if (caster is not Character casterCharacter)
				return;

			// Spawns the Snow Sphere
			var snowSphere = new Mob(47312, MonsterType.Mob);
			snowSphere.Position = caster.Position;
			snowSphere.Faction = FactionType.IceWall;
			snowSphere.FromGround = true;
			snowSphere.Direction = caster.Direction;
			snowSphere.Components.Add(new ControllableMovementComponent(snowSphere, caster));

			caster.Map.AddMonster(snowSphere);

			var duration = TimeSpan.FromSeconds(10);
			snowSphere.StartBuff(BuffId.Cryomancer_Object_Buff);
			caster.StartBuff(BuffId.SnowRolling_Buff, duration);

			Send.ZC_ATTACH_TO_OBJ(caster, snowSphere, "Dummy_top", null, TimeSpan.FromMilliseconds(1), 0, null, 0, 1, 0);

			Send.ZC_NORMAL.DisableRegularSkills(casterCharacter, "SnowRolling_Buff", SkillId.Common_StateClear);
			Send.ZC_NORMAL.Skill_13E(snowSphere, true);
			Send.ZC_NORMAL.UpdateScale(snowSphere, 1628, 0.85f, false, 0);
			Send.ZC_NORMAL.Skill_B7(snowSphere, 12);
			Send.ZC_NORMAL.AttachCasterToSnowBall(caster, snowSphere, "SnowRolling_Buff", true, true, true, false);
			
			Send.ZC_SKILL_READY(caster, skill, caster.Position, caster.Position);
			Send.ZC_NORMAL.UpdateSkillEffect(caster, 0, caster.Position, caster.Direction, Position.Zero);
			Send.ZC_SKILL_MELEE_GROUND(caster, skill, caster.Position, null);
			Send.ZC_STD_ANIM(snowSphere, 13);

			Send.ZC_NORMAL.Skill_26(snowSphere, "MSL_DEAD_C");
			Send.ZC_NORMAL.Skill_99(snowSphere, 0f);
			Send.ZC_NORMAL.Skill_C8(snowSphere, true);

			Send.ZC_NORMAL.PlayEffect(caster, "", 0, EffectLocation.Bottom);

			skill.Vars.SetBool("IsOverSnowBall", true);

			TaskHelper.CallSafe(this.RollOver(caster, snowSphere, skill));
			TaskHelper.CallSafe(this.EndSnowRolling(caster, snowSphere, duration, skill));
		}

		/// <summary>
		/// Roll Over nearby entities, attaching then to the snow ball.
		/// </summary>
		/// <param name="caster"></param>
		/// <param name="snowSphere"></param>
		/// <param name="skill"></param>
		private async Task RollOver(ICombatEntity caster, Mob snowSphere, Skill skill)
		{
			var targetsAttached = 0;

			while(true)
			{
				if (!skill.Vars.GetBool("IsOverSnowBall"))				
					break;
				
				var splashArea = new Circle(caster.Position, 35);

				var targets = caster.Map.GetAttackableEntitiesIn(caster, splashArea);
				if (!targets.Any())
				{
					await Task.Delay(TimeSpan.FromMilliseconds(150));
					return;
				}

				foreach(var target in targets)
				{
					if (targetsAttached >= 10)
						continue;

					Send.ZC_ATTACH_TO_OBJ(target, snowSphere, "Dummy_snow17", null, TimeSpan.FromMilliseconds(1), 0, "DOWN", 0, 1, 0);
					this.Attack(skill, caster, target);
					targetsAttached++;
				}

				await Task.Delay(TimeSpan.FromMilliseconds(150));
			}
		}

		/// <summary>
		/// Destroy entity after a duration.
		/// </summary>
		/// <param name="caster"></param>
		/// <param name="entity"></param>
		/// <param name="duration"></param>
		/// <param name="skill"></param>
		private async Task EndSnowRolling(ICombatEntity caster, Mob entity, TimeSpan duration, Skill skill)
		{
			await Task.Delay(duration);
			skill.Vars.SetBool("IsOverSnowBall", false);
			Send.ZC_NORMAL.EnableRegularSkills(caster as Character, "SnowRolling_Buff");
			entity.Kill(caster);
			Send.ZC_NORMAL.ClearEffects(entity);
		}

		/// <summary>
		/// Commit the actual attack on targets inside the snowball.
		/// </summary>
		/// <param name="skill"></param>
		/// <param name="caster"></param>
		/// <param name="target"></param>
		private void Attack(Skill skill, ICombatEntity caster, ICombatEntity target)
		{
			var skillHitResult = SCR_SkillHit(caster, target, skill);
			target.TakeDamage(skillHitResult.Damage, caster);

			var hit = new HitInfo(caster, target, skill, skillHitResult);

			Send.ZC_HIT_INFO(caster, target, hit);
		}
	}
}
