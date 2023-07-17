using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.Localization;

namespace XDContentMod.Content.Tiles.Furniture
{
    public class TVTile : ModTile
    {
		public override void SetStaticDefaults()
		{
			Main.tileSolidTop[Type] = false;
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileTable[Type] = false;
			Main.tileLavaDeath[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
			TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };
			TileObjectData.addTile(Type);
			
			LocalizedText name = CreateMapEntryName();
            AddMapEntry(new Color(99, 99, 99), name);
			TileID.Sets.DisableSmartCursor[Type] = true;
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}
	}
}