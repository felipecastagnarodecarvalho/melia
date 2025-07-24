using Melia.Shared.World;
using Melia.Zone.Network;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Components;

public class ControllableMovementComponent : ActorMovementComponent
{
	/// <summary>
	/// Returns the actual owner of the child actor.
	/// </summary>
	public IActor ParentOwner { get; }

	/// <summary>
	/// Creates new instance for controllable movement component.
	/// </summary>
	/// <param name="actor"></param>
	/// <param name="parentOwner"></param>
	public ControllableMovementComponent(IActor actor, IActor parentOwner) : base(actor) {
		this.ParentOwner = parentOwner;
	}

	/// <summary>
	/// Updates the entity's movement on nearby clients.
	/// </summary>
	/// <param name="pos"></param>
	/// <param name="dest"></param>
	/// <param name="speed"></param>
	protected override void UpdateMoveTo(Position pos, Position dest, float speed)
	{
		Send.ZC_MOVE_PATH(this.Owner, pos, dest, speed);
	}

	/// <summary>
	/// Stops the movement at the given position on nearby clients.
	/// </summary>
	/// <param name="pos"></param>
	protected override void UpdateStop(Position pos)
	{
		if (this.Owner is ICombatEntity combatEntity)
			Send.ZC_MOVE_STOP(combatEntity, pos);
	}
}
