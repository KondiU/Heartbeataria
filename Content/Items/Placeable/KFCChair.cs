using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace XDContentMod.Content.Items.Placeable
{
	public class KFCChair : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("KFC Chair");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId [Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 64;
			Item.height = 34;

			Item.maxStack = 99;
			Item.value = Item.buyPrice(silver: 250);

			Item.useStyle = 1;
			Item.useTime = 10;
			Item.useAnimation = 15;

			Item.useTurn = true;
			Item.autoReuse = true;
			Item.consumable = true;

			Item.createTile = ModContent.TileType<Content.Tiles.Furniture.KFCChairTile>();
		}
	}
}