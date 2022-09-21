using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace XDContentMod.Content.Items.Pets
{
	public class LittlePuff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Little Puff Powerbank");
			Tooltip.SetDefault("Summons a Little Puff to charge your phone");
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
			Item.value = 20000;
			Item.UseSound = SoundID.Item2;


			Item.shoot = ModContent.ProjectileType<Content.Projectiles.Friendly.Pets.LittlePuffProjectile>();
			Item.buffType = ModContent.BuffType<Content.Buffs.LittlePuffBuff>();
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