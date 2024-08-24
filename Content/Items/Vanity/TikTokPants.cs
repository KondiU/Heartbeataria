using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace XDContentMod.Content.Items.Vanity
{
	[AutoloadEquip(EquipType.Legs)]

	public class TikTokPants : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Item.ResearchUnlockCount = 1;

			int equipSlotLegs = EquipLoader.GetEquipSlot(Mod, Name, EquipType.Body);
			int equipSlotLegsAlt = EquipLoader.GetEquipSlot(Mod, "TikTokPants", EquipType.Legs);

			ArmorIDs.Legs.Sets.HidesBottomSkin[equipSlotLegsAlt] = true;
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