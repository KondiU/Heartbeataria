using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace XDContentMod.Content.Items.Weapons.Summon
{
	public class Stargazer : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Stargazer");
			Tooltip.SetDefault("May the power of stardust be with you\nCURRENTLY NOT WORKING PROPERLY");
		}

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.MoonlordTurretStaff);
//			Item.shoot = ModContent.ProjectileType<Content.Projectiles.Friendly.StargazerProjectile>();

		}
	}
}