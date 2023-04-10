using XDContentMod.Content.Items.Mounts;
using XDContentMod.Content.Items.Pets;
using XDContentMod.Content.Items.Placeable;
using XDContentMod.Content.Items.Vanity;
using XDContentMod.Content.Items.Weapons;
using XDContentMod.Content.Items.Weapons.Melee;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.Chat;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.Utilities;
using Terraria.Audio;

namespace XDContentMod.Content.NPCs
{
	[AutoloadHead]
	class StarMerchantNPC : ModNPC
	{
		public const double despawnTime = 48600.0;
		public static double spawnTime = 13500;
		public static StarMerchantShop Shop;

		public List<Item> shopItems;

		private static int ShimmerHeadIndex;
		private static Profiles.StackedNPCProfile NPCProfile;

		public override bool PreAI() 
		{
			if ((!Main.dayTime || Main.time >= despawnTime) && !IsNpcOnscreen(NPC.Center))
			{
				if (Main.netMode == NetmodeID.SinglePlayer) Main.NewText(Language.GetTextValue("LegacyMisc.35", NPC.FullName), 50, 125, 255);
				else ChatHelper.BroadcastChatMessage(NetworkText.FromKey("LegacyMisc.35", NPC.GetFullNetName()), new Color(50, 125, 255));
				NPC.active = false;
				NPC.netSkip = -1;
				NPC.life = 0;
				return false;
			}

			return true;
		}
		public override void AddShops() {
			Shop = new StarMerchantShop(NPC.type);

			Shop.AddPool("Melee Weapons", slots: 1)
				.Add<HeartbeatBroadsword>()
				.Add<TapTapBroadsword>()
				.Add<KFCChickenDrumstick>();

			Shop.AddPool("Disc Weapons", slots: 1)
				.Add<BaiduTiebaHuajiDisc>()
				.Add<HupuDisc>()
				.Add<iFlytekDisc>()
				.Add<LOOKDisc>()
				.Add<PururuDisc>();

			Shop.AddPool("Pets", slots: 1)
				.Add<Basketball>()
				.Add<FriedChickenNugget>()
				.Add<PururuCharger>()
				.Add<Xiaokuai>()
				.Add<Xiaoliu>();

			Shop.AddPool("Leaf Pets", slots: 1)
				.Add<Leaf>()
				.Add<ToadQuack2R>()
				.Add<ToadQuack2W>();

			Shop.AddPool("Mounts", slots: 1)
				.Add<ConvertibleKeys>()
				.Add<DiDiBikeKeys>()
				.Add<DiDiCarKeys>()
				.Add<KFCDeliveryScooterKeys>()
				.Add<TapTapMinivanKeys>();

			Shop.AddPool("Paintings", slots: 4)
				.Add<BirthdayCake>()
				.Add<ColorfulBalloonsStockPhoto>()
				.Add<GetThePartyStarted>()
				.Add<PururuPortrait>()
				.Add<TapTapGroupPortrait>()
				.Add<TararaPortrait>()
				.Add<SmallHeartbeatTownscapeOilPainting>()
				.Add<HeartbeatOilPainting>()
				.Add<LargeHeartbeatTownscapeOilPainting>()
				.Add<SmallDouYuOilPainting>()
				.Add<MediumDouYuOilPainting>()
				.Add<LargeDouYuOilPainting>()
				.Add<KFCBurgerAd>()
				.Add<KFCChickenDrumstickAd>()
				.Add<KFCFamilyBucketAd>()
				.Add<SmallHuyaOilPainting>()
				.Add<MediumHuyaOilPainting>()
				.Add<LargeHuyaOilPainting>()
				.Add<RockPotato>()
				.Add<LightPotato>()
				.Add<Potataria>()
				.Add<AcFunOilPainting>()
				.Add<JinyiCinemasPopcornPoster>()
				.Add<SeiyuuchanSupportPoster>();

			Shop.Add<KFCChair>();
			Shop.Add<KFCWorkBench>();
			Shop.Add<KFCBar>();


			Shop.AddPool("Vanity Sets", slots: 6)
				.Add<ColonelsMask>(Condition.MoonPhaseFull)
				.Add<ColonelsTuxedoShirt>(Condition.MoonPhaseFull)
				.Add<ColonelsTuxedoPants>(Condition.MoonPhaseFull)

				.Add<CuteBrownWig>(Condition.MoonPhaseWaningGibbous)
				.Add<SeifukuShirt>(Condition.MoonPhaseWaningGibbous)
				.Add<SeifukuShoes>(Condition.MoonPhaseWaningGibbous)

				.Add<HeartbeatOrangePonytail>(Condition.MoonPhaseThirdQuarter)
				.Add<HeartbeatOrangeDress>(Condition.MoonPhaseThirdQuarter)
				.Add<HeartbeatOrangeShoes>(Condition.MoonPhaseThirdQuarter)

				.Add<HeartbeatOrangeWig>(Condition.MoonPhaseThirdQuarter)
				.Add<HeartbeatOrangeTuxedoShirt>(Condition.MoonPhaseThirdQuarter)
				.Add<HeartbeatOrangeTuxedoPants>(Condition.MoonPhaseThirdQuarter)

				.Add<BCYCatEars>(Condition.MoonPhaseWaningCrescent)
				.Add<BCYCosplayDress>(Condition.MoonPhaseWaningCrescent)
				.Add<BCYCosplayShoes>(Condition.MoonPhaseWaningCrescent)

				.Add<TikTokNoteHat>(Condition.MoonPhaseNew)
				.Add<TikTokTorso>(Condition.MoonPhaseNew)
				.Add<TikTokPants>(Condition.MoonPhaseNew)

				.Add<DogMask>(Condition.MoonPhaseNew)
				.Add<DogShirt>(Condition.MoonPhaseNew)
				.Add<DogPants>(Condition.MoonPhaseNew)

				.Add<TararaPonytail>(Condition.MoonPhaseWaxingCrescent)
				.Add<TararaDress>(Condition.MoonPhaseWaxingCrescent)
				.Add<TararaShoes>(Condition.MoonPhaseWaxingCrescent)

				.Add<iQIYIMechaHelmet>(Condition.MoonPhaseFirstQuarter)
				.Add<iQIYIMechaTorso>(Condition.MoonPhaseFirstQuarter)
				.Add<iQIYIMechaPants>(Condition.MoonPhaseFirstQuarter)

				.Add<ExpeditionerHat>(Condition.MoonPhaseWaxingGibbous)
				.Add<ExpeditionerShirt>(Condition.MoonPhaseWaxingGibbous)
				.Add<ExpeditionerPants>(Condition.MoonPhaseWaxingGibbous)

				.Add<ChengXinYouXuanHat>(Condition.MoonPhaseWaxingGibbous)
				.Add<ChengXinYouXuanShirt>(Condition.MoonPhaseWaxingGibbous)
				.Add<ChengXinYouXuanPants>(Condition.MoonPhaseWaxingGibbous);

			Shop.Register();
		}

