using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace XDContentMod.Content.Items.Accessories
{
	[AutoloadEquip(EquipType.Back, EquipType.Front)]

	public class MasterSuraCloak : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Item.ResearchUnlockCount = 1;
		}

		public override void SetDefaults() 
		{
			int width = 20; int height = 24;
			Item.Size = new Vector2(width, height);

			Item.rare = ItemRarityID.Pink;
			Item.value = Item.buyPrice(gold: 5);
			Item.vanity = true;
		}
	}
}
//WiP SPRITES