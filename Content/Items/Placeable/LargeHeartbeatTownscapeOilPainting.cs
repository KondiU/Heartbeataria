using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
namespace XDContentMod.Content.Items.Placeable
{
	public class LargeHeartbeatTownscapeOilPainting : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Large Heartbeat Townscape Oil Painting");
//			Tooltip.SetDefault("A view of Heartbeat Town Center buildings.");
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

			Item.createTile = ModContent.TileType<Content.Tiles.Paintings.LargeHeartbeatTownscapeOilPainting_Painting>();
		}

	}
}