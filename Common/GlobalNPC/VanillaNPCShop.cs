using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace XDContentMod.Common {
	class VanillaNPCShop : GlobalNPC {
		public override void SetupShop (int type, Chest shop, ref int nextSlot) {
			Player player = Main.player [Main.myPlayer];
            if (type == NPCID.TravellingMerchant) 
            {
				if (NPC.downedMoonlord && Main.moonPhase == 0) 
                {
					shop.item [nextSlot].SetDefaults(ModContent.ItemType<Content.Items.Vanity.ImperialMasterHelmet>());
					nextSlot++;
					shop.item [nextSlot].SetDefaults(ModContent.ItemType<Content.Items.Vanity.ImperialMasterBreastplate>());
					nextSlot++;
                    shop.item [nextSlot].SetDefaults(ModContent.ItemType<Content.Items.Vanity.ImperialMasterLeggings>());
					nextSlot++;
	            } 

                if (NPC.downedBoss2 && Main.moonPhase == 1) 
                {
					shop.item [nextSlot].SetDefaults(ModContent.ItemType<Content.Items.Vanity.GuaPiMao>());
					nextSlot++;
					shop.item [nextSlot].SetDefaults(ModContent.ItemType<Content.Items.Vanity.TangSuitShirt>());
					nextSlot++;
                    shop.item [nextSlot].SetDefaults(ModContent.ItemType<Content.Items.Vanity.TangSuitPants>());
					nextSlot++;
	            }

                if (Main.hardMode && Main.moonPhase == 2) 
                {
                    shop.item [nextSlot].SetDefaults(ModContent.ItemType<Content.Items.Vanity.MythicalDogMask>());
					nextSlot++;
					shop.item [nextSlot].SetDefaults(ModContent.ItemType<Content.Items.Vanity.MythicalDogShirt>());
					nextSlot++;
                    shop.item [nextSlot].SetDefaults(ModContent.ItemType<Content.Items.Vanity.MythicalDogPants>());
					nextSlot++;
	            }

                if (NPC.downedBoss3 && Main.moonPhase == 3) 
                {
					shop.item [nextSlot].SetDefaults(ModContent.ItemType<Content.Items.Vanity.ImperialGuardHelmet>());
					nextSlot++;
					shop.item [nextSlot].SetDefaults(ModContent.ItemType<Content.Items.Vanity.ImperialGuardBreastplate>());
					nextSlot++;
                    shop.item [nextSlot].SetDefaults(ModContent.ItemType<Content.Items.Vanity.ImperialGuardLeggings>());
					nextSlot++;
	            }

                if (NPC.downedBoss1 && Main.moonPhase == 5) 
                {
					shop.item [nextSlot].SetDefaults(ModContent.ItemType<Content.Items.Vanity.MountainGuardHelmet>());
					nextSlot++;
					shop.item [nextSlot].SetDefaults(ModContent.ItemType<Content.Items.Vanity.MountainGuardBreastplate>());
					nextSlot++;
                    shop.item [nextSlot].SetDefaults(ModContent.ItemType<Content.Items.Vanity.MountainGuardLeggings>());
					nextSlot++;
	            }

                if (NPC.downedChristmasIceQueen && Main.moonPhase == 6) 
                {
					shop.item [nextSlot].SetDefaults(ModContent.ItemType<Content.Items.Vanity.DeepColdHelmet>());
					nextSlot++;
					shop.item [nextSlot].SetDefaults(ModContent.ItemType<Content.Items.Vanity.DeepColdBreastplate>());
					nextSlot++;
                    shop.item [nextSlot].SetDefaults(ModContent.ItemType<Content.Items.Vanity.DeepColdLeggings>());
					nextSlot++;
	            }

                if (NPC.downedPirates && Main.moonPhase == 7) 
                {
					shop.item [nextSlot].SetDefaults(ModContent.ItemType<Content.Items.Vanity.TangYuanHat>());
					nextSlot++;
					shop.item [nextSlot].SetDefaults(ModContent.ItemType<Content.Items.Vanity.TangYuanShirt>());
					nextSlot++;
                    shop.item [nextSlot].SetDefaults(ModContent.ItemType<Content.Items.Vanity.TangYuanPants>());
					nextSlot++;
	            }
            }
        }
    }
}