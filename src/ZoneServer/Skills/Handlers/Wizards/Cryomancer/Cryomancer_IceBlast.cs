using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Melia.Shared.Game.Const;
using Melia.Shared.L10N;
using Melia.Shared.World;
using Melia.Zone.Network;
using Melia.Zone.Skills.Combat;
using Melia.Zone.Skills.Handlers.Base;
using Melia.Zone.Skills.SplashAreas;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.Monsters;
using static Melia.Shared.Util.TaskHelper;
using static Melia.Zone.Skills.SkillUseFunctions;

namespace Melia.Zone.Skills.Handlers.Wizards.Cryomancer
{
	/// <summary>
	/// Handler for the Cryomancer skill Ice Blast.
	/// </summary>
	[SkillHandler(SkillId.Cryomancer_IceBlast)]
	public class Cryomancer_IceBlast : IGroundSkillHandler, IDynamicCasted, ISkillCombatAttackBeforeCalcHandler, ISkillCombatAttackAfterCalcHandler
	{
		// <summary>
		/// Called when the user starts casting the skill.
		/// </summary>
		/// <param name="skill"></param>
		/// <param name="caster"></param>
		public void StartDynamicCast(Skill skill, ICombatEntity caster)
		{
			if (!caster.IsAbilityActive(AbilityId.Cryomancer24))
				return;

			Send.ZC_PLAY_SOUND_Gendered(caster, "voice_war_atk_long_shot", "voice_atk_long_war_f");
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
			if (!caster.IsAbilityActive(AbilityId.Cryomancer24))
				return;

			Send.ZC_STOP_SOUND_Gendered(caster, "voice_war_atk_long_shot", "voice_atk_long_war_f");
			skill.Vars.SetBool("HasFinishedSkillCast", true);

			if (caster is Character casterCharacter)
				Send.ZC_NORMAL.UnkDynamicCastEnd(casterCharacter, skill.Id, 2);
		}

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
			// Ice Blast: Break - Casting version of the skill while the ability is active
			if (caster.IsAbilityActive(AbilityId.Cryomancer24) && !skill.Vars.GetBool("HasFinishedSkillCast"))			
				return;

			if (!caster.TrySpendSp(skill))
			{
				caster.ServerMessage(Localization.Get("Not enough SP."));
				return;
			}

			skill.IncreaseOverheat();
			caster.TurnTowards(farPos);
			caster.SetAttackState(true);

			Send.ZC_SKILL_READY(caster, skill, originPos, farPos);
			Send.ZC_NORMAL.UpdateSkillEffect(caster, target != null ? target.Handle : 0, originPos, caster.Direction, Position.Zero);
			Send.ZC_SKILL_MELEE_GROUND(caster, skill, farPos, null);

			CallSafe(this.Active(skill, caster, new Circle(caster.Position, 180)));
		}

		/// <summary>
		/// Activates the skill, searching for entities on the area.
		/// </summary>
		/// <param name="skill"></param>
		/// <param name="caster"></param>
		/// <param name="activationArea"></param>
		private async Task Active(Skill skill, ICombatEntity caster, ISplashArea activationArea)
		{
			var targets = caster.Map.GetAttackableEntitiesIn(caster, activationArea);
			var hitTargets = 0;
			var hitTargetHandles = new List<int>();

			foreach (var target in targets)
			{
				// Make sure that we only hit 8 targets
				if (hitTargets >= 8)
					break;

				// Deals damage to enemies nearby ice walls
				if (target is Mob mob && mob.Data.Id == 47452)
				{
					var splashArea = new Square(mob.Position, mob.Direction, 25, 25);
					var targetsNearWall = caster.Map.GetAttackableEntitiesIn(caster, splashArea);
					foreach (var targetNearWall in targetsNearWall.LimitRandom(3))
					{
						if (targetNearWall is Mob mob2 && mob2.Data.Id == 47452 || hitTargetHandles.Contains(targetNearWall.Handle))
							continue;

						CallSafe(this.Attack(skill, caster, targetNearWall));
						hitTargetHandles.Add(targetNearWall.Handle);
						hitTargets++;
					}
					continue;
				}

				// Deals damage to frozen enemies
				if (target.IsBuffActive(BuffId.Cryomancer_Freeze)) {					
					CallSafe(this.Attack(skill, caster, target));
					hitTargets++;
				}					
			}
		}

		/// <summary>
		/// Executes the actual attack after a delay.
		/// </summary>
		/// <param name="skill"></param>
		/// <param name="caster"></param>
		/// <param name="target"></param>
		private async Task Attack(Skill skill, ICombatEntity caster, ICombatEntity target)
		{
			SkillModifier modifier = null;

			if (caster.IsAbilityActive(AbilityId.Cryomancer24))
			{
				modifier = SkillModifier.MultiHit(4);

				if (target.IsBuffActive(BuffId.Cryomancer_Freeze))				
					target.StopBuff(BuffId.Cryomancer_Freeze);				
			}

			var skillHitResult = SCR_SkillHit(caster, target, skill, modifier != null ? modifier : SkillModifier.Default);
			target.TakeDamage(skillHitResult.Damage, caster);

			var hit = new HitInfo(caster, target, skill, skillHitResult, TimeSpan.FromMilliseconds(100));
			Send.ZC_HIT_INFO(caster, target, hit);
		}

		/// <summary>
		/// On Attack Before Calculations.
		/// </summary>
		/// <param name="skill"></param>
		/// <param name="attacker"></param>
		/// <param name="target"></param>
		/// <param name="attackerSkill"></param>
		/// <param name="modifier"></param>
		/// <param name="skillHitResult"></param>
		public void OnAttackBeforeCalc(Skill skill, ICombatEntity attacker, ICombatEntity target, Skill attackerSkill, SkillModifier modifier, SkillHitResult skillHitResult)
		{
			// Ice Blast: Break - Ignore 20% of the target defense.
			if (attackerSkill.Id == SkillId.Cryomancer_IceBlast && attacker.IsAbilityActive(AbilityId.Cryomancer24))
			{
				var reduceDef = target.Properties.GetFloat(PropertyName.DEF);
				target.Properties.Modify(PropertyName.DEF_BM, (float)(reduceDef * -0.2f));
			}
		}

		/// <summary>
		/// Defense Calculations Before Calculations.
		/// </summary>
		/// <param name="skill"></param>
		/// <param name="attacker"></param>
		/// <param name="target"></param>
		/// <param name="attackerSkill"></param>
		/// <param name="modifier"></param>
		/// <param name="skillHitResult"></param>
		public void OnAttackAfterCalc(Skill skill, ICombatEntity attacker, ICombatEntity target, Skill attackerSkill, SkillModifier modifier, SkillHitResult skillHitResult)
		{
			// Ice Blast: Break - Restoration of ignore 20% of the target defense.
			if (attackerSkill.Id == SkillId.Cryomancer_IceBlast && attacker.IsAbilityActive(AbilityId.Cryomancer24))
			{
				var reduceDef = target.Properties.GetFloat(PropertyName.DEF);
				target.Properties.Modify(PropertyName.DEF_BM, (float)(reduceDef * 0.2f));
			}
		}
	}
}
