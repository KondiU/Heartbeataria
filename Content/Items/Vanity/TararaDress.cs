using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace XDContentMod.Content.Items.Vanity
{
	[AutoloadEquip(EquipType.Body)]

	public class TararaDress : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Tarara Dress");
			Tooltip.SetDefault("Tarara's favourite unisex dress!");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() 
		{
			int width = 30; int height = 18;
			Item.Size = new Vector2(width, height);

			Item.value = Item.buyPrice(silver: 100);
			Item.vanity = true;
		}
	}
}