using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace XDContentMod.Content.Items.Vanity
{
	[AutoloadEquip(EquipType.Body)]

	public class TikTokBlackTorso : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("TikTok Black Torso");
			Tooltip.SetDefault("Armor of a true Gen-Z!");
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