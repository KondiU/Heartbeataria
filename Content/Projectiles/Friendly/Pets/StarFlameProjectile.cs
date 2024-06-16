using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace XDContentMod.Content.Projectiles.Friendly.Pets 
{
    public class StarFlameProjectile : ConsolariaFlyingPet 
    {
        public override int maxFrames => 15;
        public override int PreviewOffsetX => -16;
		public override int PreviewOffsetY => -12;
		public override int PreviewSpriteDirection => -1;
        public override bool isLightPet => false;

/*        public override void SetStaticDefaults () 
		{
            ProjectileID.Sets.CharacterPreviewAnimations[Projectile.type] = ProjectileID.Sets.SimpleLoop(0, 15)
                .WhenNotSelected(0, 0)
				.WithOffset(0, -10)
				.WithSpriteDirection(-1);

            base.SetStaticDefaults();
        }
*/
        public override void SetDefaults () 
        {
            int width = 48; int height = 48;
            Projectile.Size = new Vector2(width, height);

            base.SetDefaults();
        }

        public override void AI () {
            Player player = Main.player [Projectile.owner];
            if (!player.dead && player.HasBuff(ModContent.BuffType<Buffs.StarFlameBuff>()))
                Projectile.timeLeft = 2;

            FloatingAI(tilt: 0.025f);
            int frameTime = 1;
            Animation(frameTime);
        }
    }
}