using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace XDContentMod.Content.Items.Pets 
{
	public class FriedChickenNugget : PetItem 
	{
		public override void SetStaticDefaults () 
		{
			DisplayName.SetDefault("Fried Chicken Nugget");
			Tooltip.SetDefault("Summons a chicken");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId [Type] = 1;
		}

		public override void SetDefaults () {
			Item.DefaultToVanitypet(ModContent.ProjectileType<Content.Projectiles.Friendly.Pets.ChickenProjectile>(), ModContent.BuffType<Content.Buffs.ChickenBuff>());

			int width = 24; int height = 26;
			Item.Size = new Vector2(width, height);

			Item.rare = 3;
			Item.value = Item.sellPrice(gold: 10);
		}
	}
}