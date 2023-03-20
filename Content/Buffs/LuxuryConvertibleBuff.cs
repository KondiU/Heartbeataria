using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace XDContentMod.Content.Buffs
{
	public class LuxuryConvertibleBuff : ModBuff
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Luxury Convertible");
			Description.SetDefault("Elegance never goes out of style!");

			Main.buffNoTimeDisplay[Type] = true;
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex){
			player.mount.SetMount(ModContent.MountType<Mounts.LuxuryConvertible>(), player);
			player.buffTime[buffIndex] = 10; 
		}
	}
}
