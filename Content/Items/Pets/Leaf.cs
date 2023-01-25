using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace XDContentMod.Content.Items.Pets 
{
	public class Leaf : PetItem 
	{
		public override void SetStaticDefaults () 
		{
			DisplayName.SetDefault("Leaf");
			Tooltip.SetDefault("What's underneath it?");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId [Type] = 1;
		}

		public override void SetDefaults () {
			Item.DefaultToVanitypet(ModContent.ProjectileType<Content.Projectiles.Friendly.Pets.GreenFrogProjectile>(), ModContent.BuffType<Content.Buffs.GreenFrogBuff>());

			int width = 24; int height = 26;
			Item.Size = new Vector2(width, height);

			Item.rare = 3;
			Item.value = Item.sellPrice(gold: 10);
		}
	}
}