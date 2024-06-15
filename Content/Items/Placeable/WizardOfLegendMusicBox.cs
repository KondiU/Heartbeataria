using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace XDContentMod.Content.Items.Placeable {
	public class WizardOfLegendMusicBox : ModItem {
		public override void SetStaticDefaults () {
			Item.ResearchUnlockCount = 1;
			MusicLoader.AddMusicBox(Mod, MusicLoader.GetMusicSlot(Mod, "Assets/Music/WizardOfLegend"), ModContent.ItemType<WizardOfLegendMusicBox>(), ModContent.TileType<Tiles.WizardOfLegendMusicBoxTile>());
			ItemID.Sets.ShimmerTransformToItem[Type] = ItemID.MusicBox;
            ItemID.Sets.CanGetPrefixes [Type] = false;
        }

		public override void SetDefaults () {
            Item.DefaultToMusicBox(ModContent.TileType<Tiles.WizardOfLegendMusicBoxTile>(), 0);
            Item.maxStack = 1;
			Item.rare = ItemRarityID.LightRed;
			Item.value = Item.buyPrice(gold: 10);
        }
	}
}