		public static void UpdateTravelingMerchant() 
		{
			bool travelerIsThere = (NPC.FindFirstNPC(ModContent.NPCType<StarMerchantNPC>()) != -1);
			if (Main.dayTime && Main.time == 0) 
			{
				if (!travelerIsThere && Main.rand.NextBool(5)) 
				{
					spawnTime = GetRandomSpawnTime(0, 27000);
				}
				else {
					spawnTime = double.MaxValue;
				}
			}

			if (!travelerIsThere && CanSpawnNow()) 
			{
				int newTraveler = NPC.NewNPC(Terraria.Entity.GetSource_TownSpawn(), Main.spawnTileX * 16, Main.spawnTileY * 16, ModContent.NPCType<StarMerchantNPC>(), 1); // Spawning at the world spawn
				NPC traveler = Main.npc[newTraveler];
				traveler.homeless = true;
				traveler.direction = Main.spawnTileX >= WorldGen.bestX ? -1 : 1;
				traveler.netUpdate = true;

				spawnTime = double.MaxValue;

				if (Main.netMode == NetmodeID.SinglePlayer) Main.NewText(Language.GetTextValue("Announcement.HasArrived", traveler.FullName), 50, 125, 255);
				else ChatHelper.BroadcastChatMessage(NetworkText.FromKey("Announcement.HasArrived", traveler.GetFullNetName()), new Color(50, 125, 255));
			}
		}

