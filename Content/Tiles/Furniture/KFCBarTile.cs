using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.Localization;

namespace XDContentMod.Content.Tiles.Furniture
{
	public class KFCBarTile : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileSolidTop[Type] = true;
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileTable[Type] = true;
			Main.tileLavaDeath[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
			TileObjectData.newTile.CoordinateHeights = new int[] { 16, 18 };
			TileObjectData.addTile(Type);

            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
			AddMapEntry(new Color(191, 142, 111), Language.GetText("MapObject.Table"));
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}
	}
}