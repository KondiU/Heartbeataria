using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace XDContentMod.Content.Items.Vanity
{
	[AutoloadEquip(EquipType.Legs)]

	public class HeartbeatOrangeShoes : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Heartbeat Orange Shoes");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() 
		{
			int width = 30; int height = 18;
			Item.Size = new Vector2(width, height);

			Item.value = Item.buyPrice(gold: 3);
			Item.vanity = true;
		}
	}
}