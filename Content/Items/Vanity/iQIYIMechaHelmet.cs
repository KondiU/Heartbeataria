using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Creative;

namespace XDContentMod.Content.Items.Vanity
{
	[AutoloadEquip(EquipType.Head)]
	public class iQIYIMechaHelmet : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("iQIYI Mecha Helmet");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() 
		{
			int width = 38; int height = 34;
			Item.Size = new Vector2(width, height);

			Item.value = Item.buyPrice(gold: 3);
			Item.vanity = true;
		}
	}
}