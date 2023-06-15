using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace XDContentMod.Common 
{
	class VanillaNPCShop : GlobalNPC 
	{
		public override void ModifyShop(NPCShop shop) 
		{
            if (shop.NpcType == NPCID.TravellingMerchant) 
            {
					shop.Add(ModContent.ItemType<Content.Items.Vanity.MountainGuardHelmet>(), Condition.DownedEyeOfCthulhu, Condition.MoonPhaseFull);
					shop.Add(ModContent.ItemType<Content.Items.Vanity.MountainGuardBreastplate>(), Condition.DownedEyeOfCthulhu, Condition.MoonPhaseFull);
                    shop.Add(ModContent.ItemType<Content.Items.Vanity.MountainGuardLeggings>(), Condition.DownedEyeOfCthulhu, Condition.MoonPhaseFull);

					shop.Add(ModContent.ItemType<Content.Items.Vanity.DeepColdHelmet>(), Condition.DownedSkeletron, Condition.MoonPhaseWaxingCrescent);
					shop.Add(ModContent.ItemType<Content.Items.Vanity.DeepColdBreastplate>(), Condition.DownedSkeletron, Condition.MoonPhaseWaxingCrescent);
                    shop.Add(ModContent.ItemType<Content.Items.Vanity.DeepColdLeggings>(), Condition.DownedSkeletron, Condition.MoonPhaseWaxingCrescent);

					shop.Add(ModContent.ItemType<Content.Items.Vanity.ImperialGuardHelmet>(), Condition.Hardmode, Condition.MoonPhaseThirdQuarter);
					shop.Add(ModContent.ItemType<Content.Items.Vanity.ImperialGuardBreastplate>(), Condition.Hardmode, Condition.MoonPhaseThirdQuarter);
                    shop.Add(ModContent.ItemType<Content.Items.Vanity.ImperialGuardLeggings>(), Condition.Hardmode, Condition.MoonPhaseThirdQuarter);

					shop.Add(ModContent.ItemType<Content.Items.Vanity.ImperialMasterHelmet>(), Condition.DownedMoonLord, Condition.MoonPhaseFirstQuarter);
					shop.Add(ModContent.ItemType<Content.Items.Vanity.ImperialMasterBreastplate>(), Condition.DownedMoonLord, Condition.MoonPhaseFirstQuarter);
                    shop.Add(ModContent.ItemType<Content.Items.Vanity.ImperialMasterLeggings>(), Condition.DownedMoonLord, Condition.MoonPhaseFirstQuarter);
            }
        }
    }
}