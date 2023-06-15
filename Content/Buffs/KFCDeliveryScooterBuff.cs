using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace XDContentMod.Content.Buffs
{
	public class KFCDeliveryScooterBuff : ModBuff
	{
		public override void SetStaticDefaults() 
		{
			Main.buffNoTimeDisplay[Type] = true;
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex){
			player.mount.SetMount(ModContent.MountType<Mounts.KFCDeliveryScooter>(), player);
			player.buffTime[buffIndex] = 10; 
		}
	}
}
