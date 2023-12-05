using XDContentMod.Content.NPCs;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace XDContentMod.Common.Systems;

public class StarMerchantSystem : ModSystem
{
	public override void PreUpdateWorld() 
	{
		StarMerchantNPC.UpdateTravelingMerchant();
	}

	public override void SaveWorldData(TagCompound tag) 
	{
		tag["shopItems"] = StarMerchantNPC.shopItems;
		if (StarMerchantNPC.spawnTime != double.MaxValue) 
		{
			tag["spawnTime"] = StarMerchantNPC.spawnTime;
		}
	}

	public override void LoadWorldData(TagCompound tag) 
	{
		StarMerchantNPC.shopItems.Clear();
			StarMerchantNPC.shopItems.AddRange(tag.Get<List<Item>>("shopItems"));
			if (!tag.TryGet("spawnTime", out StarMerchantNPC.spawnTime)) 
			{
			StarMerchantNPC.spawnTime = double.MaxValue;
		}
	}
	
	public override void ClearWorld() 
	{
		StarMerchantNPC.shopItems.Clear();
		StarMerchantNPC.spawnTime = double.MaxValue;
	}

	public override void NetSend(BinaryWriter writer) {
		writer.Write(StarMerchantNPC.shopItems.Count);
		foreach (Item item in StarMerchantNPC.shopItems) {
			ItemIO.Send(item, writer, writeStack: true);
		}
	}

	public override void NetReceive(BinaryReader reader) {
		StarMerchantNPC.shopItems.Clear();
		int count = reader.ReadInt32();
		for (int i = 0; i < count; i++) {
			StarMerchantNPC.shopItems.Add(ItemIO.Receive(reader, readStack: true));
		}
	}
}