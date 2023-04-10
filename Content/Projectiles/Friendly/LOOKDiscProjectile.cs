using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace XDContentMod.Content.Projectiles.Friendly
{
	public class LOOKDiscProjectile : ModProjectile
	{
		public override void SetDefaults()
		{	
			Projectile.width = 32;
			Projectile.height = 32;
			Projectile.aiStyle = 3;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.maxPenetrate = -1;
		}
	}
}