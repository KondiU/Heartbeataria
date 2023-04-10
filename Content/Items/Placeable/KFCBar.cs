using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace XDContentMod.Content.Items.Placeable
{
	public class KFCBar : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 1;
		}

		public override void SetDefaults()
		{
			int width = 44; int height = 25;
			Item.Size = new Vector2(width, height);

			Item.maxStack = 99;
			Item.value = Item.buyPrice(silver: 50);

			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 10;
			Item.useAnimation = 15;

			Item.useTurn = true;
			Item.autoReuse = true;
			Item.consumable = true;

			Item.DefaultToPlaceableTile(ModContent.TileType<Content.Tiles.Furniture.KFCBarTile>());
		}
	}
}