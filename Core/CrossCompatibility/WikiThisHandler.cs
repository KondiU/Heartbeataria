using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace XDContentMod.Core.CrossCompatibility
{
    public class WikiThisHandler : ModSystem
    {
        public const string WikiLink = "https://terrariamods.wiki.gg/wiki/Heartbeataria/{}";

        public override void PostSetupContent()
        {
            if (!ModLoader.TryGetMod("Wikithis", out Mod wikithis) || Main.netMode == NetmodeID.Server)
                return;

            wikithis.Call("AddModURL", Mod, WikiLink);

            wikithis.Call("AddWikiTexture", Mod, ModContent.Request<Texture2D>("XDContentMod/icon_small", AssetRequestMode.ImmediateLoad));
        }
    }
}
