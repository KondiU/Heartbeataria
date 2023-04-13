using XDContentMod.Content.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace XDContentMod.Content.Items.Accessories
{
	public class OtherworldCore : ModItem
	{
		public override void SetDefaults() 
		{
			int width = 32; int height = 32;
            Item.Size = new Vector2(width, height);
			
			Item.accessory = true;
			Item.rare = ItemRarityID.LightRed;
			Item.value = Item.buyPrice(silver: 750);
		}

		public override void AddRecipes() 
		{
        CreateRecipe()
            .AddIngredient<FilthySap>()
			.AddIngredient<GreenScales>()
			.AddIngredient<DreadFangs>()
			.AddIngredient<MagmaShell>()
			.AddIngredient<FusionModule>()
            .AddTile(TileID.Hellforge)
            .Register();
        }
    }
}

//		public override void UpdateAccessory(Player player, bool hideVisual) 
//		{
//			// Set the HasExampleImmunityAcc bool to true to ensure we have this accessory
//			// And apply the changes in ModPlayer.PostHurt correctly
//			player.GetModPlayer<ExampleImmunityPlayer>().HasExampleImmunityAcc = true;
//		}

//CRAFTING
//INSPO: ZNALEŹĆ