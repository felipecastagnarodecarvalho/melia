using Melia.Shared.Game.Const;
using Melia.Zone.Network;
using Melia.Zone.World.Actors.Monsters;

namespace Melia.Zone.Pads.Handlers.Wizards.Cryomancer
{
	/// <summary>
	/// Handler for the Cryomancer_Igloo pad, creates and disables the effect.
	/// </summary>
	[PadHandler(PadName.Cryomancer_Igloo)]
	public class Cryomancer_Igloo : ICreatePadHandler, IDestroyPadHandler
	{
		/// <summary>
		/// Called when the pad is created.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="args"></param>
		public void Created(object sender, PadTriggerArgs args)
		{
			var pad = args.Trigger;
			var creator = args.Creator;

			Send.ZC_NORMAL.PadUpdate(creator, pad, PadName.Cryomancer_Igloo, pad.Direction.RadianAngle, (float)creator.Position.Get2DDistance(pad.Position), 70, true);
		}

		/// <summary>
		/// Called when the pad is destroyed.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="args"></param>
		public void Destroyed(object sender, PadTriggerArgs args)
		{
			var pad = args.Trigger;
			var creator = args.Creator;

			Send.ZC_NORMAL.PadUpdate(creator, pad, PadName.Cryomancer_Igloo, pad.Direction.RadianAngle, (float)creator.Position.Get2DDistance(pad.Position), 70, false);
		}
	}
}
