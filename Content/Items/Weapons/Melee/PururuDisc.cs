using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace XDContentMod.Content.Items.Weapons.Melee
{
	public class PururuDisc : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 10;
			Item.DamageType = DamageClass.Melee;
			int width = 24; int height = 24;
			Item.Size = new Vector2(width, height);
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useStyle = 1;
			Item.knockBack = 8;
			Item.value = Item.buyPrice(gold: 15);
			Item.rare = ItemRarityID.Pink;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<Content.Projectiles.Friendly.PururuDiscProjectile>();
			Item.shootSpeed = 13;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.maxStack = 5;
		}
	}
}