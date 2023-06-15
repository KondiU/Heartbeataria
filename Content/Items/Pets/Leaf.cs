using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace XDContentMod.Content.Items.Pets 
{
	public class Leaf : PetItem 
	{
		public override void SetStaticDefaults () 
		{
			Item.ResearchUnlockCount = 1;
		}

		public override void SetDefaults () {
			Item.DefaultToVanitypet(ModContent.ProjectileType<Content.Projectiles.Friendly.Pets.GreenFrogProjectile>(), ModContent.BuffType<Content.Buffs.GreenFrogBuff>());

			int width = 24; int height = 26;
			Item.Size = new Vector2(width, height);

			Item.rare = ItemRarityID.Orange;
			Item.value = Item.buyPrice(gold: 15);
		}
	}
}