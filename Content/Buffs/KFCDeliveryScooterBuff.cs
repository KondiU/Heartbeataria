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
			DisplayName.SetDefault("KFC Delivery Scooter");
			Description.SetDefault("A great companion for traveling through the streets");

			Main.buffNoTimeDisplay[Type] = true;
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex){
			player.mount.SetMount(ModContent.MountType<Mounts.KFCDeliveryScooter>(), player);
			player.buffTime[buffIndex] = 10; 
		}
	}
}
