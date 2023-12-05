using Microsoft.Xna.Framework;
using Terraria.GameContent.UI;
using Terraria.ModLoader;

namespace XDContentMod.Content.EmoteBubbles
{
	public class StarMerchantEmote : ModEmoteBubble
	{
		public override void SetStaticDefaults() {
			AddToCategory(EmoteID.Category.Town);
		}
	}
}