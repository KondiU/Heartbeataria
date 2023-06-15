using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace XDContentMod.Content.Items.Placeable
{
	public class TV : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 1;
		}

		public override void SetDefaults()
		{
			int width = 44; int height = 25;
			Item.Size = new Vector2(width, height);
			Item.rare = ItemRarityID.White;
			Item.value = Item.buyPrice(silver: 100);

			Item.maxStack = 99;

			Item.useStyle = 1;
			Item.useTime = 10;
			Item.useAnimation = 15;

			Item.useTurn = true;
			Item.autoReuse = true;
			Item.consumable = true;

			Item.DefaultToPlaceableTile(ModContent.TileType<Content.Tiles.Furniture.TVTile>());
		}
		public override void AddRecipes() 
		{
			CreateRecipe()
				.AddRecipeGroup(RecipeGroupID.Wood, 12)
				.AddIngredient(ItemID.Glass, 10)
				.AddIngredient(ItemID.Wire, 10)
				.AddTile(TileID.Sawmill)
				.Register();
		}
	}
}