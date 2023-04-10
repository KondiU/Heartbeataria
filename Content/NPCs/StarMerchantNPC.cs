using XDContentMod.Content.Items;
using XDContentMod.Content.Items.Mounts;
using XDContentMod.Content.Items.Pets;
using XDContentMod.Content.Items.Placeable;
using XDContentMod.Content.Items.Vanity;
using XDContentMod.Content.Items.Weapons;
using XDContentMod.Content.Items.Weapons.Melee;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.GameContent;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.Utilities;

namespace XDContentMod.Content.NPCs
{
	[AutoloadHead]
	class StarMerchantNPC : ModNPC
	{
		// Time of day for traveller to leave (6PM)
		public const double despawnTime = 48600.0;

		// the time of day the traveler will spawn (double.MaxValue for no spawn)
		// saved and loaded with the world in TravelingMerchantSystem
		public static double spawnTime = 13500;

		// The list of items in the traveler's shop. Saved with the world and set when the traveler spawns
		public List<Item> shopItems = new List<Item>();

		public override bool PreAI() 
		{
			if ((!Main.dayTime || Main.time >= despawnTime) && !IsNpcOnscreen(NPC.Center)) // If it's past the despawn time and the NPC isn't onscreen
			{
				// Here we despawn the NPC and send a message stating that the NPC has despawned
				// LegacyMisc.35 is {0) has departed!
				if (Main.netMode == NetmodeID.SinglePlayer) Main.NewText(Language.GetTextValue("LegacyMisc.35", NPC.FullName), 50, 125, 255);
				else ChatHelper.BroadcastChatMessage(NetworkText.FromKey("LegacyMisc.35", NPC.GetFullNetName()), new Color(50, 125, 255));
				NPC.active = false;
				NPC.netSkip = -1;
				NPC.life = 0;
				return false;
			}

			return true;
		}

		public static void UpdateTravelingMerchant() 
		{
			bool travelerIsThere = (NPC.FindFirstNPC(ModContent.NPCType<StarMerchantNPC>()) != -1); // Find a Merchant if there's one spawned in the world

			// Main.time is set to 0 each morning, and only for one update. Sundialling will never skip past time 0 so this is the place for 'on new day' code
			if (Main.dayTime && Main.time == 0) 
			{
				// insert code here to change the spawn chance based on other conditions (say, npcs which have arrived, or milestones the player has passed)
				// You can also add a day counter here to prevent the merchant from possibly spawning multiple days in a row.

				// NPC won't spawn today if it stayed all night
				if (!travelerIsThere && Main.rand.NextBool(5)) 
				{ // 4 = 25% Chance
																// Here we can make it so the NPC doesnt spawn at the EXACT same time every time it does spawn
					spawnTime = GetRandomSpawnTime(0, 27000); // minTime = 6:00am, maxTime = 7:30am
				}
				else {
					spawnTime = double.MaxValue; // no spawn today
				}
			}

			// Spawn the traveler if the spawn conditions are met (time of day, no events, no sundial)
			if (!travelerIsThere && CanSpawnNow()) 
			{
				int newTraveler = NPC.NewNPC(Terraria.Entity.GetSource_TownSpawn(), Main.spawnTileX * 16, Main.spawnTileY * 16, ModContent.NPCType<StarMerchantNPC>(), 1); // Spawning at the world spawn
				NPC traveler = Main.npc[newTraveler];
				traveler.homeless = true;
				traveler.direction = Main.spawnTileX >= WorldGen.bestX ? -1 : 1;
				traveler.netUpdate = true;

				// Prevents the traveler from spawning again the same day
				spawnTime = double.MaxValue;

				// Annouce that the traveler has spawned in!
				if (Main.netMode == NetmodeID.SinglePlayer) Main.NewText(Language.GetTextValue("Announcement.HasArrived", traveler.FullName), 50, 125, 255);
				else ChatHelper.BroadcastChatMessage(NetworkText.FromKey("Announcement.HasArrived", traveler.GetFullNetName()), new Color(50, 125, 255));
			}
		}

		private static bool CanSpawnNow() 
		{
			// can't spawn if the sundial is active
			if (Main.fastForwardTime)
				return false;

			// can spawn if daytime, and between the spawn and despawn times
			return Main.dayTime && Main.time >= spawnTime && Main.time < despawnTime;
		}

