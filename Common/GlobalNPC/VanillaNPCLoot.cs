using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using XDContentMod.Content.Items.Materials;
using System.Linq;

namespace XDContentMod.Common.GlobalNPCs
{
	public class ChineseMaterialsDrops : GlobalNPC
	{
		public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot) 
		{
			if (npc.type == NPCID.EyeofCthulhu) 
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<GreenScales>(), 5));
			}

			if (System.Array.IndexOf(new int[] { NPCID.EaterofWorldsBody, NPCID.EaterofWorldsHead, NPCID.EaterofWorldsTail }, npc.type) > -1)
			{
				LeadingConditionRule leadingConditionRule = new(new Conditions.LegacyHack_IsABoss());
				leadingConditionRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<DreadFangs>(), 5));
				npcLoot.Add(leadingConditionRule);
			}

			if (npc.type == NPCID.BrainofCthulhu) 
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<GelOfCthulhu>(), 5));
			}

			if (npc.type == NPCID.SkeletronHead) 
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FilthySap>(), 5));
			}

			if (npc.type == NPCID.WallofFlesh) 
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<MagmaShell>(), 5));
			}
		}
	}
}