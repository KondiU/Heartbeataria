using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace XDContentMod.Content.Buffs
{
	public class StarFlameBuff : ModBuff
	{
		public override void SetStaticDefaults() 
		{
			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) 
		{
			player.buffTime[buffIndex] = 18000;

			int projType = ModContent.ProjectileType<Content.Projectiles.Friendly.Pets.StarFlameProjectile>();


			if (player.whoAmI == Main.myPlayer && player.ownedProjectileCounts[projType] <= 0) 
			{
				var entitySource = player.GetSource_Buff(buffIndex);
				
				Projectile.NewProjectile(entitySource, player.Center, Vector2.Zero, projType, 0, 0f, player.whoAmI);
			}
		}
	}
}