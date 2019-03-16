using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PotionSellerReborn
{
	// ReSharper disable once UnusedMember.Global
	internal class PotionSellerMod : Mod
	{
	    internal static Mod CalamityInstance;

		public override void PostSetupContent()
		{
			// Do this in PostSetupContent to ensure other mods are already loaded
			InitShops();
		}

		private void InitShops()
		{
			InitVanillaShop();

		    if (ModLoader.Mods.Any(i => i.Name == "CalamityMod"))
		    {
		        CalamityInstance = ModLoader.Mods.Single(i => i.Name == "CalamityMod");
                InitCalamityShop();
            }

		    List<Mod> modWithPotion = ModLoader.Mods.Where(i => i.GetInternalItemList().Any(j => j.item.potion)).ToList();

		    foreach (var mod in modWithPotion)
		    {
		        if (mod.Name == "CalamityMod" || mod.Name == "TUA")
		        {
		            continue;
                }

		        List<ShopItem> modShopItems = new List<ShopItem>();
		        List<ModItem> potions = mod.GetInternalItemList().Where(i => i.item.potion).ToList();

		        foreach (var potion in potions)
		        {
		            modShopItems.Add(new ShopItem(potion.item.type, new Currency((int) (10000 + potion.item.value * 1.5f)), IsHardMode));
		        }
                ShopManager.AddShop(mod.Name, mod.DisplayName + " Shop", modShopItems);
		    }
		}

		bool IsHardMode() => Main.hardMode;

		bool IsBossDowned3() => NPC.downedBoss3;

		private void InitVanillaShop()
		{
			List<ShopItem> vanilla = new List<ShopItem>();
			
			vanilla.Add(new ShopItem(
				ItemID.AmmoReservationPotion,
				new Currency(0, 0, 75)
			));

			vanilla.Add(new ShopItem(
				ItemID.ArcheryPotion,
				new Currency(0, 2)
			));

			vanilla.Add(new ShopItem(
				ItemID.BattlePotion,
				new Currency(0, 3)
			));

			vanilla.Add(new ShopItem(
				ItemID.BuilderPotion,
				new Currency(0, 0, 25)
			));

			vanilla.Add(new ShopItem(
				ItemID.CalmingPotion,
				new Currency(0, 1)
			));

			vanilla.Add(new ShopItem(
				ItemID.CratePotion,
				new Currency(0, 2)
			));

			vanilla.Add(new ShopItem(
				ItemID.EndurancePotion,
				new Currency(0, 2, 50),
				IsHardMode
			));

			vanilla.Add(new ShopItem(
				ItemID.FeatherfallPotion,
				new Currency(0, 0, 50)
			));

			vanilla.Add(new ShopItem(
				ItemID.FishingPotion,
				new Currency(0, 2)
			));

			vanilla.Add(new ShopItem(
				ItemID.FlipperPotion,
				new Currency(0, 0, 75)
			));

			vanilla.Add(new ShopItem(
				ItemID.GenderChangePotion,
				new Currency(0, 0, 5)
			));

			vanilla.Add(new ShopItem(
				ItemID.GillsPotion,
				new Currency(0, 1)
			));

			vanilla.Add(new ShopItem(
				ItemID.GravitationPotion,
				new Currency(0, 3),
				IsBossDowned3
			));

			vanilla.Add(new ShopItem(
				ItemID.HeartreachPotion,
				new Currency(0, 1, 25),
				IsBossDowned3
			));

			vanilla.Add(new ShopItem(
				ItemID.HunterPotion,
				new Currency(0, 1)
			));

			vanilla.Add(new ShopItem(
				ItemID.InfernoPotion,
				new Currency(0, 1)
			));

			vanilla.Add(new ShopItem(
				ItemID.InvisibilityPotion,
				new Currency(0, 0, 50)
			));

			vanilla.Add(new ShopItem(
				ItemID.IronskinPotion,
				new Currency(0, 0, 75)
			));

			vanilla.Add(new ShopItem(
				ItemID.LifeforcePotion,
				new Currency(0, 4),
				IsHardMode
			));

			vanilla.Add(new ShopItem(
				ItemID.MagicPowerPotion,
				new Currency(0, 2),
				IsHardMode
			));

			vanilla.Add(new ShopItem(
				ItemID.ManaRegenerationPotion,
				new Currency(0, 1, 25)
			));

			vanilla.Add(new ShopItem(
				ItemID.MiningPotion,
				new Currency(0, 1)
			));

			vanilla.Add(new ShopItem(
				ItemID.NightOwlPotion,
				new Currency(0, 0, 25)
			));

			vanilla.Add(new ShopItem(
				ItemID.ObsidianSkinPotion,
				new Currency(0, 2),
				IsBossDowned3
			));

			vanilla.Add(new ShopItem(
				ItemID.RagePotion,
				new Currency(0, 3, 25),
				IsHardMode
			));

			vanilla.Add(new ShopItem(
				ItemID.RegenerationPotion,
				new Currency(0, 0, 75)
			));

			vanilla.Add(new ShopItem(
				ItemID.ShinePotion,
				new Currency(0, 0, 75)
			));

			vanilla.Add(new ShopItem(
				ItemID.SonarPotion,
				new Currency(0, 2)
			));

			vanilla.Add(new ShopItem(
				ItemID.SpelunkerPotion,
				new Currency(0, 5)
			));

			vanilla.Add(new ShopItem(
				ItemID.SummoningPotion,
				new Currency(0, 1, 25)
			));

			vanilla.Add(new ShopItem(
				ItemID.SwiftnessPotion,
				new Currency(0, 0, 75)
			));

			vanilla.Add(new ShopItem(
				ItemID.TeleportationPotion,
				new Currency(0, 3),
				IsBossDowned3
			));

			vanilla.Add(new ShopItem(
				ItemID.ThornsPotion,
				new Currency(0, 0, 75)
			));

			vanilla.Add(new ShopItem(
				ItemID.TitanPotion,
				new Currency(0, 0, 75)
			));

			vanilla.Add(new ShopItem(
				ItemID.TrapsightPotion,
				new Currency(0, 1)
			));

			vanilla.Add(new ShopItem(
				ItemID.WarmthPotion,
				new Currency(0, 2)
			));

			vanilla.Add(new ShopItem(
				ItemID.WaterWalkingPotion,
				new Currency(0, 1)
			));

			vanilla.Add(new ShopItem(
				ItemID.WormholePotion,
				new Currency(0, 3)
			));

			vanilla.Add(new ShopItem(
				ItemID.WrathPotion,
				new Currency(0, 3, 25),
				IsHardMode
			));

			ShopManager.AddShop("vanilla", "Vanilla Potions", vanilla);
		}

		private void InitCalamityShop()
		{
			List<ShopItem> calamity = new List<ShopItem>();

			calamity.Add(new ShopItem(
				ModLoader.GetMod("CalamityMod").ItemType("AnechoicCoating"),
				new Currency(0, 2),
				IsHardMode
			));

			calamity.Add(new ShopItem(
				ModLoader.GetMod("CalamityMod").ItemType("CadencePotion"),
				new Currency(0, 10),
				IsHardMode
			));

			calamity.Add(new ShopItem(
				ModLoader.GetMod("CalamityMod").ItemType("CalamitasBrew"),
				new Currency(0, 3),
				IsHardMode
			));

			calamity.Add(new ShopItem(
				ModLoader.GetMod("CalamityMod").ItemType("CalamitasBrew"),
				new Currency(0, 3),
				IsHardMode
			));

			calamity.Add(new ShopItem(
				ModLoader.GetMod("CalamityMod").ItemType("FabsolsVodka"),
				new Currency(0, 4),
				IsHardMode
			));

			calamity.Add(new ShopItem(
				ModLoader.GetMod("CalamityMod").ItemType("PotionofOmniscience"),
				new Currency(0, 9),
				IsHardMode
			));

			calamity.Add(new ShopItem(
				ModLoader.GetMod("CalamityMod").ItemType("TitanScalePotion"),
				new Currency(0, 3, 50),
				IsHardMode
			));

			calamity.Add(new ShopItem(
				ModLoader.GetMod("CalamityMod").ItemType("YharimsStimulants"),
				new Currency(0, 15),
				IsHardMode
			));

			calamity.Add(new ShopItem(
				ModLoader.GetMod("CalamityMod").ItemType("ZergPotion"),
				new Currency(0, 15),
				IsHardMode
			));

			calamity.Add(new ShopItem(
				ModLoader.GetMod("CalamityMod").ItemType("ZenPotion"),
				new Currency(0, 15),
				IsHardMode
			));

			ShopManager.AddShop("calamity", "Calamity Potions", calamity);
		}
	}
}
