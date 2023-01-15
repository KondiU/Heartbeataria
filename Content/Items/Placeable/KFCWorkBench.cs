using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace XDContentMod.Content.Items.Placeable
{
	public class KFCWorkBench : ModItem
	{
		public override void SetStaticDefaults() => DisplayName.SetDefault("KFC Work Bench");

		public override void SetDefaults()
		{
			Item.width = 44;
			Item.height = 25;
			Item.value = 150;
			Item.maxStack = 99;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 10;
			Item.useAnimation = 15;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.consumable = true;
			Item.createTile = ModContent.TileType<Content.Tiles.Furniture.KFCWorkBenchTile>();
		}
	}
}