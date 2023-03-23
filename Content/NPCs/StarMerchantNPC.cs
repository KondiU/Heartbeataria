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
using Terraria.Chat;
using Terraria.GameContent;
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
		public const double despawnTime = 0.0;

		// the time of day the traveler will spawn (double.MaxValue for no spawn)
		// saved and loaded with the world in TravelingMerchantSystem
		public static double spawnTime = 54000.0;

		// The list of items in the traveler's shop. Saved with the world and set when the traveler spawns
		public List<Item> shopItems = new List<Item>();

		public override bool PreAI() {
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

		public static void UpdateTravelingMerchant() {
			bool travelerIsThere = (NPC.FindFirstNPC(ModContent.NPCType<StarMerchantNPC>()) != -1); // Find a Merchant if there's one spawned in the world

			// Main.time is set to 0 each morning, and only for one update. Sundialling will never skip past time 0 so this is the place for 'on new day' code
			if (Main.dayTime && Main.time == 0) {
				// insert code here to change the spawn chance based on other conditions (say, npcs which have arrived, or milestones the player has passed)
				// You can also add a day counter here to prevent the merchant from possibly spawning multiple days in a row.

				// NPC won't spawn today if it stayed all night
				if (!travelerIsThere && Main.rand.NextBool(4)) { // 4 = 25% Chance
																// Here we can make it so the NPC doesnt spawn at the EXACT same time every time it does spawn
					spawnTime = GetRandomSpawnTime(51300, 54000); // minTime = 6:00am, maxTime = 7:30am
				}
				else {
					spawnTime = double.MaxValue; // no spawn today
				}
			}

			// Spawn the traveler if the spawn conditions are met (time of day, no events, no sundial)
			if (!travelerIsThere && CanSpawnNow()) {
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

		private static bool CanSpawnNow() {
			// can't spawn if any events are running
			if (Main.eclipse || Main.invasionType > 0 && Main.invasionDelay == 0 && Main.invasionSize > 0)
				return false;

			// can't spawn if the sundial is active
			if (Main.fastForwardTime)
				return false;

			// can spawn if daytime, and between the spawn and despawn times
			return Main.dayTime && Main.time >= spawnTime && Main.time < despawnTime;
		}

		private static bool IsNpcOnscreen(Vector2 center) {
			int w = NPC.sWidth + NPC.safeRangeX * 2;
			int h = NPC.sHeight + NPC.safeRangeY * 2;
			Rectangle npcScreenRect = new Rectangle((int)center.X - w / 2, (int)center.Y - h / 2, w, h);
			foreach (Player player in Main.player) {
				// If any player is close enough to the traveling merchant, it will prevent the npc from despawning
				if (player.active && player.getRect().Intersects(npcScreenRect)) return true;
			}
			return false;
		}

		public static double GetRandomSpawnTime(double minTime, double maxTime) {
			// A simple formula to get a random time between two chosen times
			return (maxTime - minTime) * Main.rand.NextDouble() + minTime;
		}

		public void CreateNewShop() {
			// create a list of item ids
			var itemIds = new List<int>();

			// For each slot we add a switch case to determine what should go in that slot
			switch (Main.rand.Next(3)) { //SWORDS
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

			switch (Main.rand.Next(5)) { //DISCS
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

			switch (Main.rand.Next(5)) { //PETS
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

			switch (Main.rand.Next(3)) { //LEAF PETS
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

			switch (Main.rand.Next(5)) { //MOUNTS
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

			switch (Main.rand.Next(1)) { 
				default:
					itemIds.Add(ModContent.ItemType<KFCChair>());
					break;
			}

			switch (Main.rand.Next(1)) { 
				default:
					itemIds.Add(ModContent.ItemType<KFCWorkBench>());
					break;
			}

			switch (Main.rand.Next(1)) { 
				default:
					itemIds.Add(ModContent.ItemType<KFCBar>());
					break;
			}
			

			switch (Main.rand.Next(6)) { //PAINTINGS - SLOT 1
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

			switch (Main.rand.Next(6)) { //PAINTINGS - SLOT 2
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

			switch (Main.rand.Next(6)) { //PAINTINGS - SLOT 3
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

			switch (Main.rand.Next(6)) { //PAINTINGS - SLOT 4
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



				//ADD VANITY SETS




			// convert to a list of items
			shopItems = new List<Item>();
			foreach (int itemId in itemIds) {
				Item item = new Item();
				item.SetDefaults(itemId);
				shopItems.Add(item);
			}
		}

		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Star Merchant");
			Main.npcFrameCount[NPC.type] = 25;
			NPCID.Sets.ExtraFramesCount[NPC.type] = 9;
			NPCID.Sets.AttackFrameCount[NPC.type] = 4;
			NPCID.Sets.DangerDetectRange[NPC.type] = 700;
			NPCID.Sets.AttackType[NPC.type] = 0;
			NPCID.Sets.AttackTime[NPC.type] = 90;
			NPCID.Sets.AttackAverageChance[NPC.type] = 30;
			NPCID.Sets.HatOffsetY[NPC.type] = 2;
		}

		public override void SetDefaults() {
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
            bestiaryEntry.Info.AddRange(new Terraria.GameContent.Bestiary.IBestiaryInfoElement[] {
                Terraria.GameContent.Bestiary.BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
                new Terraria.GameContent.Bestiary.FlavorTextBestiaryInfoElement("There's very little info about the Star Merchant. Some say they came from space, others that they live in China. We're not even sure about their gender, but it's pretty clear that they love to sell some unique items in their shop!"),
            });
        }

		public override void SaveData(TagCompound tag) {
			tag["itemIds"] = shopItems;
		}

		public override void LoadData(TagCompound tag) {
			shopItems = tag.Get<List<Item>>("shopItems");
		}

/*
		public override void HitEffect(int hitDirection, double damage) {
			int num = NPC.life > 0 ? 1 : 5;
			for (int k = 0; k < num; k++) {
				Dust.NewDust(NPC.position, NPC.width, NPC.height, ModContent.DustType<Sparkle>());
			}
		}
*/

		public override bool CanTownNPCSpawn(int numTownNPCs, int money) {
			return false; // This should always be false, because we spawn in the Traveling Merchant manually
		}

		public override ITownNPCProfile TownNPCProfile() {
			return new ExampleTravelingMerchantProfile();
		}

		public override List<string> SetNPCNameList() {
			return new List<string>() {
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

		public override string GetChat() {
			WeightedRandom<string> chat = new WeightedRandom<string>();
			
			int mechanic = NPC.FindFirstNPC(NPCID.Mechanic);
			if (mechanic >= 0) {
				chat.Add(Language.GetTextValue("Mods.XDContentMod.Dialogue.StarMerchant.StarMerchantMechanicDialogue", Main.npc[mechanic].GivenName));
			}
			
			chat.Add(Language.GetTextValue("Mods.XDContentMod.Dialogue.StarMerchant.StarMerchantDialogue1"));
			chat.Add(Language.GetTextValue("Mods.XDContentMod.Dialogue.StarMerchant.StarMerchantDialogue2"));
			chat.Add(Language.GetTextValue("Mods.XDContentMod.Dialogue.StarMerchant.StarMerchantDialogue3"));
			chat.Add(Language.GetTextValue("Mods.XDContentMod.Dialogue.StarMerchant.StarMerchantDialogue4"));
			chat.Add(Language.GetTextValue("Mods.XDContentMod.Dialogue.StarMerchant.StarMerchantDialogue5"));

			string dialogueLine = chat;
			return dialogueLine;
		}
		

		public override void SetChatButtons(ref string button, ref string button2) {
			button = Language.GetTextValue("LegacyInterface.28");
			Main.LocalPlayer.currentShoppingSettings.HappinessReport = "";
		}

		public override void OnChatButtonClicked(bool firstButton, ref bool shop) {
			if (firstButton) {
				shop = true;
			}
		}

		public override void SetupShop(Chest shop, ref int nextSlot) {
			foreach (Item item in shopItems) {
				// We don't want "empty" items and unloaded items to appear
				if (item == null || item.type == ItemID.None)
					continue;

				shop.item[nextSlot].SetDefaults(item.type);
				nextSlot++;
			}
		}

		public override void AI() {
			NPC.homeless = true; // Make sure it stays homeless
		}

		public override void ModifyNPCLoot(NPCLoot npcLoot) {
			npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<StarMerchantHat>()));
		}

		public override void HitEffect(int hitDirection, double damage)
   		{
        	if (NPC.life <= 0)
       		{
         		Gore.NewGore(NPC.GetSource_FromAI(), NPC.position, NPC.velocity, Mod.Find<ModGore>("StarMerchantNPC").Type, 1f);
        		Gore.NewGore(NPC.GetSource_FromAI(), NPC.position, NPC.velocity, Mod.Find<ModGore>("StarMerchantNPC2").Type, 1f);
            	Gore.NewGore(NPC.GetSource_FromAI(), NPC.position, NPC.velocity, Mod.Find<ModGore>("StarMerchantNPC3").Type, 1f);
            	Gore.NewGore(NPC.GetSource_FromAI(), NPC.position, NPC.velocity, Mod.Find<ModGore>("StarMerchantNPC4").Type, 1f);
        	}
    	}
	}

	public class ExampleTravelingMerchantProfile : ITownNPCProfile
	{
		public int RollVariation() => 0;
		public string GetNameForVariant(NPC npc) => npc.getNewNPCName();

		public Asset<Texture2D> GetTextureNPCShouldUse(NPC npc) {
			if (npc.IsABestiaryIconDummy && !npc.ForcePartyHatOn)
				return ModContent.Request<Texture2D>("XDContentMod/Content/NPCs/StarMerchantNPC");

			if (npc.altTexture == 1)
				return ModContent.Request<Texture2D>("XDContentMod/Content/NPCs/StarMerchantNPC_Alt");

			return ModContent.Request<Texture2D>("XDContentMod/Content/NPCs/StarMerchantNPC");
		}

		public int GetHeadTextureIndex(NPC npc) => ModContent.GetModHeadSlot("XDContentMod/Content/NPCs/StarMerchantNPC_Head");
	}
}