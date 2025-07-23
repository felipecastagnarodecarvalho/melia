using Melia.Shared.Game.Const;
using Melia.Zone.Buffs.Base;
using Melia.Zone.Skills;
using Melia.Zone.Skills.Combat;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Components;

namespace Melia.Zone.Buffs.Handlers.Common
{
	/// <summary>
	/// Handle for the Igloo Freeze Immune Buff
	/// </summary>
	[BuffHandler(BuffId.Igloo_FreezeImmune_Buff)]
	public class Igloo_FreezeImmune_Buff : BuffHandler
	{
		/// <summary>
		/// Starts buff activation.
		/// </summary>
		/// <param name="buff"></param>
		public override void OnActivate(Buff buff, ActivationType activationType)
		{
			buff.Target.RemoveState(StateType.Frozen);

			// Decreases magic defense by 30%
			var reduceMDef = buff.Target.Properties.GetFloat(PropertyName.MDEF);
			buff.Target.Properties.Modify(PropertyName.MDEF_BM, (float)(reduceMDef * -0.3f));

			if (buff.Target.IsBuffActive(BuffId.Cryomancer_Freeze))
				buff.Target.StopBuff(BuffId.Cryomancer_Freeze);
		}

		/// <summary>
		/// Ends the buff.
		/// </summary>
		/// <param name="buff"></param>
		public override void OnEnd(Buff buff)
		{
			// Restore magic defense (30%)
			var reduceMDef = buff.Target.Properties.GetFloat(PropertyName.MDEF);
			buff.Target.Properties.Modify(PropertyName.MDEF_BM, (float)(reduceMDef * 0.3f));
		}
	}
}
