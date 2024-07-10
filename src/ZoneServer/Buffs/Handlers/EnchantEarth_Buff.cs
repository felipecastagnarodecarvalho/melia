using System.Threading.Tasks;
using System;
using Melia.Shared.Game.Const;
using Melia.Zone.Buffs.Base;
using Melia.Zone.Scripting;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.Characters.Components;

namespace Melia.Zone.Buffs.Handlers
{
	/// <summary>
	/// Handle for the Enchant Earth Buff, which increases the target's block penetration
	/// </summary>
	[BuffHandler(BuffId.EnchantEarth_Buff)]
	public class EnchantEarth_Buff : BuffHandler
	{
		private const string VarName = "Melia.EnchantEarth_Buff.BlockPenetrationBonus";
		private const string DifferentMapVarName = "Melia.EnchantEarth_Buff.DifferentMap";

		public override async void WhileActive(Buff buff)
		{
			// End the Buff if the Caster is Disconnected
			// TODO: Replace !casterCharacter.Connection.LoggedIn with a right way of checking if the character is online
			if (buff.Caster is Character casterCharacter && !casterCharacter.Connection.LoggedIn)
			{
				buff.End();
				return;
			}

			// End the Buff if the Caster is Dead
			if (buff.Caster.IsDead)
			{
				buff.End();
				return;
			}

			// Ends the Buff if the Caster and Target are not in the same map
			if (buff.Caster.Map.Id != buff.Target.Map.Id)
			{
				var differentMapHelper = buff.Vars.GetInt(DifferentMapVarName);

				if (differentMapHelper + 1 >= 3)
				{
					buff.End();
					return;
				}

				buff.Vars.SetInt(DifferentMapVarName, differentMapHelper + 1);
			}
			else
			{
				buff.Vars.SetInt(DifferentMapVarName, 0);
			}

			await Task.Delay(TimeSpan.FromSeconds(10));
		}

		public override void OnStart(Buff buff)
		{
			if (buff.Caster is Character casterCharacter && buff.Target is Character targetCharacter)
			{
				// Apply penality when the CASTER Max Physical Attack is lower than the TARGET Max Physical Attack
				// TODO: Find out the exacly value of the penality (We are applying 50%)
				var casterMaxPAtk = casterCharacter.Properties.GetFloat(PropertyName.MAXPATK);
				var targetMaxPAtk = targetCharacter.Properties.GetFloat(PropertyName.MAXPATK);
				var penaltyValue = casterMaxPAtk < targetMaxPAtk ? 0.5f : 1f;

				var skillLevel = buff.NumArg1;

				var data = ZoneServer.Instance.Data.SkillDb.Find(SkillId.Enchanter_EnchantEarth);

				var initialBlockPenBonus = data.Factor + (skillLevel * data.FactorByLevel);
				var blockPenetrationBonus = initialBlockPenBonus * penaltyValue;

				if (casterCharacter.Components.Get<AbilityComponent>().Has(AbilityId.Enchanter10))
				{
					var SCR_Get_SkillFactor = ScriptableFunctions.Skill.Get("SCR_Get_SkillFactor");
					if (casterCharacter.Skills.TryGet(buff.SkillId, out var skill))
					{
						var abilityBonus = SCR_Get_SkillFactor(skill);
						blockPenetrationBonus += abilityBonus;
					}
				}

				buff.Vars.SetFloat(VarName, blockPenetrationBonus);
				buff.Vars.SetInt(DifferentMapVarName, 0);

				buff.Target.Properties.Modify(PropertyName.BLK_BREAK_BM, blockPenetrationBonus);				
			}
		}

		public override void OnEnd(Buff buff)
		{
			if (buff.Target is Character)
			{
				if (buff.Vars.TryGetFloat(VarName, out var bonus))
				{
					buff.Target.Properties.Modify(PropertyName.BLK_BREAK_BM, -bonus);
				}
			}
		}
	}
}
