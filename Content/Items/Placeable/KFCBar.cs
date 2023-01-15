using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace XDContentMod.Content.Items.Placeable
{
	public class KFCBar : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("KFC Bar");
		}

		public override void SetDefaults()
		{
			Item.width = 44;
			Item.height = 25;

			Item.maxStack = 99;
			Item.value = Item.buyPrice(silver: 100);

			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 10;
			Item.useAnimation = 15;

			Item.useTurn = true;
			Item.autoReuse = true;
			Item.consumable = true;

			Item.createTile = ModContent.TileType<Content.Tiles.Furniture.KFCBarTile>();
		}
	}
}