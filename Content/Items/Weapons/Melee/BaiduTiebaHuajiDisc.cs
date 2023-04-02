using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace XDContentMod.Content.Items.Weapons.Melee
{
	public class BaiduTiebaHuajiDisc : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Baidu Tieba Huájí Disc");
			Tooltip.SetDefault("Remnant from the Baidu Tieba posting culture");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId [Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 10;
			Item.DamageType = DamageClass.Melee;
			Item.width = 24;
			Item.height = 24;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useStyle = 1;
			Item.knockBack = 8;
			Item.value = Item.buyPrice(gold: 15);
			Item.rare = 5;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<Content.Projectiles.Friendly.BaiduTiebaHuajiDiscProjectile>();
			Item.shootSpeed = 13;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.maxStack = 5;
		}
	}
}