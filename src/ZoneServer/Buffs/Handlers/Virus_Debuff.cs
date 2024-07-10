﻿using Melia.Zone.Buffs.Base;
using Melia.Zone.Network;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.Skills.Combat;
using Melia.Shared.Game.Const;

namespace Melia.Zone.Buffs.Handlers
{
	/// <summary>
	/// Handle for the Virus Debuff, which ticks damage while active.
	/// </summary>
	[BuffHandler(BuffId.Virus_Debuff)]
	public class Virus_Debuff : BuffHandler
	{
		private const string varName = "Melia.SpreadTargets";

		public override void OnStart(Buff buff)
		{
			buff.Vars.SetInt(varName, 0);
		}

		public override void WhileActive(Buff buff)
		{
			if (buff.Target.IsDead)
			{
				return;
			}

			// The damage amount is unknow, for now we are dealing
			// the same amount as the original skill hit is passed as NumberArg2
			buff.Target.TakeDamage(buff.NumArg2, buff.Caster);

			var hit = new HitInfo(buff.Caster, buff.Target, null, buff.NumArg2, HitResultType.Hit);

			Send.ZC_HIT_INFO(buff.Caster, buff.Target, null, hit);
		}
	}
}
