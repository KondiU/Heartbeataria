using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
namespace XDContentMod.Content.Items.Placeable
{
	public class KFCBurgerAd : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("KFC Burger Ad");
			Tooltip.SetDefault("Anything But Ordinary!");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId [Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 30;
			Item.rare = ItemRarityID.White;
			Item.value = Item.buyPrice(silver: 250);

			Item.maxStack = 99;

			Item.useStyle = 1;
			Item.useTime = 10;
			Item.useAnimation = 15;

			Item.useTurn = true;
			Item.autoReuse = true;
			Item.consumable = true;

			Item.createTile = ModContent.TileType<Content.Tiles.Paintings.KFCBurgerAdTile>();
		}

	}
}