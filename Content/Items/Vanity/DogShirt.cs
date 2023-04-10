using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace XDContentMod.Content.Items.Vanity
{
	[AutoloadEquip(EquipType.Body)]

	public class DogShirt : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Item.ResearchUnlockCount = 1;

			int equipSlotBody = EquipLoader.GetEquipSlot(Mod, Name, EquipType.Body);
			int equipSlotBodyAlt = EquipLoader.GetEquipSlot(Mod, "DogShirt", EquipType.Body);

			ArmorIDs.Body.Sets.HidesArms[equipSlotBody] = true;
			ArmorIDs.Body.Sets.HidesArms[equipSlotBodyAlt] = true;
		}

		public override void SetDefaults() 
		{
			int width = 30; int height = 18;
			Item.Size = new Vector2(width, height);

			Item.value = Item.buyPrice(silver: 300);
			Item.vanity = true;
		}
	}
}