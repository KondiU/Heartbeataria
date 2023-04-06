using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace XDContentMod.Content.Items.Pets 
{
	public class Xiaokuai : PetItem 
	{
		public override void SetStaticDefaults () 
		{
			DisplayName.SetDefault("Xiaokuai");
			Tooltip.SetDefault("Summons Xiaokuai");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId [Type] = 1;
		}

		public override void SetDefaults () {
			Item.DefaultToVanitypet(ModContent.ProjectileType<Content.Projectiles.Friendly.Pets.XiaokuaiProjectile>(), ModContent.BuffType<Content.Buffs.XiaokuaiBuff>());

			int width = 24; int height = 26;
			Item.Size = new Vector2(width, height);

			Item.rare = 3;
			Item.value = Item.buyPrice(gold: 25);
		}
	}
}