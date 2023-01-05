using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
namespace XDContentMod.Content.Items.Placeable
{
	public class ColorfulBalloonsStockPhoto : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Colorful Balloons Stock Photo");
//			Tooltip.SetDefault("Open the first page of TapTap's 6th Birthday album, and you'll see some colorful balloons!");
		}

		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 50;
			Item.rare = ItemRarityID.White;
			Item.value = Item.buyPrice(silver: 100);

			Item.maxStack = 99;

			Item.useStyle = 1;
			Item.useTime = 10;
			Item.useAnimation = 15;

			Item.useTurn = true;
			Item.autoReuse = true;
			Item.consumable = true;

			Item.createTile = ModContent.TileType<Content.Tiles.Paintings.ColorfulBalloonsStockPhoto_Painting>();
		}

	}
}