		private static bool CanSpawnNow() 
		{
			if (Main.IsFastForwardingTime())
				return false;

			return Main.dayTime && Main.time >= spawnTime && Main.time < despawnTime;
		}

		private static bool IsNpcOnscreen(Vector2 center) 
		{
			int w = NPC.sWidth + NPC.safeRangeX * 2;
			int h = NPC.sHeight + NPC.safeRangeY * 2;
			Rectangle npcScreenRect = new Rectangle((int)center.X - w / 2, (int)center.Y - h / 2, w, h);
			foreach (Player player in Main.player) 
			{
				if (player.active && player.getRect().Intersects(npcScreenRect)) return true;
			}
			return false;
		}

		public static double GetRandomSpawnTime(double minTime, double maxTime) 
		{
			return (maxTime - minTime) * Main.rand.NextDouble() + minTime;
		}

		public override void Load() {
			ShimmerHeadIndex = Mod.AddNPCHeadTexture(Type, Texture + "_Shimmer_Head");
		}

		public override void SetStaticDefaults() 
		{
			Main.npcFrameCount[NPC.type] = 25;
			NPCID.Sets.ExtraFramesCount[NPC.type] = 9;
			NPCID.Sets.AttackFrameCount[NPC.type] = 4;
			NPCID.Sets.DangerDetectRange[NPC.type] = 700;
			NPCID.Sets.AttackType[NPC.type] = 0;
			NPCID.Sets.AttackTime[NPC.type] = 90;
			NPCID.Sets.AttackAverageChance[NPC.type] = 30;
			NPCID.Sets.HatOffsetY[NPC.type] = 2;
			NPCID.Sets.ShimmerTownTransform[Type] = true;

			NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0) 
			{
				Velocity = 1f,
				Direction = -1
			};

			NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);

