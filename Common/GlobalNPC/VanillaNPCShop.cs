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

					shop.Add<GuaPiMao>(Condition.DownedEowOrBoc, Condition.MoonPhaseWaningGibbous);
					shop.Add<TangSuitShirt>(Condition.DownedEowOrBoc, Condition.MoonPhaseWaningGibbous);
                    shop.Add<TangSuitPants>(Condition.DownedEowOrBoc, Condition.MoonPhaseWaningGibbous);

                    shop.Add<MythicalDogMask>(Condition.Hardmode, Condition.MoonPhaseThirdQuarter);
					shop.Add<MythicalDogShirt>(Condition.Hardmode, Condition.MoonPhaseThirdQuarter);
                    shop.Add<MythicalDogPants>(Condition.Hardmode, Condition.MoonPhaseThirdQuarter);

					shop.Add<ImperialGuardHelmet>(Condition.DownedSkeletron, Condition.MoonPhaseWaningCrescent);
					shop.Add<ImperialGuardBreastplate>(Condition.DownedSkeletron, Condition.MoonPhaseWaningCrescent);
                    shop.Add<ImperialGuardLeggings>(Condition.DownedSkeletron, Condition.MoonPhaseWaningCrescent);

					shop.Add<MountainGuardHelmet>(Condition.DownedEyeOfCthulhu, Condition.MoonPhaseWaxingCrescent);
					shop.Add<MountainGuardBreastplate>(Condition.DownedEyeOfCthulhu, Condition.MoonPhaseWaxingCrescent);
                    shop.Add<MountainGuardLeggings>(Condition.DownedEyeOfCthulhu, Condition.MoonPhaseWaxingCrescent);

					shop.Add<DeepColdHelmet>(Condition.DownedIceQueen, Condition.MoonPhaseFirstQuarter);
					shop.Add<DeepColdBreastplate>(Condition.DownedIceQueen, Condition.MoonPhaseFirstQuarter);
                    shop.Add<DeepColdLeggings>(Condition.DownedIceQueen, Condition.MoonPhaseFirstQuarter);

					shop.Add<TangYuanHat>(Condition.DownedPirates, Condition.MoonPhaseWaxingGibbous);
					shop.Add<TangYuanShirt>(Condition.DownedPirates, Condition.MoonPhaseWaxingGibbous);
                    shop.Add<TangYuanPants>(Condition.DownedPirates, Condition.MoonPhaseWaxingGibbous);
            }
        }
    }
}