using System;
using Melia.Shared.Game.Const;
using Melia.Shared.L10N;
using Melia.Shared.World;
using Melia.Zone.Network;
using Melia.Zone.Skills.Combat;
using Melia.Zone.Skills.Handlers.Base;
using Melia.Zone.Skills.SplashAreas;
using Melia.Zone.World.Actors;
using Yggdrasil.Util;
using static Melia.Zone.Skills.SkillUseFunctions;

namespace Melia.Zone.Skills.Handlers.Wizards.Cryomancer
{
	/// <summary>
	/// Handler for the Cryomancer skill Subzero Shield.
	/// </summary>
	[SkillHandler(SkillId.Cryomancer_SubzeroShield)]
	public class Cryomancer_SubzeroShield : IGroundSkillHandler
	{
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
			if (!caster.TrySpendSp(skill))
			{
				caster.ServerMessage(Localization.Get("Not enough SP."));
				return;
			}

			skill.IncreaseOverheat();
			caster.SetAttackState(true);

			Send.ZC_SKILL_READY(caster, skill, caster.Position, caster.Position);
			Send.ZC_NORMAL.UpdateSkillEffect(caster, 0, caster.Position, caster.Direction, Position.Zero);
			Send.ZC_SKILL_MELEE_GROUND(caster, skill, caster.Position, null);

			this.RemoveRandomDebuff(caster, skill);
			caster.StartBuff(BuffId.Subzero_Buff, TimeSpan.FromMinutes(30));
		}

		/// <summary>
		/// Potentially removes a random debuff from the caster.
		/// </summary>
		/// <param name="caster"></param>
		/// <param name="skill"></param>
		private void RemoveRandomDebuff(ICombatEntity caster, Skill skill)
		{
			var chance = this.GetRemoveDebuffChance(skill);
			caster.RemoveRandomDebuff(chance);
		}

		/// <summary>
		/// Returns the remove Debuff ratio
		/// </summary>
		/// <returns></returns>
		private int GetRemoveDebuffChance(Skill skill)
		{
			return (int)Math.Clamp(skill.Level * 7.5f, 0, 100);
		}
	}
}
