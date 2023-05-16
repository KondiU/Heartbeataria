using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using XDContentMod.Content.Items.Materials;

namespace XDContentMod.Common.GlobalItems
{
	public class BossBagLoot : GlobalItem
	{
		public override void ModifyItemLoot(Item item, ItemLoot itemLoot) 
        {
            if(item.type == ItemID.EyeOfCthulhuBossBag) 
                itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<GreenScales>(), 3));

			if(item.type == ItemID.EaterOfWorldsBossBag) 
                itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<DreadFangs>(), 3));

			if(item.type == ItemID.BrainOfCthulhuBossBag) 
                itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<GelOfCthulhu>(), 3));

            if(item.type == ItemID.SkeletronBossBag) 
                itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<FilthySap>(), 3));

            if(item.type == ItemID.WallOfFleshBossBag) 
                itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<MagmaShell>(), 3));
		}
	}
}