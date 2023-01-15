using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace XDContentMod.Content.Items.Pets
{
	public class Leaf : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Leaf");
			Tooltip.SetDefault("What's underneath it?");
		}

		public override void SetDefaults() 
		{
			//Item.CloneDefaults(ItemID.AmberMosquito);
			Item.useStyle = 1;
			Item.useAnimation = 20;
			Item.useTime = 20;
			Item.width = 24;
			Item.height = 26;
			Item.useTime = 2;
			Item.damage = 0;
			Item.stack = 1;
			Item.noMelee = true;
			Item.rare = 3;
			Item.value = Item.buyPrice(gold: 10);
			Item.UseSound = SoundID.Item2;


			Item.shoot = ModContent.ProjectileType<Content.Projectiles.Friendly.Pets.GreenFrogProjectile>();
			Item.buffType = ModContent.BuffType<Content.Buffs.GreenFrogBuff>();
		}

		public override void UseStyle(Player player, Rectangle heldItemFrame) 
		{
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0) 
			{
				player.AddBuff(Item.buffType, 3600);
			}
		}

		public override void AddRecipes()
		{

		}
	}
}