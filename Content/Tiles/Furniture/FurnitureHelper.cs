using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.ObjectInteractions;

namespace XDContentMod.Content.Tiles.Furniture
{
	public static class FurnitureHelper
	{
		public static bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings) => settings.player.IsWithinSnappngRangeToTile(i, j, PlayerSittingHelper.ChairSittingMaxDistance); // Avoid being able to trigger it from long range

		public static void ModifySittingTargetInfo(int i, int j, ref TileRestingInfo info, int nextStyleHeight = 40)
		{
			Tile tile = Framing.GetTileSafely(i, j);
			info.TargetDirection = -1;
			if (tile.TileFrameX != 0)
				info.TargetDirection = 1;

			info.AnchorTilePosition.X = i;
			info.AnchorTilePosition.Y = j;

			if (tile.TileFrameY % nextStyleHeight == 0)
				info.AnchorTilePosition.Y++;
		}

		public static bool RightClick(int i, int j)
		{
			Player player = Main.LocalPlayer;

			if (player.IsWithinSnappngRangeToTile(i, j, PlayerSittingHelper.ChairSittingMaxDistance))
			{
				player.GamepadEnableGrappleCooldown();
				player.sitting.SitDown(player, i, j);
			}

			return true;
		}

		public static void MouseOver(int i, int j, int itemType)
		{
			Player player = Main.LocalPlayer;

			if (!player.IsWithinSnappngRangeToTile(i, j, PlayerSittingHelper.ChairSittingMaxDistance))
				return;

			player.noThrow = 2;
			player.cursorItemIconEnabled = true;
			player.cursorItemIconID = itemType;

			if (Main.tile[i, j].TileFrameX / 18 < 1)
				player.cursorItemIconReversed = true;
		}
	}
}