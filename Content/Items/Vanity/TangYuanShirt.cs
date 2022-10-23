using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace XDContentMod.Content.Items.Vanity
{
	[AutoloadEquip(EquipType.Body)]

	public class TangYuanShirt : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Tang Yuan Shirt");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

			int equipSlotBody = EquipLoader.GetEquipSlot(Mod, Name, EquipType.Body);
			int equipSlotBodyAlt = EquipLoader.GetEquipSlot(Mod, "TangYuanShirt", EquipType.Body);

			ArmorIDs.Body.Sets.HidesArms[equipSlotBody] = true;
			ArmorIDs.Body.Sets.HidesArms[equipSlotBodyAlt] = true;
		}

		public override void SetDefaults() 
		{
			int width = 30; int height = 18;
			Item.Size = new Vector2(width, height);

			Item.value = Item.buyPrice(silver: 450);
			Item.vanity = true;
		}
	}
}