using XDContentMod.Content.Items.Placeable;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace XDContentMod.Content.Tiles.Paintings
{
	public class DaiDaiSelfieTile : ModTile
	{
		public override void SetStaticDefaults()
		{
            Main.tileFrameImportant[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileID.Sets.FramesOnKillWall[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
            TileObjectData.newTile.Width = 3;
            TileObjectData.newTile.Height = 3;
            TileObjectData.newTile.StyleWrapLimit = 111;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };
            TileObjectData.newTile.StyleHorizontal = true;
            DustType = -1;

            TileObjectData.addTile(Type);
            AddMapEntry(new Color(99, 50, 30), Language.GetText("MapObject.Painting"));
        }

  		public override void NumDust(int i, int j, bool fail, ref int num) 
		{
            num = 0;
		}
	}
}