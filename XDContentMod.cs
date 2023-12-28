using Terraria;
using Terraria.ModLoader;

namespace XDContentMod
{
	public class XDContentMod : Mod
	{
        public override void PostSetupContent()
        {
            if (ModLoader.TryGetMod("ShopLookup", out Mod slu))
            {
                slu.Call("NonPermanent", ModContent.NPCType<Content.NPCs.StarMerchantNPC>(), Condition.TimeDay);
            }
            base.PostSetupContent();
        }
    }
}