using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using Yggdrasil.Data.JSON;

namespace Melia.Shared.Data.Database
{
	[Serializable]
	public class RecipeData
	{
		public int Id { get; set; }
		public string ClassName { get; set; }
		public string ProductClassName { get; set; }
		public int ProductAmount { get; set; }
		public Dictionary<string, int> Ingredients { get; set; } = new Dictionary<string, int>();
	}

	/// <summary>
	/// Recipe database, indexed by their id.
	/// </summary>
	public class RecipeDb : DatabaseJsonIndexed<int, RecipeData>
	{
		/// <summary>
		/// Returns data for the first recipe with the given class name,
		/// or null if none were found.
		/// </summary>
		/// <param name="className"></param>
		/// <returns></returns>
		public RecipeData Find(string className)
		{
			return this.Entries.Values.FirstOrDefault(a => a.ClassName == className);
		}

		/// <summary>
		/// Returns true for the first recipe with the given class name,
		/// or false if none were found.
		/// </summary>
		/// <param name="className"></param>
		/// <returns></returns>
		public bool TryFind(string className, out RecipeData recipe)
		{
			recipe = this.Find(className);
			return recipe != null;
		}

		/// <summary>
		/// Reads given entry and adds it to the database.
		/// </summary>
		/// <param name="entry"></param>
		protected override void ReadEntry(JObject entry)
		{
			entry.AssertNotMissing("recipeId", "className", "productClassName", "productAmount", "ingredients");

			var data = new RecipeData();

			data.Id = entry.ReadInt("recipeId");
			data.ClassName = entry.ReadString("className");
			data.ProductClassName = entry.ReadString("productClassName");
			data.ProductAmount = entry.ReadInt("productAmount");

			var ingredientsEntry = (JArray)entry["ingredients"];
			foreach (JObject ingredientEntry in ingredientsEntry)
			{
				ingredientEntry.AssertNotMissing("className", "amount");

				var itemName = ingredientEntry.ReadString("className");
				var amount = ingredientEntry.ReadInt("amount");

				if (!data.Ingredients.ContainsKey(itemName))
					data.Ingredients.Add(itemName, amount);
			}

			this.AddOrReplace(data.Id, data);
		}
	}
}
