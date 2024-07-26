﻿using System;
using System.Threading.Tasks;
using Melia.Shared.Game.Const;
using Melia.Zone.Buffs.Base;
using Melia.Zone.Network;
using Melia.Zone.Skills.Combat;
using Melia.Zone.World.Actors;
using static Melia.Zone.Skills.SkillUseFunctions;

namespace Melia.Zone.Buffs.Handlers.Archer.Wugushi
{
	/// <summary>
	/// Handle for the WideMiasma Debuff, which ticks damage every second.
	/// </summary>
	[BuffHandler(BuffId.WideMiasma_Debuff)]
	public class WideMiasma_Debuff : BuffHandler
	{
		public override async void WhileActive(Buff buff)
		{
			if (buff.Target.IsDead)
				return;

			if (buff.Caster.TryGetSkill((SkillId)buff.NumArg2, out var skill))
			{
				var damageMultiplier = 1f;

				if (buff.Caster.TryGetBuff(BuffId.Zhendu_Buff, out var ZhenduBuff))
					damageMultiplier = ZhenduBuff.NumArg1;

				var skillHitResult = SCR_SkillHit(buff.Caster, buff.Target, skill);
				skillHitResult.Damage *= damageMultiplier;

				// The damage amount is unknow, for now we are dealing
				// the same amount as the original skill hit is passed as NumberArg2
				buff.Target.TakeDamage(skillHitResult.Damage, buff.Caster);

				var hit = new HitInfo(buff.Caster, buff.Target, SkillId.Wugushi_WideMiasma, skillHitResult.Damage, HitResultType.Buff26);

				Send.ZC_HIT_INFO(buff.Caster, buff.Target, hit);
			}

			var damageThickDelay = 1000f;
			var skillLevel = (int)buff.NumArg1;

			Crescendo_Bane_Buff.TryApply(buff.Caster, ref damageThickDelay);

			await Task.Delay(TimeSpan.FromMilliseconds(damageThickDelay));
		}
	}
}