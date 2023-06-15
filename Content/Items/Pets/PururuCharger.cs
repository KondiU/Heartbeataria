using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace XDContentMod.Content.Items.Pets 
{
	public class PururuCharger : PetItem 
	{
		public override void SetStaticDefaults () 
		{
			Item.ResearchUnlockCount = 1;
		}

		public override void SetDefaults () {
			Item.DefaultToVanitypet(ModContent.ProjectileType<Content.Projectiles.Friendly.Pets.PururuProjectile>(), ModContent.BuffType<Content.Buffs.PururuBuff>());

			int width = 24; int height = 26;
			Item.Size = new Vector2(width, height);

			Item.rare = ItemRarityID.Orange;
			Item.value = Item.buyPrice(gold: 25);
		}
	}
}