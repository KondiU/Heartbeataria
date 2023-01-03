using Terraria.ID;
using Terraria.ModLoader;
namespace XDContentMod.Content.Items.Placeable
{
	public class SeiyuuchanSupportPoster : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Seiyuu-chan Support Poster");
//			Tooltip.SetDefault("LOOK直播看板娘\百变/\声优酱/\耶耶耶/");
		}

		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 50;
			Item.rare = ItemRarityID.White;

			Item.maxStack = 99;

			Item.useStyle = 1;
			Item.useTime = 10;
			Item.useAnimation = 15;

			Item.useTurn = true;
			Item.autoReuse = true;
			Item.consumable = true;

			Item.createTile = ModContent.TileType<Content.Tiles.Paintings.SeiyuuchanSupportPoster_Painting>();
		}

	}
}