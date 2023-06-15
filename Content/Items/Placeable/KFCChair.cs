using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace XDContentMod.Content.Items.Placeable
{
	public class KFCChair : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 1;
		}

		public override void SetDefaults()
		{
			int width = 64; int height = 34;
			Item.Size = new Vector2(width, height);

			Item.maxStack = 99;
			Item.value = Item.buyPrice(silver: 50);

			Item.useStyle = 1;
			Item.useTime = 10;
			Item.useAnimation = 15;

			Item.useTurn = true;
			Item.autoReuse = true;
			Item.consumable = true;

			Item.DefaultToPlaceableTile(ModContent.TileType<Content.Tiles.Furniture.KFCChairTile>());
		}
	}
}