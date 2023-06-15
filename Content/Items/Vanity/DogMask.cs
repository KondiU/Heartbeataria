using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace XDContentMod.Content.Items.Vanity
{
	[AutoloadEquip(EquipType.Head)]
	
	public class DogMask : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Item.ResearchUnlockCount = 1;
		}

		public override void SetDefaults() 
		{
			int width = 38; int height = 34;
			Item.Size = new Vector2(width, height);

			Item.value = Item.buyPrice(silver: 300);
			Item.vanity = true;
		}
	}
}