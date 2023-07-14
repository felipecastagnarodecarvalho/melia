//--- Melia Script ----------------------------------------------------------
// Recipe Crafting Scripts
//--- Description -----------------------------------------------------------
// Recipe-related crafting scripts, only used to create items while sitting
//---------------------------------------------------------------------------

using System;
using Melia.Shared.Tos.Const;
using Melia.Zone;
using Melia.Zone.Network;
using Melia.Zone.Scripting;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Items;

public class RecipeCraftingScripts : GeneralScript
{
	[ScriptableFunction("SCR_ITEM_MANUFACTURE_Recipe")]
	public DialogTxResult TxRecipeCraftScriptFunc(Character character, DialogTxArgs args)
	{
		var recipeId = args.NumArgs.Length > 0 ? args.NumArgs[0] : 0;
		var craftAmount = args.NumArgs.Length > 1 ? args.NumArgs[0] : 0;

		// var craftData = ZoneServer.Instance.

		//foreach (var txItem in args.TxItems)
		//{
		//	var item = txItem.Item;
		//	var amount = txItem.Amount;

		//	if (item.Data.Script.StrArg != "XpCard")
		//		throw new ArgumentException($"Item '{item.Id}' is not an EXP card.");

		//	var numArg1 = item.Data.Script.NumArg1;
		//	var baseExp = (long)numArg1;
		//	var classExp = (long)(baseExp * 0.77f);

		//	baseExp *= amount;
		//	classExp *= amount;

		//	character.GiveExp(baseExp, classExp, null);
		//	character.SystemMessage("GetExp{CHAR}{JOB}", new MsgParameter("CHAR", baseExp), new MsgParameter("JOB", classExp));

		//	character.Inventory.Remove(item, amount, InventoryItemRemoveMsg.Used);
		//}

		//character.PlayEffect("F_sys_expcard_normal");

		return DialogTxResult.Okay;
	}
}
