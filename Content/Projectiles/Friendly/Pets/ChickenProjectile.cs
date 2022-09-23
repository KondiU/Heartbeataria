using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace XDContentMod.Content.Projectiles.Friendly.Pets
{
	public class ChickenProjectile : ModProjectile
	{
		private int turnTimer;

		public override void SetStaticDefaults() {
			Main.projFrames[Projectile.type] = 15;
			Main.projPet[Projectile.type] = true;
		}

		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.SugarGlider); // Copy the stats of the Zephyr Fish
			//Projectile.width = 42;
			//Projectile.height = 42;
			Projectile.friendly = true;
			Projectile.maxPenetrate = -1;
			Projectile.timeLeft = 18000;
			Projectile.netImportant = true;

			AIType = ProjectileID.SugarGlider; // Copy the AI of the Zephyr Fish.


            int width = 42; int height = 42;
			Projectile.Size = new Vector2(width, height);
		}

		public override bool PreAI() {
			Player player = Main.player[Projectile.owner];

			//player.glider = false; // Relic from aiType

			return true;
		}

		public override void AI() {
			Player player = Main.player[Projectile.owner];
			if (!player.dead && player.HasBuff(ModContent.BuffType<Content.Buffs.ChickenBuff>())) {
				Projectile.timeLeft = 2;

            if (Projectile.velocity.Y != 0.4f) {
                if (Projectile.direction != player.direction) turnTimer++;
                if (turnTimer >= 45) {
                    Projectile.direction = player.direction;
                    turnTimer = 0;
					}
				}
			}
		}
			private int texFrameCounter;
        	private int texCurrentFrame;

			public override bool PreDraw (ref Color lightColor) {
        		Texture2D texture = (Texture2D) ModContent.Request<Texture2D>(Texture);
            	bool onGround = Projectile.velocity.Y == 0f;
            	texFrameCounter++;
            	if (texFrameCounter >= 10) {
                	texFrameCounter = 0;
                	texCurrentFrame++;
                	if (texCurrentFrame >= (onGround ? 11 : 14))
                    	texCurrentFrame = onGround ? 1 : 10;
            }
            if (onGround && Projectile.velocity.X == 0f) {
                texCurrentFrame = 0;
                texFrameCounter = 0;
            }
            Vector2 position = new Vector2(Projectile.Center.X, Projectile.Center.Y) - Main.screenPosition;
            Vector2 drawOrigin = new Vector2(texture.Width * 0.5f, Projectile.height * 0.5f);
            var spriteEffects = Projectile.direction > 0 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
            int frameHeight = texture.Height / Main.projFrames [Projectile.type];
            Rectangle frameRect = new Rectangle(0, texCurrentFrame * frameHeight, texture.Width, frameHeight);
            Main.EntitySpriteDraw(texture, position, frameRect, lightColor, Projectile.rotation, drawOrigin, Projectile.scale, spriteEffects, 0);
            return false;
        }
    }
}