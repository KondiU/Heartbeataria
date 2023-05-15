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
					shop.Add<ImperialMasterHelmet>(Condition.DownedMoonLord, Condition.MoonPhaseFull);
					shop.Add<ImperialMasterBreastplate>(Condition.DownedMoonLord, Condition.MoonPhaseFull);
                    shop.Add<ImperialMasterLeggings>(Condition.DownedMoonLord, Condition.MoonPhaseFull);

					shop.Add<ImperialGuardHelmet>(Condition.DownedSkeletron, Condition.MoonPhaseWaningCrescent);
					shop.Add<ImperialGuardBreastplate>(Condition.DownedSkeletron, Condition.MoonPhaseWaningCrescent);
                    shop.Add<ImperialGuardLeggings>(Condition.DownedSkeletron, Condition.MoonPhaseWaningCrescent);

					shop.Add<MountainGuardHelmet>(Condition.DownedEyeOfCthulhu, Condition.MoonPhaseWaxingCrescent);
					shop.Add<MountainGuardBreastplate>(Condition.DownedEyeOfCthulhu, Condition.MoonPhaseWaxingCrescent);
                    shop.Add<MountainGuardLeggings>(Condition.DownedEyeOfCthulhu, Condition.MoonPhaseWaxingCrescent);

					shop.Add<DeepColdHelmet>(Condition.DownedIceQueen, Condition.MoonPhaseFirstQuarter);
					shop.Add<DeepColdBreastplate>(Condition.DownedIceQueen, Condition.MoonPhaseFirstQuarter);
                    shop.Add<DeepColdLeggings>(Condition.DownedIceQueen, Condition.MoonPhaseFirstQuarter);
            }
        }
    }
}