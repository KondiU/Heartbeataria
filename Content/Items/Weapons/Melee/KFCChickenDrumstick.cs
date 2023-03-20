using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace XDContentMod.Content.Items.Weapons.Melee
{
	public class KFCChickenDrumstick : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("KFC Chicken Drumstick");
			Tooltip.SetDefault("It's Finger Lickin' Good!");
		}

		public override void SetDefaults()
		{
			Item.damage = 15;
			Item.DamageType = DamageClass.Melee;
			Item.width = 24;
			Item.height = 28;
			Item.useTime = 19;
			Item.useAnimation = 19;
			Item.useStyle = 1;
			Item.knockBack = 5;
			Item.value = Item.buyPrice(silver: 135);
			Item.rare = 0;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}
	}
}