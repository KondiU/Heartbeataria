using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace XDContentMod.Content.Items.Mounts 
{
	public class DiDiCarKeys : ModItem 
	{
		public override void SetStaticDefaults () 
		{
			DisplayName.SetDefault("DiDi Car Keys");
			Tooltip.SetDefault("Summons a rideable DiDi Car mount");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId [Type] = 1;
		}


		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 24;
			Item.value = Item.buyPrice(gold: 30);
			Item.rare = 8;
			Item.useAnimation = 15;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.noMelee = true;
			Item.mountType = ModContent.MountType<Content.Mounts.DiDiCar>();
			Item.UseSound = SoundID.Item25;
		}
	}
}