		private static bool IsNpcOnscreen(Vector2 center) 
		{
			int w = NPC.sWidth + NPC.safeRangeX * 2;
			int h = NPC.sHeight + NPC.safeRangeY * 2;
			Rectangle npcScreenRect = new Rectangle((int)center.X - w / 2, (int)center.Y - h / 2, w, h);
			foreach (Player player in Main.player) 
			{
				// If any player is close enough to the traveling merchant, it will prevent the npc from despawning
				if (player.active && player.getRect().Intersects(npcScreenRect)) return true;
			}
			return false;
		}

		public static double GetRandomSpawnTime(double minTime, double maxTime) 
		{
			// A simple formula to get a random time between two chosen times
			return (maxTime - minTime) * Main.rand.NextDouble() + minTime;
		}

		public void CreateNewShop() 
		{
			// create a list of item ids
			var itemIds = new List<int>();

			// For each slot we add a switch case to determine what should go in that slot
			switch (Main.rand.Next(3)) 
			{
				case 0:
					itemIds.Add(ModContent.ItemType<HeartbeatBroadsword>());
					break;
				case 1:
					itemIds.Add(ModContent.ItemType<TapTapBroadsword>());
					break;
				default:
					itemIds.Add(ModContent.ItemType<KFCChickenDrumstick>());
					break;
			}

			switch (Main.rand.Next(5)) 
			{
				case 0:
					itemIds.Add(ModContent.ItemType<BaiduTiebaHuajiDisc>());
					break;
				case 1:
					itemIds.Add(ModContent.ItemType<HupuDisc>());
					break;
				case 2:
					itemIds.Add(ModContent.ItemType<iFlytekDisc>());
					break;
				case 3:
					itemIds.Add(ModContent.ItemType<LOOKDisc>());
					break;
				default:
					itemIds.Add(ModContent.ItemType<PururuDisc>());
					break;
			}

			switch (Main.rand.Next(5)) 
			{
				case 0:
					itemIds.Add(ModContent.ItemType<Basketball>());
					break;
				case 1:
					itemIds.Add(ModContent.ItemType<FriedChickenNugget>());
					break;
				case 2:
					itemIds.Add(ModContent.ItemType<PururuCharger>());
					break;
				case 3:
					itemIds.Add(ModContent.ItemType<Xiaokuai>());
					break;
				default:
					itemIds.Add(ModContent.ItemType<Xiaoliu>());
					break;
			}

			switch (Main.rand.Next(3)) 
			{
				case 0:
					itemIds.Add(ModContent.ItemType<Leaf>());
					break;
				case 1:
					itemIds.Add(ModContent.ItemType<ToadQuack2R>());
					break;
				default:
					itemIds.Add(ModContent.ItemType<ToadQuack2W>());
					break;
			}

			switch (Main.rand.Next(5)) 
			{
				case 0:
					itemIds.Add(ModContent.ItemType<ConvertibleKeys>());
					break;
				case 1:
					itemIds.Add(ModContent.ItemType<DiDiBikeKeys>());
					break;
				case 2:
					itemIds.Add(ModContent.ItemType<DiDiCarKeys>());
					break;
				case 3:
					itemIds.Add(ModContent.ItemType<KFCDeliveryScooterKeys>());
					break;
				default:
					itemIds.Add(ModContent.ItemType<TapTapMinivanKeys>());
					break;
			}

			itemIds.Add(ModContent.ItemType<KFCChair>());
			itemIds.Add(ModContent.ItemType<KFCWorkBench>());
			itemIds.Add(ModContent.ItemType<KFCBar>());

			switch (Main.rand.Next(6)) 
			{
				case 0:
					itemIds.Add(ModContent.ItemType<BirthdayCake>());
					break;
				case 1:
					itemIds.Add(ModContent.ItemType<ColorfulBalloonsStockPhoto>());
					break;
				case 2:
					itemIds.Add(ModContent.ItemType<GetThePartyStarted>());
					break;
				case 3:
					itemIds.Add(ModContent.ItemType<PururuPortrait>());
					break;
				case 4:
					itemIds.Add(ModContent.ItemType<TapTapGroupPortrait>());
					break;
				default:
					itemIds.Add(ModContent.ItemType<TararaPortrait>());
					break;
			}

			switch (Main.rand.Next(6)) 
			{
				case 0:
					itemIds.Add(ModContent.ItemType<SmallHeartbeatTownscapeOilPainting>());
					break;
				case 1:
					itemIds.Add(ModContent.ItemType<HeartbeatOilPainting>());
					break;
				case 2:
					itemIds.Add(ModContent.ItemType<LargeHeartbeatTownscapeOilPainting>());
					break;
				case 3:
					itemIds.Add(ModContent.ItemType<SmallDouYuOilPainting>());
					break;
				case 4:
					itemIds.Add(ModContent.ItemType<MediumDouYuOilPainting>());
					break;
				default:
					itemIds.Add(ModContent.ItemType<LargeDouYuOilPainting>());
					break;
			}

			switch (Main.rand.Next(6)) 
			{
				case 0:
					itemIds.Add(ModContent.ItemType<KFCBurgerAd>());
					break;
				case 1:
					itemIds.Add(ModContent.ItemType<KFCChickenDrumstickAd>());
					break;
				case 2:
					itemIds.Add(ModContent.ItemType<KFCFamilyBucketAd>());
					break;
				case 3:
					itemIds.Add(ModContent.ItemType<SmallHuyaOilPainting>());
					break;
				case 4:
					itemIds.Add(ModContent.ItemType<MediumHuyaOilPainting>());
					break;
				default:
					itemIds.Add(ModContent.ItemType<LargeHuyaOilPainting>());
					break;
			}

			switch (Main.rand.Next(6)) 
			{
				case 0:
					itemIds.Add(ModContent.ItemType<RockPotato>());
					break;
				case 1:
					itemIds.Add(ModContent.ItemType<LightPotato>());
					break;
				case 2:
					itemIds.Add(ModContent.ItemType<Potataria>());
					break;
				case 3:
					itemIds.Add(ModContent.ItemType<AcFunOilPainting>());
					break;
				case 4:
					itemIds.Add(ModContent.ItemType<JinyiCinemasPopcornPoster>());
					break;
				default:
					itemIds.Add(ModContent.ItemType<SeiyuuchanSupportPoster>());
					break;
			}
			
			if (Main.moonPhase == 0) 
			{
		 		itemIds.Add(ModContent.ItemType<ColonelsMask>());
				itemIds.Add(ModContent.ItemType<ColonelsTuxedoShirt>());
				itemIds.Add(ModContent.ItemType<ColonelsTuxedoPants>());
			}

			if (Main.moonPhase == 1) 
			{
		 		itemIds.Add(ModContent.ItemType<CuteBrownWig>());
				itemIds.Add(ModContent.ItemType<SeifukuShirt>());
				itemIds.Add(ModContent.ItemType<SeifukuShoes>());
			}

			if (Main.moonPhase == 2) 
			{
				itemIds.Add(ModContent.ItemType<HeartbeatOrangePonytail>());
		 		itemIds.Add(ModContent.ItemType<HeartbeatOrangeDress>());
				itemIds.Add(ModContent.ItemType<HeartbeatOrangeShoes>());
				itemIds.Add(ModContent.ItemType<HeartbeatOrangeWig>());
				itemIds.Add(ModContent.ItemType<HeartbeatOrangeTuxedoShirt>());
				itemIds.Add(ModContent.ItemType<HeartbeatOrangeTuxedoPants>());
			}

			if (Main.moonPhase == 3) 
			{
		 		itemIds.Add(ModContent.ItemType<BCYCatEars>());
				itemIds.Add(ModContent.ItemType<BCYCosplayDress>());
				itemIds.Add(ModContent.ItemType<BCYCosplayShoes>());
			}

			if (Main.moonPhase == 4) 
			{
				itemIds.Add(ModContent.ItemType<TikTokNoteHat>());
				itemIds.Add(ModContent.ItemType<TikTokTorso>());
				itemIds.Add(ModContent.ItemType<TikTokPants>());
		 		itemIds.Add(ModContent.ItemType<DogMask>());
				itemIds.Add(ModContent.ItemType<DogShirt>());
				itemIds.Add(ModContent.ItemType<DogPants>());
			}

			if (Main.moonPhase == 5) 
			{
				itemIds.Add(ModContent.ItemType<TararaPonytail>());
				itemIds.Add(ModContent.ItemType<TararaDress>());
				itemIds.Add(ModContent.ItemType<TararaShoes>());
			}

			if (Main.moonPhase == 6) 
			{
				itemIds.Add(ModContent.ItemType<iQIYIMechaHelmet>());
				itemIds.Add(ModContent.ItemType<iQIYIMechaTorso>());
				itemIds.Add(ModContent.ItemType<iQIYIMechaPants>());
			}

			if (Main.moonPhase == 7) 
			{
				itemIds.Add(ModContent.ItemType<ExpeditionerHat>());
				itemIds.Add(ModContent.ItemType<ExpeditionerShirt>());
				itemIds.Add(ModContent.ItemType<ExpeditionerPants>());
		 		itemIds.Add(ModContent.ItemType<ChengXinYouXuanHat>());
				itemIds.Add(ModContent.ItemType<ChengXinYouXuanShirt>());
				itemIds.Add(ModContent.ItemType<ChengXinYouXuanPants>());
			}

			shopItems = new List<Item>();
			foreach (int itemId in itemIds) 
			{
				Item item = new Item();
				item.SetDefaults(itemId);
				shopItems.Add(item);
			}
		}

		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Star Merchant");
			Main.npcFrameCount[NPC.type] = 25;
			NPCID.Sets.ExtraFramesCount[NPC.type] = 9;
			NPCID.Sets.AttackFrameCount[NPC.type] = 4;
			NPCID.Sets.DangerDetectRange[NPC.type] = 700;
			NPCID.Sets.AttackType[NPC.type] = 0;
			NPCID.Sets.AttackTime[NPC.type] = 90;
			NPCID.Sets.AttackAverageChance[NPC.type] = 30;
			NPCID.Sets.HatOffsetY[NPC.type] = 2;

			NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0) 
			{
				Velocity = 1f
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
		}

		public override void SetDefaults() 
		{
			NPC.townNPC = true;
			NPC.friendly = true;
			NPC.width = 18;
			NPC.height = 40;
			NPC.aiStyle = 7;
			NPC.damage = 10;
			NPC.defense = 15;
			NPC.lifeMax = 250;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.knockBackResist = 0.5f;
			AIType = NPCID.TravellingMerchant;
			AnimationType = NPCID.TravellingMerchant;
			CreateNewShop();
		}

		public override void SetBestiary(Terraria.GameContent.Bestiary.BestiaryDatabase database, Terraria.GameContent.Bestiary.BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new Terraria.GameContent.Bestiary.IBestiaryInfoElement[] 
			{
                Terraria.GameContent.Bestiary.BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
                new Terraria.GameContent.Bestiary.FlavorTextBestiaryInfoElement("There's very little info about the Star Merchant. Some say they got here from other space and for some reason they can't get back home. We're not even sure about their gender, but it's pretty clear that they love to sell some unique items in their shop!"),
            });
        }

		public override void SaveData(TagCompound tag) 
		{
			tag["itemIds"] = shopItems;
		}

		public override void LoadData(TagCompound tag) 
		{
			shopItems = tag.Get<List<Item>>("shopItems");
		}

		public override bool CanTownNPCSpawn(int numTownNPCs, int money) 
		{
			return false; // This should always be false, because we spawn in the Traveling Merchant manually
		}

		public override ITownNPCProfile TownNPCProfile() 
		{
			return new ExampleTravelingMerchantProfile();
		}

		public override List<string> SetNPCNameList() 
		{
			return new List<string>() 
			{
				"Alex",
				"Ari",
				"Efe",
				"Kai",
				"Makena",
				"Noor",
				"Steve",
				"Sunny",
				"Zuri"
			};
		}

		public override string GetChat() 
		{
			WeightedRandom<string> chat = new WeightedRandom<string>();

			int clothier = NPC.FindFirstNPC(NPCID.Clothier);
			if (clothier >= 0) 
			{
				chat.Add(Language.GetTextValue("Mods.XDContentMod.Dialogue.StarMerchant.StarMerchantClothierDialogue1", Main.npc[clothier].GivenName));
			}
			
			int mechanic = NPC.FindFirstNPC(NPCID.Mechanic);
			if (mechanic >= 0) 
			{
				chat.Add(Language.GetTextValue("Mods.XDContentMod.Dialogue.StarMerchant.StarMerchantMechanicDialogue1", Main.npc[mechanic].GivenName));
			}

			int merchant = NPC.FindFirstNPC(NPCID.Merchant);
			if (merchant >= 0) 
			{
				chat.Add(Language.GetTextValue("Mods.XDContentMod.Dialogue.StarMerchant.StarMerchantMerchantDialogue1", Main.npc[merchant].GivenName));
			}

			int travellingmerchant = NPC.FindFirstNPC(NPCID.TravellingMerchant);
			if (travellingmerchant >= 0) 
			{
				chat.Add(Language.GetTextValue("Mods.XDContentMod.Dialogue.StarMerchant.StarMerchantTravellingMerchantDialogue1", Main.npc[travellingmerchant].GivenName));
			}
	
			int guide = NPC.FindFirstNPC(NPCID.Guide);
			if (guide >= 0) 
			{
				chat.Add(Language.GetTextValue("Mods.XDContentMod.Dialogue.StarMerchant.StarMerchantGuideDialogue1", Main.npc[guide].GivenName));
			}

			int zoologist = NPC.FindFirstNPC(NPCID.BestiaryGirl);
			if (zoologist >= 0) 
			{
				chat.Add(Language.GetTextValue("Mods.XDContentMod.Dialogue.StarMerchant.StarMerchantZoologistDialogue1", Main.npc[zoologist].GivenName));
			}

			int truffle = NPC.FindFirstNPC(NPCID.Truffle);
			if (truffle >= 0) 
			{
				chat.Add(Language.GetTextValue("Mods.XDContentMod.Dialogue.StarMerchant.StarMerchantTruffleDialogue1", Main.npc[truffle].GivenName));
			}

			if (Main.dayTime)
			{
				chat.Add(Language.GetTextValue("Mods.XDContentMod.Dialogue.StarMerchant.StarMerchantDay1"));
			}
			else
			{
				chat.Add(Language.GetTextValue("Mods.XDContentMod.Dialogue.StarMerchant.StarMerchantNight1"));
				chat.Add(Language.GetTextValue("Mods.XDContentMod.Dialogue.StarMerchant.StarMerchantNight2"));
				chat.Add(Language.GetTextValue("Mods.XDContentMod.Dialogue.StarMerchant.StarMerchantNight3"));
			}

			if (Main.raining)
			{
				chat.Add(Language.GetTextValue("Mods.XDContentMod.Dialogue.StarMerchant.StarMerchantRain1"));
				chat.Add(Language.GetTextValue("Mods.XDContentMod.Dialogue.StarMerchant.StarMerchantRain2"));
				chat.Add(Language.GetTextValue("Mods.XDContentMod.Dialogue.StarMerchant.StarMerchantRain3"));
			}

			if (Main.IsItAHappyWindyDay)
			{
				chat.Add(Language.GetTextValue("Mods.XDContentMod.Dialogue.StarMerchant.StarMerchantWind1"));
			}

			if (Main.bloodMoon)
			{
				chat.Add(Language.GetTextValue("Mods.XDContentMod.Dialogue.StarMerchant.StarMerchantBloodMoon1"));
			}

			if (Main.LocalPlayer.armor[0].type == ModContent.ItemType<StarMerchantHat>())
			{
				chat.Add(Language.GetTextValue("Mods.XDContentMod.Dialogue.StarMerchant.StarMerchantHat1"));
			}
			
			chat.Add(Language.GetTextValue("Mods.XDContentMod.Dialogue.StarMerchant.StarMerchantDialogue1"));
			chat.Add(Language.GetTextValue("Mods.XDContentMod.Dialogue.StarMerchant.StarMerchantDialogue2"));
			chat.Add(Language.GetTextValue("Mods.XDContentMod.Dialogue.StarMerchant.StarMerchantDialogue3"));
			chat.Add(Language.GetTextValue("Mods.XDContentMod.Dialogue.StarMerchant.StarMerchantDialogue4"));
			chat.Add(Language.GetTextValue("Mods.XDContentMod.Dialogue.StarMerchant.StarMerchantDialogue5"));
			chat.Add(Language.GetTextValue("Mods.XDContentMod.Dialogue.StarMerchant.StarMerchantDialogue6"));
			chat.Add(Language.GetTextValue("Mods.XDContentMod.Dialogue.StarMerchant.StarMerchantDialogue7"));
			chat.Add(Language.GetTextValue("Mods.XDContentMod.Dialogue.StarMerchant.StarMerchantDialogue8"));
			chat.Add(Language.GetTextValue("Mods.XDContentMod.Dialogue.StarMerchant.StarMerchantDialogue9"));
			chat.Add(Language.GetTextValue("Mods.XDContentMod.Dialogue.StarMerchant.StarMerchantDialogue10"));
			chat.Add(Language.GetTextValue("Mods.XDContentMod.Dialogue.StarMerchant.StarMerchantDialogue11"));
			chat.Add(Language.GetTextValue("Mods.XDContentMod.Dialogue.StarMerchant.StarMerchantDialogue12"));

			string dialogueLine = chat;
			return dialogueLine;
		}

		public override void SetChatButtons(ref string button, ref string button2) 
		{
			button = Language.GetTextValue("LegacyInterface.28");
			Main.LocalPlayer.currentShoppingSettings.HappinessReport = "";
		}

		public override void OnChatButtonClicked(bool firstButton, ref bool shop) 
		{
			if (firstButton) {
				shop = true;
			}
		}

		public override void SetupShop(Chest shop, ref int nextSlot) 
		{
			foreach (Item item in shopItems) 
			{
				// We don't want "empty" items and unloaded items to appear
				if (item == null || item.type == ItemID.None)
					continue;

				shop.item[nextSlot].SetDefaults(item.type);
				nextSlot++;
			}
		}

		public override void AI() 
		{
			NPC.homeless = true; // Make sure it stays homeless
		}

		public override void ModifyNPCLoot(NPCLoot npcLoot) 
		{
			npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<StarMerchantHat>()));
		}

		public override void HitEffect(int hitDirection, double damage)
   		{
			if (Main.netMode == NetmodeID.Server) 
			{
				// We don't want Mod.Find<ModGore> to run on servers as it will crash because gores are not loaded on servers
				return;
			}

        	if (NPC.life <= 0) 
			{
				int GoreHead = Mod.Find<ModGore>("StarMerchantNPC_GoreHead").Type;
				int GoreHand = Mod.Find<ModGore>("StarMerchantNPC_GoreHand").Type;
				int GoreLeg = Mod.Find<ModGore>("StarMerchantNPC_GoreLeg").Type;

				var entitySource = NPC.GetSource_Death();

				for (int i = 0; i < 1; i++) 
				{
					Gore.NewGore(entitySource, NPC.position, new Vector2(Main.rand.Next(-3, 4), Main.rand.Next(-3, 4)), GoreHead);
					Gore.NewGore(entitySource, NPC.position, new Vector2(Main.rand.Next(-3, 4), Main.rand.Next(-3, 4)), GoreHand);
					Gore.NewGore(entitySource, NPC.position, new Vector2(Main.rand.Next(-3, 4), Main.rand.Next(-3, 4)), GoreHand);
					Gore.NewGore(entitySource, NPC.position, new Vector2(Main.rand.Next(-3, 4), Main.rand.Next(-3, 4)), GoreLeg);
					Gore.NewGore(entitySource, NPC.position, new Vector2(Main.rand.Next(-3, 4), Main.rand.Next(-3, 4)), GoreLeg);
				}

				SoundEngine.PlaySound(SoundID.NPCDeath1, NPC.Center);
    		}
		}
	}

	public class ExampleTravelingMerchantProfile : ITownNPCProfile
	{
		public int RollVariation() => 0;
		public string GetNameForVariant(NPC npc) => npc.getNewNPCName();

		public Asset<Texture2D> GetTextureNPCShouldUse(NPC npc) 
		{
			if (npc.IsABestiaryIconDummy && !npc.ForcePartyHatOn)
				return ModContent.Request<Texture2D>("XDContentMod/Content/NPCs/StarMerchantNPC");

			if (npc.altTexture == 1)
				return ModContent.Request<Texture2D>("XDContentMod/Content/NPCs/StarMerchantNPC_Alt");

			return ModContent.Request<Texture2D>("XDContentMod/Content/NPCs/StarMerchantNPC");
		}

		public int GetHeadTextureIndex(NPC npc) => ModContent.GetModHeadSlot("XDContentMod/Content/NPCs/StarMerchantNPC_Head");
	}
}