using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace XDContentMod.Content.Items.Placeable
{
	public class RockPotato : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 1;
		}

		public override void SetDefaults()
		{
			int width = 28; int height = 28;
			Item.Size = new Vector2(width, height);
			Item.rare = ItemRarityID.White;
			Item.value = Item.buyPrice(silver: 50);

			Item.maxStack = 99;

			Item.useStyle = 1;
			Item.useTime = 10;
			Item.useAnimation = 15;

			Item.useTurn = true;
			Item.autoReuse = true;
			Item.consumable = true;

			Item.DefaultToPlaceableTile(ModContent.TileType<Content.Tiles.Paintings.RockPotatoTile>());
		}

	}
}