using Melia.Shared.Game.Const;
using Melia.Zone.Buffs.Base;
using Melia.Zone.Scripting;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.Characters.Components;
using Melia.Zone.World.Items;

namespace Melia.Zone.Buffs.Handlers
{
	/// <summary>
	/// Handle for the Enchant Glove Buff, which increases the target's accuracy (Hit Rate)
	/// </summary>
	[BuffHandler(BuffId.Enchantglove_Buff)]
	public class Enchantglove_Buff : BuffHandler
	{
		private const string VarName = "Melia.HitRateBonus";

		public override void OnStart(Buff buff)
		{
			// It is not applied to characters without Gloves
			if (buff.Caster is Character targetCaster && !(targetCaster.Inventory.GetEquip(EquipSlot.Gloves) is DummyEquipItem))
				return;
				
			// Apply penalty when the CASTER Max Physical Attack is lower than the TARGET Max Physical Attack
			// TODO: Find out the exactly value of the penalty (We are applying 50%)
			var casterMaxPAtk = buff.Caster.Properties.GetFloat(PropertyName.MAXPATK);
			var targetMaxPAtk = buff.Target.Properties.GetFloat(PropertyName.MAXPATK);
			var penaltyValue = casterMaxPAtk < targetMaxPAtk ? 0.5f : 1f;

			var skillLevel = buff.NumArg1;

			var data = ZoneServer.Instance.Data.SkillDb.Find("Enchanter_EnchantGlove");

			var initialHitRateBonus = data.Factor + (skillLevel * data.FactorByLevel);
			var hitRateBonus = initialHitRateBonus * penaltyValue;
			var abilityComponents = buff.Caster.Components.Get<AbilityComponent>();

			// TODO: Add SkillFactor based on the Ability learned.
			//if (abilityComponents.Has(AbilityId.Enchanter9) || abilityComponents.Has(AbilityId.Enchanter14))
			//{
			//	var SCR_Get_SkillFactor = ScriptableFunctions.Skill.Get("SCR_Get_SkillFactor");
			//	if (buff.Caster is Character casterCharacter && casterCharacter.Skills.TryGet(buff.SkillId, out var skill))
			//	{
			//		var abilityBonus = SCR_Get_SkillFactor(skill);
			//		hitRateBonus += abilityBonus;
			//	}
			//}

			buff.Vars.SetFloat(VarName, hitRateBonus);

			buff.Target.Properties.Modify(PropertyName.HR_BM, hitRateBonus);			
		}

		public override void OnEnd(Buff buff)
		{
			if (buff.Vars.TryGetFloat(VarName, out var bonus))
			{
				buff.Target.Properties.Modify(PropertyName.HR_BM, -bonus);
			}
		}
	}
}
