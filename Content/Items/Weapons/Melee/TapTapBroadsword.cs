using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace XDContentMod.Content.Items.Weapons.Melee
{
	public class TapTapBroadsword : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("TapTap Broadsword");
			Tooltip.SetDefault("Fight for Tarara & Pururu!");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId [Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.PlatinumBroadsword);
			//Item.damage = 16;
			//Item.DamageType = DamageClass.Melee;
			//Item.width = 24;
			//Item.height = 28;
			//Item.useTime = 17;
			//Item.useAnimation = 19;
			//Item.useStyle = 1;
			//Item.knockBack = 6.5;
			//Item.value = Item.buyPrice(silver: 135);
			Item.rare = 0;
			//Item.UseSound = SoundID.Item1;
			//Item.autoReuse = false;
		}
	}
}