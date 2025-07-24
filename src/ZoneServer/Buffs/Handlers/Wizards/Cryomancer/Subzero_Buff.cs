using System;
using Melia.Shared.Game.Const;
using Melia.Zone.Buffs.Base;
using Melia.Zone.Network;
using Melia.Zone.Skills;
using Melia.Zone.Skills.Combat;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Characters;
using Yggdrasil.Util;
using static Melia.Zone.Skills.SkillUseFunctions;

namespace Melia.Zone.Buffs.Handlers.Common
{
	/// <summary>
	/// Handle for the Subzero Buff
	/// </summary>
	[BuffHandler(BuffId.Subzero_Buff)]
	public class Subzero_Buff : BuffHandler, IBuffCombatDefenseAfterCalcHandler
	{
		/// <summary>
		/// Applies the buff's effect during the combat calculations.
		/// </summary>
		/// <param name="buff"></param>
		/// <param name="attacker"></param>
		/// <param name="target"></param>
		/// <param name="skill"></param>
		/// <param name="modifier"></param>
		/// <param name="skillHitResult"></param>
		public void OnDefenseAfterCalc(Buff buff, ICombatEntity attacker, ICombatEntity target, Skill skill, SkillModifier modifier, SkillHitResult skillHitResult)
		{
			if ((skill.IsNormalAttack || skill.IsMonsterSkill) && target.IsBuffActive(BuffId.Subzero_Buff))
			{
				if (RandomProvider.Get().Next(100) < this.GetBlockingChance(target, skill))
				{
					skillHitResult.Damage *= this.GetDamageReduction(skill);
					attacker.StartBuff(BuffId.Cryomancer_Freeze, skill.Level, 0, this.GetFreezeDuration(target), target);

					// Subzero Shield: Counterattack - "Reflects" the attack
					if (target.IsAbilityActive(AbilityId.Cryomancer10) && target.TryGetAbility(AbilityId.Cryomancer10, out var ability))
					{
						if (target is not Character character || character.Inventory.GetItem(EquipSlot.LeftHand)?.Data.EquipType1 != EquipType.Shield)
							return;
						
						if (!target.TryGetSkill(SkillId.Default, out var skillCounter))						
							skillCounter = skill;
						
						var skillHitResultCounter = SCR_SkillHit(target, attacker, skillCounter);

						var shield = character.Inventory.GetItem(EquipSlot.LeftHand);
						skillHitResult.Damage = shield.Data.Def * 2.41f;

						attacker.TakeDamage(skillHitResult.Damage, target);

						var hit = new HitInfo(target, attacker, skillCounter, skillHitResultCounter.Damage, skillHitResultCounter.Result);
						Send.ZC_HIT_INFO(target, attacker, hit);
					}
				}
			}
		}

		/// <summary>
		/// Returns the blocking chance.
		/// </summary>
		private float GetBlockingChance(ICombatEntity target, Skill skill)
		{
			var skillFactorBase = skill.Properties.GetFloat(PropertyName.SkillFactor);
			var skillFactorPerLevel = skill.Properties.GetFloat(PropertyName.SklFactorByLevel);
			var value = skillFactorBase + skill.Level * skillFactorPerLevel;

			if(target.IsAbilityActive(AbilityId.Cryomancer9) && target.TryGetAbility(AbilityId.Cryomancer9, out var ability))			
				value = value * (1 + (ability.Level * 0.05f));

			// TODO: Check if it's a PVP Map and decrease the chance by 50%
			return value;
		}

		/// <summary>
		/// Returns the damage reduction value (on successful blocking).
		/// </summary>
		private float GetDamageReduction(Skill skill)
		{
			return 0.43f + (skill.Level * 0.04f);
		}

		private TimeSpan GetFreezeDuration(ICombatEntity caster)
		{
			var duration = 3;

			// Subzero Shield: Duration
			if (caster.IsAbilityActive(AbilityId.Cryomancer7) && caster.TryGetAbility(AbilityId.Cryomancer7, out var ability))
				duration += (int)(ability.Level * 0.5f);

			return TimeSpan.FromSeconds(duration);
		}
	}
}