			NPCProfile = new Profiles.StackedNPCProfile(
				new Profiles.DefaultNPCProfile(Texture, NPCHeadLoader.GetHeadSlot(HeadTexture), Texture + "_Party"),
				new Profiles.DefaultNPCProfile(Texture + "_Shimmer", ShimmerHeadIndex)
			);
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
			TownNPCStayingHomeless = true;
		}

		public override void OnSpawn(IEntitySource source) 
		{
			shopItems = Shop.GenerateNewInventoryList();
		}

		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] 
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

		public override bool CanTownNPCSpawn(int numTownNPCs)
		{
			return false;
		}

		public override ITownNPCProfile TownNPCProfile() 
		{
			return NPCProfile;
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

			if (Main.LocalPlayer.TalkNPC?.IsShimmerVariant == false)
			{
				chat.Add(Language.GetTextValue("Mods.XDContentMod.Dialogue.StarMerchant.StarMerchantNoShimmerDialogue1"));
			}
			else
			{
				chat.Add(Language.GetTextValue("Mods.XDContentMod.Dialogue.StarMerchant.StarMerchantShimmerDialogue1"));
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

			string dialogueLine = chat;
			return dialogueLine;
		}

		public override void SetChatButtons(ref string button, ref string button2) 
		{
			button = Language.GetTextValue("LegacyInterface.28");
			Main.LocalPlayer.currentShoppingSettings.HappinessReport = "";
		}

		public override void OnChatButtonClicked(bool firstButton, ref string shop) 
		{
			if (firstButton) 
			{
				shop = Shop.Name;
			}
		}

		public override void AI() 
		{
			NPC.homeless = true;
		}

		public override void ModifyNPCLoot(NPCLoot npcLoot) 
		{
			npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<StarMerchantHat>()));
		}

		public override void TownNPCAttackStrength(ref int damage, ref float knockback) {
			damage = 20;
			knockback = 4f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown) {
			cooldown = 15;
			randExtraCooldown = 8;
		}

		public override void TownNPCAttackSwing(ref int itemWidth, ref int itemHeight) {
			itemWidth = itemHeight = 40;
		}

		public override void DrawTownAttackSwing(ref Texture2D item, ref Rectangle itemFrame, ref int itemSize, ref float scale, ref Vector2 offset) {
			Main.GetItemDrawFrame(ModContent.ItemType<TapTapBroadsword>(), out item, out itemFrame);
			itemSize = 40;
			if (NPC.ai[1] > NPCID.Sets.AttackTime[NPC.type] * 0.66f) {
				offset.Y = 12f;
			}
		}

		public override void HitEffect(NPC.HitInfo hit)
   		{
			if (Main.netMode == NetmodeID.Server) 
			{
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

	public class StarMerchantShop : AbstractNPCShop
	{
		public new record Entry(Item Item, List<Condition> Conditions) : AbstractNPCShop.Entry
		{
			IEnumerable<Condition> AbstractNPCShop.Entry.Conditions => Conditions;

			public bool Disabled { get; private set; }

			public Entry Disable() 
			{
				Disabled = true;
				return this;
			}

			public bool ConditionsMet() => Conditions.All(c => c.IsMet());
		}

		public record Pool(string Name, int Slots, List<Entry> Entries)
		{
			public Pool Add(Item item, params Condition[] conditions) 
			{
				Entries.Add(new Entry(item, conditions.ToList()));
				return this;
			}

			public Pool Add<T>(params Condition[] conditions) where T : ModItem => Add(ModContent.ItemType<T>(), conditions);
			public Pool Add(int item, params Condition[] conditions) => Add(ContentSamples.ItemsByType[item], conditions);

			public IEnumerable<Item> PickItems() 
			{
				var list = Entries.Where(e => !e.Disabled && e.ConditionsMet()).ToList();
				for (int i = 0; i < Slots; i++) {
					if (list.Count == 0)
						break;

					int k = Main.rand.Next(list.Count);
					yield return list[k].Item;

					list.RemoveAt(k);
				}
			}
		}

		public List<Pool> Pools { get; } = new();

		public StarMerchantShop(int npcType) : base(npcType) { }

		public override IEnumerable<Entry> ActiveEntries => Pools.SelectMany(p => p.Entries).Where(e => !e.Disabled);

		public Pool AddPool(string name, int slots) {
			var pool = new Pool(name, slots, new List<Entry>());
			Pools.Add(pool);
			return pool;
		}

		public void Add(Item item, params Condition[] conditions) => AddPool(item.ModItem?.FullName ?? $"Terraria/{item.type}", slots: 1).Add(item, conditions);
		public void Add<T>(params Condition[] conditions) where T : ModItem => Add(ModContent.ItemType<T>(), conditions);
		public void Add(int item, params Condition[] conditions) => Add(ContentSamples.ItemsByType[item], conditions);

		public List<Item> GenerateNewInventoryList() {
			var items = new List<Item>();
			foreach (var pool in Pools) {
				items.AddRange(pool.PickItems());
			}
			return items;
		}

		public override void FillShop(ICollection<Item> items, NPC npc) {
			foreach (var item in ((StarMerchantNPC)npc.ModNPC).shopItems) {
				items.Add(item.Clone());
			}
		}

		public override void FillShop(Item[] items, NPC npc, out bool overflow) {
			overflow = false;
			int i = 0;
			foreach (var item in ((StarMerchantNPC)npc.ModNPC).shopItems) {

				if (i == items.Length - 1) {
					overflow = true;
					return;
				}

				items[i++] = item.Clone();
			}
		}
	}
}





/*	public class ExampleTravelingMerchantProfile : ITownNPCProfile
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
*/