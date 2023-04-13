using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace XDContentMod.Content.Items.Weapons.Melee
{
	public class TapTapBroadsword : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 16;
			Item.DamageType = DamageClass.Melee;
			Item.width = 24;
			Item.height = 28;
			Item.useTime = 17;
			Item.useAnimation = 17;
			Item.useStyle = 1;
			Item.knockBack = 6.5f;
			Item.value = Item.buyPrice(silver: 135);
			Item.rare = 0;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = false;
		}
	}
}