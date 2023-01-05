using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
namespace XDContentMod.Content.Items.Placeable
{
	public class PururuPortrait : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pururu Portrait");
			Tooltip.SetDefault("BU BU DO DI DU DONG DA!");
		}

		public override void SetDefaults()
		{
			Item.width = 28;
			Item.height = 28;
			Item.rare = ItemRarityID.White;
			Item.value = Item.buyPrice(silver: 100);

			Item.maxStack = 99;

			Item.useStyle = 1;
			Item.useTime = 10;
			Item.useAnimation = 15;

			Item.useTurn = true;
			Item.autoReuse = true;
			Item.consumable = true;

			Item.createTile = ModContent.TileType<Content.Tiles.Paintings.PururuPortrait_Painting>();
		}

	}
}