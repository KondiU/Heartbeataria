using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace XDContentMod.Content.Items.Weapons.Melee
{
	public class KFCChickenDrumstick : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 15;
			Item.DamageType = DamageClass.Melee;
			int width = 24; int height = 28;
			Item.Size = new Vector2(width, height);
			Item.useTime = 19;
			Item.useAnimation = 19;
			Item.useStyle = 1;
			Item.knockBack = 5;
			Item.value = Item.buyPrice(silver: 135);
			Item.rare = ItemRarityID.White;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}
	}
}