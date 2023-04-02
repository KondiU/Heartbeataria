using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace XDContentMod.Content.Items.Pets 
{
	public class Basketball : PetItem 
	{
		public override void SetStaticDefaults () 
		{
			DisplayName.SetDefault("Basketball");
			Tooltip.SetDefault("Summons a Flying Basketball");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId [Type] = 1;
		}

		public override void SetDefaults () {
			Item.DefaultToVanitypet(ModContent.ProjectileType<Content.Projectiles.Friendly.Pets.FlyingBasketballProjectile>(), ModContent.BuffType<Content.Buffs.FlyingBasketballBuff>());

			int width = 24; int height = 26;
			Item.Size = new Vector2(width, height);

			Item.rare = 3;
			Item.value = Item.sellPrice(gold: 25);
		}
	}
}