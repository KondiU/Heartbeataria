using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace XDContentMod.Content.Items.Mounts 
{
	public class DiDiBikeKeys : ModItem 
	{
		public override void SetStaticDefaults () 
		{
			Item.ResearchUnlockCount = 1;
		}

		public override void SetDefaults()
		{
			int width = 24; int height = 24;
            Item.Size = new Vector2(width, height);
			Item.value = Item.buyPrice(gold: 30);
			Item.rare = 8;
			Item.useAnimation = 15;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.noMelee = true;
			Item.mountType = ModContent.MountType<Content.Mounts.DiDiBike>();
			Item.UseSound = SoundID.Item25;
		}
	}
}