using Melia.Shared.Game.Const;
using Melia.Zone.Buffs.Base;
using Melia.Zone.World.Actors.Characters;

namespace Melia.Zone.Buffs.Handlers
{
	/// <summary>
	/// Handle for the Zhendu Buff, which increases the other Wugushi skills final damage.
	/// </summary>
	[BuffHandler(BuffId.Zhendu_Buff)]
	public class Zhendu_Buff : BuffHandler
	{
		private const string varName = "Melia.Zhendu_Buff.DmgIncPercentage";

		public override void OnStart(Buff buff)
		{
			var dmgIncPercentage = 100 + this.GetDamageIncreasePercentage(buff);

			buff.Vars.SetFloat(varName, dmgIncPercentage);

			// TODO: Increase all the Wugushi skills damage by a percentage (Look into  Deeds of Valor - Doppel PR)
		}

		public override void OnEnd(Buff buff)
		{
			if (buff.Vars.TryGetFloat(varName, out var bonus))
			{
				// TODO: Decrease all the Wugushi skills damage by a percentage (Look into  Deeds of Valor - Doppel PR)
			}
		}

		// This may be useful later.
		/*private float GetRatio(Buff buff)
		{
			return Convert.ToSingle((15 * buff.Target.Level) + (buff.Skill.Level * buff.Target.Level * 3.3));
		}

		private float GetRatio(Buff buff)
		{
			var minPAtk = buff.Target.Properties.GetFloat(PropertyName.MINPATK);
			var maxPAtk = buff.Target.Properties.GetFloat(PropertyName.MAXPATK);
			var value = Math.Floor(((minPAtk + maxPAtk) / 2) * 0.5);
			return Convert.ToSingle(value);
		}*/

		private float GetDamageIncreasePercentage(Buff buff)
		{
			var skillLevel = buff.NumArg1;
			return 5 + skillLevel * 2;
		}
	}
}
