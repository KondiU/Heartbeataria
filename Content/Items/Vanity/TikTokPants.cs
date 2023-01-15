using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace XDContentMod.Content.Items.Vanity
{
	[AutoloadEquip(EquipType.Legs)]

	public class TikTokPants : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("TikTok Pants");
//			Tooltip.SetDefault("");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

			int equipSlotLegs = EquipLoader.GetEquipSlot(Mod, Name, EquipType.Body);
			int equipSlotLegsAlt = EquipLoader.GetEquipSlot(Mod, "TikTokPants", EquipType.Legs);

			ArmorIDs.Legs.Sets.HidesBottomSkin[equipSlotLegsAlt] = true;
			ArmorIDs.Legs.Sets.HidesBottomSkin[equipSlotLegsAlt] = true;
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