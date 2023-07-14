//--- Melia Script ----------------------------------------------------------
// Dialog Transaction Scripts
//--- Description -----------------------------------------------------------
// Handles "Dialog TX" requests from the client.
//---------------------------------------------------------------------------

using System;
using Melia.Shared.Tos.Const;
using Melia.Zone;
using Melia.Zone.Network;
using Melia.Zone.Scripting;
using Melia.Zone.World.Actors.Characters;

public class DialogTxFunctionsScript : GeneralScript
{
	[ScriptableFunction("SCR_ITEM_MANUFACTURE_RECIPE")]
	public DialogTxResult SCR_ITEM_MANUFACTURE_RECIPE(Character character, DialogTxArgs args)
	{
		if (!character.IsSitting)
			return DialogTxResult.Fail;

		if (args.NumArgs.Length < 2)
			return DialogTxResult.Fail;

		var recipeId = args.NumArgs[0];
		var craftAmount = args.NumArgs[1];

		if (!ZoneServer.Instance.Data.RecipeDb.TryFind(recipeId, out var recipe))
		{
			character.AddonMessage(AddonMessage.JOURNAL_DETAIL_CRAFT_EXEC_FAIL, "", 0);
			return DialogTxResult.Fail;
		}

		character.AddonMessage(AddonMessage.JOURNAL_DETAIL_CRAFT_EXEC_START, recipe.ClassName);

		var timeConsumed = 8;
		var type = "CRAFT";

		Send.ZC_NORMAL.TimeAction(character, "!@#$ItemCraftProcess#@!", type, timeConsumed, true);

		character.TimedEvents.Add(TimeSpan.FromSeconds(timeConsumed), TimeSpan.Zero, 0, "timeaction", caller =>
		{
			Send.ZC_NORMAL.TimeActionState(caller, true);

			for (var i = 0; i < craftAmount; i++)
			{
				foreach (var txItem in args.TxItems)
				{
					var item = txItem.Item;
					var amount = txItem.Amount;

					if (!recipe.Ingredients.ContainsKey(item.Data.ClassName) || amount < recipe.Ingredients[item.Data.ClassName])
					{
						character.AddonMessage(AddonMessage.JOURNAL_DETAIL_CRAFT_EXEC_FAIL, recipe.ClassName);
						return;
					}
				}
			}

			for (var i = 0; i < craftAmount; i++)
			{
				foreach (var txItem in args.TxItems)
				{
					character.Inventory.Remove(txItem.Item.ObjectId, txItem.Amount, InventoryItemRemoveMsg.Given);
				}
			}

			character.AddItem(recipe.ProductClassName, recipe.ProductAmount * craftAmount);

			character.AddonMessage(AddonMessage.JOURNAL_DETAIL_CRAFT_EXEC_SUCCESS, recipe.ClassName, craftAmount);
			Send.ZC_NORMAL.TimeActionState(caller, false);
		}, caller =>
		{
			character.AddonMessage(AddonMessage.JOURNAL_DETAIL_CRAFT_EXEC_FAIL, recipe.ClassName, 0);
			Send.ZC_NORMAL.TimeActionState(caller, false);			
		});

		return DialogTxResult.Okay;
	}
}
