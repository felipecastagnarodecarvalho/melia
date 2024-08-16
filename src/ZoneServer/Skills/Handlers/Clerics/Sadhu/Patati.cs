﻿using Melia.Shared.Game.Const;
using Melia.Shared.World;
using Melia.Zone.Skills.Handlers.Base;
using Melia.Zone.World.Actors;

namespace Melia.Zone.Skills.Handlers.Clerics.Sadhu
{
	/// <summary>
	/// Handler for the Sadhu skill Patati.
	/// </summary>
	[SkillHandler(SkillId.Sadhu_Patati)]
	public class Patati : SadhuBaseSkill, IGroundSkillHandler
	{
		/// <summary>
		/// Handles skill, makes the character out of body.
		/// </summary>
		/// <param name="skill"></param>
		/// <param name="caster"></param>
		/// <param name="originPos"></param>
		/// <param name="farPos"></param>
		/// <param name="target"></param>
		public void Handle(Skill skill, ICombatEntity caster, Position originPos, Position farPos, ICombatEntity target)
		{
			Handle(skill, caster, originPos, farPos, target, BuffId.OOBE_Patati_Buff);
		}
	}
}
