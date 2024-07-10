﻿using System;
using Melia.Shared.Game.Const;
using Melia.Zone.Buffs.Base;
using Melia.Zone.Scripting;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.Characters.Components;

namespace Melia.Zone.Buffs.Handlers
{
	/// <summary>
	/// Handle for the Over Reinforce Buff, which increases the target's physical and magic attack
	/// </summary>
	[BuffHandler(BuffId.OverReinforce_Buff)]
	public class OverReinforce_Buff : BuffHandler
	{
		private const string VarName = "Melia.MagicAndPhysicalAttackBonus";

		public override void OnStart(Buff buff)
		{
			var maxPATK = buff.Caster.Properties.GetFloat(PropertyName.MAXPATK);
			var minPATK = buff.Caster.Properties.GetFloat(PropertyName.MINPATK);

			var skillLevel = buff.NumArg1;

			var rate = 0.015f + skillLevel * 0.004f;

			// TODO: Implement the usage of 'ITEM_VIBORA_Empowering' that will modify the buff behavior

			var attackBonus = ((maxPATK + minPATK) / 2) * rate;

			attackBonus = (float)Math.Floor(attackBonus);

			if (buff.Caster.Components.Get<AbilityComponent>().Has(AbilityId.Enchanter15))
			{
				var SCR_Get_SkillFactor = ScriptableFunctions.Skill.Get("SCR_Get_SkillFactor");
				if (buff.Caster is Character casterCharacter && casterCharacter.Skills.TryGet(buff.SkillId, out var skill))
				{
					var abilityBonus = SCR_Get_SkillFactor(skill);
					attackBonus += abilityBonus;
				}
			}

			buff.Vars.SetFloat(VarName, attackBonus);

			buff.Target.Properties.Modify(PropertyName.MATK_BM, attackBonus);
			buff.Target.Properties.Modify(PropertyName.PATK_BM, attackBonus);
		}

		public override void OnEnd(Buff buff)
		{
			if (buff.Vars.TryGetFloat(VarName, out var bonus))
			{
				buff.Target.Properties.Modify(PropertyName.MATK_BM, -bonus);
				buff.Target.Properties.Modify(PropertyName.PATK_BM, -bonus);
			}
		}
	}
}
