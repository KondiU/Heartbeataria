using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.ID;
using Terraria.ModLoader;

namespace XDContentMod.Common {
    internal class HeartbeatariaCorruptionMenu : ModMenu {
        public override string DisplayName => "Heartbeataria (Corruption)";

        public override Asset<Texture2D> Logo => ModContent.Request<Texture2D>("XDContentMod/Assets/Textures/LogoCorruption");

        public override bool PreDrawLogo (SpriteBatch spriteBatch, ref Vector2 logoDrawCenter, ref float logoRotation, ref float logoScale, ref Color drawColor) {
            logoDrawCenter += new Vector2(0, 14);
            logoScale *= 1f;
            return true;
        }
    }
}