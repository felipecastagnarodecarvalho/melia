using Melia.Shared.World;

namespace Melia.Zone.Skills
{
	public struct SkillCell
	{
		public Position Position;
		public Direction Direction;

		public SkillCell(Position position, Direction direction)
		{
			Position = position;
			Direction = direction;
		}
	}
}
