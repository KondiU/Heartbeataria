using XDContentMod.Content.NPCs;
using System;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace XDContentMod.Common.Systems;

public class StarMerchantSystem : ModSystem
{
	public override void PreUpdateWorld() {
		StarMerchantNPC.UpdateTravelingMerchant();
	}

	public override void SaveWorldData(TagCompound tag) {
		if (StarMerchantNPC.spawnTime != double.MaxValue) {
			tag["StarMerchantSpawnTime"] = StarMerchantNPC.spawnTime;
		}
	}

	public override void LoadWorldData(TagCompound tag) {
		if (!tag.TryGet("StarMerchantSpawnTime", out StarMerchantNPC.spawnTime)) {
			StarMerchantNPC.spawnTime = double.MaxValue;
		}
	}
}