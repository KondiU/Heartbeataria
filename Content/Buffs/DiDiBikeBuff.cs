using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace XDContentMod.Content.Buffs
{
	public class DiDiBikeBuff : ModBuff
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("DiDi Bike");
			Description.SetDefault("A great companion for traveling through the streets");

			Main.buffNoTimeDisplay[Type] = true;
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex){
			player.mount.SetMount(ModContent.MountType<Mounts.DiDiBike>(), player);
			player.buffTime[buffIndex] = 10; 
		}
	}
}
