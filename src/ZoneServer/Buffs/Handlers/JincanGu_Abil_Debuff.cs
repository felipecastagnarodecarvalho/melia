﻿using Melia.Zone.Buffs.Base;
using Melia.Zone.Network;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.Skills.Combat;
using Melia.Shared.Game.Const;

namespace Melia.Zone.Buffs.Handlers
{
	/// <summary>
	/// Handle for the Virus Debuff, which ticks damage every second.
	/// </summary>
	[BuffHandler(BuffId.JincanGu_Abil_Debuff)]
	public class JincanGu_Abil_Debuff : BuffHandler
	{
		public override void WhileActive(Buff buff)
		{
			var casterCharacter = buff.Caster as Character;

			if (casterCharacter != null)
			{
				if (buff.Target.IsDead)
				{
					return;
				}

				// The damage amount is unknow, for now we are dealing
				// the same amount as the original skill hit is passed as NumberArg2
				buff.Target.TakeDamage(buff.NumArg2, casterCharacter);

				var hit = new HitInfo(casterCharacter, buff.Target, null, buff.NumArg2, HitResultType.Hit);
				hit.ForceId = ForceId.GetNew();

				Send.ZC_HIT_INFO(casterCharacter, buff.Target, null, hit);
			}
		}
	}
}