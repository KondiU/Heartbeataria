using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace XDContentMod.Content.Buffs
{
	public class GreenFrogBuff : ModBuff
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Green Frog");
			Description.SetDefault("Little green frog that can't get lost in the wild");

			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) 
		{
			player.buffTime[buffIndex] = 18000;

			int projType = ModContent.ProjectileType<Content.Projectiles.Friendly.Pets.GreenFrogProjectile>();


			if (player.whoAmI == Main.myPlayer && player.ownedProjectileCounts[projType] <= 0) 
			{
				var entitySource = player.GetSource_Buff(buffIndex);
				
				Projectile.NewProjectile(entitySource, player.Center, Vector2.Zero, projType, 0, 0f, player.whoAmI);
			}
		}
	}
}