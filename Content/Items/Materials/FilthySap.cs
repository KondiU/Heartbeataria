using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace XDContentMod.Content.Items.Materials
{
	public class FilthySap : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 5;
		}

		public override void SetDefaults() 
		{
            int width = 32; int height = 32;
           	Item.Size = new Vector2(width, height);

        	Item.rare = ItemRarityID.Blue;
            Item.maxStack = 9999;
			Item.value = Item.buyPrice(silver: 50);
        }
    }
}