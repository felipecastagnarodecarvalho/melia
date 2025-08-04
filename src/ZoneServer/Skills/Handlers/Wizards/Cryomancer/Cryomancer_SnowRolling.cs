using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Melia.Shared.Game.Const;
using Melia.Shared.L10N;
using Melia.Shared.Util;
using Melia.Shared.World;
using Melia.Zone.Network;
using Melia.Zone.Scripting;
using Melia.Zone.Skills.Combat;
using Melia.Zone.Skills.Handlers.Base;
using Melia.Zone.Skills.SplashAreas;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.CombatEntities.Components;
using Melia.Zone.World.Actors.Monsters;
using Yggdrasil.Util;
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
		private const float SnowballScale = 0.65f;
		private const float SnowballHeight = 10.4f;
		private const int SnowballMonsterId = 47312;
		private const int SnowRollingDuration = 10000;
		private const float DamageRadius = 20f;
		private const int DamageInterval = 200;

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

			var skillHandle = ZoneServer.Instance.World.CreateSkillHandle();

			Send.ZC_SKILL_READY(caster, skill, skillHandle, caster.Position, farPos);
			Send.ZC_NORMAL.UpdateSkillEffect(caster, caster.Handle, caster.Position, caster.Direction, caster.Position);

			this.AddStateClearSkill(caster);
			var snowball = this.CreateSnowball(caster, originPos);
			this.ApplySnowRollingBuff(casterCharacter, skillHandle);

			Send.ZC_SKILL_MELEE_GROUND(caster, skill, farPos, null);

			TaskHelper.CallSafe(this.RollOver(caster, snowball, skill));
		}

		/// <summary>
		/// Starts the roll over routine.
		/// </summary>
		/// <param name="caster"></param>
		/// <param name="snowball"></param>
		/// <param name="skill"></param>
		private async Task RollOver(ICombatEntity caster, Mob snowball, Skill skill)
		{
			var damageTask = this.ApplyDamageAndPullEffect(caster, skill, snowball);

			await Task.WhenAll(Task.Delay(TimeSpan.FromMilliseconds(SnowRollingDuration)), damageTask);

			this.CleanupSnowRolling(caster as Character, snowball);
		}

		/// <summary>
		/// Pull nearby entities, attaching then to the snow ball and applying damage.
		/// </summary>
		/// <param name="caster"></param>
		/// <param name="skill"></param>
		/// <param name="snowball"></param>
		private async Task ApplyDamageAndPullEffect(ICombatEntity caster, Skill skill, Mob snowball)
		{
			var startTime = DateTime.Now;
			var random = RandomProvider.Get();
			while ((DateTime.Now - startTime).TotalMilliseconds < SnowRollingDuration)
			{
				if (snowball.IsDead)
					break;

				snowball.Position = new Position(caster.Position.X, caster.Position.Y - SnowballHeight, caster.Position.Z);
				snowball.Direction = caster.Direction;
				snowball.Vars.Set("NextAvailableAttachPoint", 1);

				var splashArea = new Circle(snowball.Position, DamageRadius);
				var hitDelay = 0;
				var damageDelay = 0;
				var hits = new List<SkillHitInfo>();
				var targets = caster.Map.GetAttackableEntitiesIn(snowball, splashArea);

				foreach (var target in targets)
				{
					// Apply damage
					var splashHitResult = SCR_SkillHit(caster, target, skill);
					target.TakeDamage(splashHitResult.Damage, caster);
					var splashHit = new SkillHitInfo(caster, target, skill, splashHitResult, TimeSpan.FromMilliseconds(damageDelay), TimeSpan.FromMilliseconds(hitDelay));
					hits.Add(splashHit);

					// Apply freeze
					var freezeChance = 100f;
					var freezeDurationMilli = 3000f;
					if ((random.Next(100) < freezeChance) && splashHitResult.Damage > 0)
					{
						target.StartBuff(BuffId.Cryomancer_Freeze, 0, 0, TimeSpan.FromMilliseconds(freezeDurationMilli), caster);
					}

					if (target.MoveType != MoveType.Holding
						&& target.EffectiveSize > SizeType.Hidden
						&& target.EffectiveSize < SizeType.L)
					{
						target.Position = snowball.Position;
						// Attaches target to snowball
						var availableAttachPoint = (int)snowball.Vars.Get("NextAvailableAttachPoint");
						var attachPoint = "Dummy_snow" + availableAttachPoint.ToString();
						Send.ZC_ATTACH_TO_OBJ(target, snowball, attachPoint, "", 0, 0.001f, attachAnimation: AnimationName.DOWN);

						// Increment attach points
						snowball.Vars.Set("NextAvailableAttachPoint", availableAttachPoint + 1);
						if (availableAttachPoint > 20)
							snowball.Vars.Set("NextAvailableAttachPoint", 1);
					}
				}

				if (hits.Count > 0)
					Send.ZC_SKILL_HIT_INFO(caster, hits);

				await Task.Delay(DamageInterval);
			}
		}

		/// <summary>
		/// Apply SnowRolling Buff on the caster.
		/// </summary>
		/// <param name="caster"></param>
		/// <param name="skillHandle"></param>
		private void ApplySnowRollingBuff(ICombatEntity caster, int skillHandle)
		{
			caster.StartBuff(BuffId.SnowRolling_Buff, TimeSpan.FromMilliseconds(SnowRollingDuration));

			if (caster is Character character)
			{
				Send.ZC_SYNC_START(character, skillHandle, 1);
				Send.ZC_SYNC_END(character, skillHandle, 0);
				Send.ZC_SYNC_EXEC_BY_SKILL_TIME(character, skillHandle, TimeSpan.FromMilliseconds(300));
			}
		}

		/// <summary>
		/// Adds the state clear skill so the cast can be stopped.
		/// </summary>
		/// <param name="caster"></param>
		private void AddStateClearSkill(ICombatEntity caster)
		{
			if (caster is Character character)
			{
				character.Skills.AddSilent(new Skill(character, SkillId.Common_StateClear, 1));
				Send.ZC_NORMAL.DisableRegularSkills(character, "SnowRolling_Buff", SkillId.Common_StateClear, true);
			}
		}

		/// <summary>
		/// Adds the state clear skill so the cast can be stopped.
		/// </summary>
		/// <param name="caster"></param>
		/// <param name="originPos"></param>
		private Mob CreateSnowball(ICombatEntity caster, Position originPos)
		{
			var snowball = new Mob(SnowballMonsterId, MonsterType.Friendly)
			{
				Faction = FactionType.Law,
				Position = (originPos + new Position(0, -0.10f, 0)).Floor,
				OwnerHandle = caster.Handle,
				AssociatedHandle = caster.Handle
			};
			snowball.Components.Add(new LifeTimeComponent(snowball, TimeSpan.FromMilliseconds(SnowRollingDuration)));
			snowball.Components.Add(new ControllableMovementComponent(snowball, caster));
			snowball.Died += this.Snowball_Died;
			caster.Map.AddMonster(snowball);
			snowball.StartBuff(BuffId.Invincible);

			this.SetupSnowball(caster, snowball);

			return snowball;
		}

		/// <summary>
		/// Event called once the SnowBall dies.
		/// </summary>
		/// <param name="caster"></param>
		/// <param name="killed"></param>
		private void Snowball_Died(ICombatEntity killer, ICombatEntity killed)
		{
			if (killed is Mob snowball && snowball.Map.TryGetCharacter(snowball.OwnerHandle, out var owner))
				this.CleanupSnowRolling(owner, snowball);
		}

		/// <summary>
		/// Event called once the SnowBall dies.
		/// </summary>
		/// <param name="caster"></param>
		/// <param name="snowball"></param>
		private void SetupSnowball(ICombatEntity caster, Mob snowball)
		{
			Send.ZC_NORMAL.AttachEffect(snowball, "", 1, EffectLocation.Bottom, 0, 10, 0);
			Send.ZC_NORMAL.RideEntity(caster, snowball, 1, 1, 1, "SnowRolling_Buff", 0);
			Send.ZC_NORMAL.Skill_CallLuaFunc(snowball, AnimationName.MissileDead, 2, 4, 0, 3, 1);
			Send.ZC_MOVE_ANIM(snowball, FixedAnimation.WLK, 0);
			Send.ZC_STD_ANIM(snowball, FixedAnimation.WLK);
			Send.ZC_FACTION(snowball);
			Send.ZC_NORMAL.SetScale(snowball, AnimationName.SnowRolling, SnowballScale);
			Send.ZC_NORMAL.DelayEnterWorld(snowball);
			Send.ZC_NORMAL.EnterDelayedActor(snowball);
			Send.ZC_NORMAL.SetHeight(snowball, SnowballHeight);
			caster.AttachToObject(snowball, AnimationName.DummyTop, "None", 0, 0.001f);
			//Send.ZC_ATTACH_TO_OBJ(caster, snowball, AnimationName.DummyTop, "", 0.001f);
			Send.ZC_NORMAL.PlayEffect(caster, 0, EffectLocation.Bottom, 0, 0, AnimationName.Empty);
			Send.ZC_GROUND_EFFECT(caster, snowball.Position, AnimationName.Empty);
		}

		/// <summary>
		/// Event called once the SnowBall dies.
		/// </summary>
		/// <param name="owner"></param>
		/// <param name="snowball"></param>
		private void CleanupSnowRolling(Character owner, Mob snowball)
		{
			owner.Skills.RemoveSilent(SkillId.Common_StateClear);
			Send.ZC_NORMAL.EnableRegularSkills(owner, "SnowRolling_Buff");
			Send.ZC_SKILL_DISABLE(owner);
			Send.ZC_NORMAL.PlayEffect(snowball, 0, EffectLocation.Bottom, 0, 0, AnimationName.Empty, 0, owner.Handle);
			//Send.ZC_ATTACH_TO_OBJ(owner, null, "", "", 0, 1);
			owner.AttachToObject(null, "None", "None", 0, 1);
			owner.Buffs.Remove(BuffId.SnowRolling_Buff);
			Send.ZC_NORMAL.SkillCancelCancel(owner, SkillId.Cryomancer_SnowRolling);
			Send.ZC_NORMAL.ClearEffects(snowball);
			Send.ZC_EXEC_CLIENT_SCP(owner.Connection, ClientScripts.UPDATE_PC_FOLLOWER_LIST);
		}
	}
}
