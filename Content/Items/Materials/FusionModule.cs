using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace XDContentMod.Content.Items.Materials
{
	public class FusionModule : ModItem
	{
		public override void SetDefaults() 
		{
        	int width = 32; int height = 32;
        	Item.Size = new Vector2(width, height);

        	Item.rare = ItemRarityID.Lime;
            Item.maxStack = 9999;
			Item.value = Item.buyPrice(gold: 5);
        }
    }
}

//KUPIĆ OD MERCHANTA
//INSPO: ZNALEŹĆ