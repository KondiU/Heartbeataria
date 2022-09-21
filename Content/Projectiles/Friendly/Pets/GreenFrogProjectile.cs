using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace XDContentMod.Content.Projectiles.Friendly.Pets
{
	public class GreenFrogProjectile : ModProjectile
	{
		public override void SetStaticDefaults() {
			Main.projFrames[Projectile.type] = 15;
			Main.projPet[Projectile.type] = true;
		}

		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.SugarGlider); // Copy the stats of the Zephyr Fish
			Projectile.width = 46;
			Projectile.height = 44;
			Projectile.friendly = true;
			Projectile.maxPenetrate = -1;
			Projectile.timeLeft = 18000;
			Projectile.netImportant = true;

			AIType = ProjectileID.SugarGlider; // Copy the AI of the Zephyr Fish.
		}

		public override bool PreAI() {
			Player player = Main.player[Projectile.owner];

			//player.glider = false; // Relic from aiType

			return true;
		}

		public override void AI() {
			Player player = Main.player[Projectile.owner];

			// Keep the projectile from disappearing as long as the player isn't dead and has the pet buff.
			if (!player.dead && player.HasBuff(ModContent.BuffType<Content.Buffs.GreenFrogBuff>())) {
				Projectile.timeLeft = 2;
			}
		}
	}
}