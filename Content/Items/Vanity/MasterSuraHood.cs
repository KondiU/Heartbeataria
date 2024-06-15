using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace XDContentMod.Content.Items.Vanity
{
	[AutoloadEquip(EquipType.Head)]
	
	public class MasterSuraHood : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Item.ResearchUnlockCount = 1;
		}

		public override void SetDefaults() 
		{
			int width = 18; int height = 18;
			Item.Size = new Vector2(width, height);

			Item.rare = ItemRarityID.Pink;
			Item.value = Item.buyPrice(gold: 3);
			Item.vanity = true;
		}
	}
}
// WIP SPRITES - FIX IN THE FUTURE