using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace XDContentMod.Content.Items.Placeable
{
	public class MimiChest : ModItem
	{
		public override void SetDefaults() {
			Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Furniture.MimiChestTile>());
			Item.width = 26;
			Item.height = 22;
			Item.value = Item.buyPrice(silver: 5);
		}
	}
}