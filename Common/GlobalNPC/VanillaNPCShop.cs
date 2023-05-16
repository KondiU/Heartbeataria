using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using XDContentMod.Content.Items.Vanity;

namespace XDContentMod.Common 
{
	class VanillaNPCShop : GlobalNPC 
	{
		
		public override void ModifyShop(NPCShop shop) 
		{
            if (shop.NpcType == NPCID.TravellingMerchant) 
            {
					shop.Add<MountainGuardHelmet>(Condition.DownedEyeOfCthulhu, Condition.MoonPhaseFull);
					shop.Add<MountainGuardBreastplate>(Condition.DownedEyeOfCthulhu, Condition.MoonPhaseFull);
                    shop.Add<MountainGuardLeggings>(Condition.DownedEyeOfCthulhu, Condition.MoonPhaseFull);

					shop.Add<DeepColdHelmet>(Condition.DownedSkeletron, Condition.MoonPhaseWaxingCrescent);
					shop.Add<DeepColdBreastplate>(Condition.DownedSkeletron, Condition.MoonPhaseWaxingCrescent);
                    shop.Add<DeepColdLeggings>(Condition.DownedSkeletron, Condition.MoonPhaseWaxingCrescent);

					shop.Add<ImperialGuardHelmet>(Condition.Hardmode, Condition.MoonPhaseThirdQuarter);
					shop.Add<ImperialGuardBreastplate>(Condition.Hardmode, Condition.MoonPhaseThirdQuarter);
                    shop.Add<ImperialGuardLeggings>(Condition.Hardmode, Condition.MoonPhaseThirdQuarter);

					shop.Add<ImperialMasterHelmet>(Condition.DownedMoonLord, Condition.MoonPhaseFirstQuarter);
					shop.Add<ImperialMasterBreastplate>(Condition.DownedMoonLord, Condition.MoonPhaseFirstQuarter);
                    shop.Add<ImperialMasterLeggings>(Condition.DownedMoonLord, Condition.MoonPhaseFirstQuarter);
            }
        }
    }
}