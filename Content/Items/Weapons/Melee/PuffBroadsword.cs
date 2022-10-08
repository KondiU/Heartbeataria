using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace XDContentMod.Content.Items.Weapons.Melee
{
	public class PuffBroadsword : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Puff Broadsword");
			Tooltip.SetDefault("Fight for tala-la-la-la - pooh-lah-lah!");
		}

		public override void SetDefaults()
		{
			Item.damage = 16;
			Item.DamageType = DamageClass.Melee;
			Item.width = 24;
			Item.height = 28;
			Item.useTime = 17;
			Item.useAnimation = 19;
			Item.useStyle = 1;
			Item.knockBack = 6.5;
			Item.value = Item.buyPrice(silver: 135);
			Item.rare = 0;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = false;
		}

		public override void AddRecipes()
		{

		}
	}
}