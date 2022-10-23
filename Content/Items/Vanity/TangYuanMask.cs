using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Creative;

namespace XDContentMod.Content.Items.Vanity
{
	[AutoloadEquip(EquipType.Head)]
	public class TangYuanMask : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Tang Yuan Mask");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() 
		{
			int width = 38; int height = 34;
			Item.Size = new Vector2(width, height);

			Item.value = Item.buyPrice(silver: 450);
			Item.vanity = true;
		}
	}
}