using Terraria.ID;
using Terraria.ModLoader;
namespace XDContentMod.Content.Items.Placeable
{
	public class KFCFamilyBucketAd : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("KFC Family Bucket Ad");
			Tooltip.SetDefault("It's for the entire family to crunch!");
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

			Item.createTile = ModContent.TileType<Content.Tiles.Paintings.KFCFamilyBucketAd_Painting>();
		}

	}
}