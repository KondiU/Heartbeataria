using XDContentMod.Content.Tiles.Furniture;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace XDContentMod.Content.Items.Placeable
{
	public class MusicBoxWizardOfLegend : ModItem
	{
		public override void SetStaticDefaults() {
			ItemID.Sets.CanGetPrefixes[Type] = false;
			ItemID.Sets.ShimmerTransformToItem[Type] = ItemID.MusicBox;
			MusicLoader.AddMusicBox(Mod, MusicLoader.GetMusicSlot(Mod, "Assets/Music/WizardOfLegend"), ModContent.ItemType<MusicBoxWizardOfLegend>(), ModContent.TileType<MusicBoxWizardOfLegendTile>());
		}

		public override void SetDefaults() {
			Item.DefaultToMusicBox(ModContent.TileType<MusicBoxWizardOfLegendTile>(), 0);
			Item.value = Item.buyPrice(gold: 2);
		}
	}
}