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
				npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<GreenScales>(), chanceDenominator: 3, chanceNumerator: 1));
			}

			if (System.Array.IndexOf(new int[] { NPCID.EaterofWorldsBody, NPCID.EaterofWorldsHead, NPCID.EaterofWorldsTail }, npc.type) > -1)
			{
				LeadingConditionRule leadingConditionRule = new(new Conditions.LegacyHack_IsABoss());
				leadingConditionRule.OnSuccess(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<DreadFangs>(), chanceDenominator: 3, chanceNumerator: 1));
				npcLoot.Add(leadingConditionRule);
			}

			if (npc.type == NPCID.BrainofCthulhu) 
			{
				npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<GelOfCthulhu>(), chanceDenominator: 3, chanceNumerator: 1));
			}

			if (npc.type == NPCID.SkeletronHead) 
			{
				npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<FilthySap>(), chanceDenominator: 3, chanceNumerator: 1));
			}

			if (npc.type == NPCID.WallofFlesh) 
			{
				npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<MagmaShell>(), chanceDenominator: 3, chanceNumerator: 1));
			}
		}
	}
}