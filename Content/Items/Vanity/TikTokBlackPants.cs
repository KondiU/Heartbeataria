using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace XDContentMod.Content.Items.Vanity
{
	[AutoloadEquip(EquipType.Legs)]

	public class TikTokBlackPants : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("TikTok Black Pants");
			Tooltip.SetDefault("Comfy pants of a true Gen-Z!");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

//		private void SetupDrawing(){
//		if (Main.netMode == NetmodeID.Server)
//			return;
//		
//		int equipSlotLegs = EquipLoader.GetEquipSlot(Mod, Name, EquipType.Legs);
//
//		ArmorIDs.Legs.Sets.HidesBottomSkin[equipSlotLegs] = true;
//		ArmorIDs.Legs.Sets.HidesBottomSkin[equipSlotLegsAlt] = true;	
//		}

		public override void SetDefaults() 
		{
			int width = 30; int height = 18;
			Item.Size = new Vector2(width, height);

			Item.value = Item.buyPrice(silver: 100);
			Item.vanity = true;
		}
	}
}