using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PotionSellerReborn.NPCs
{
	[AutoloadHead]
	// ReSharper disable once UnusedMember.Global
	internal class PotionSeller : ModNPC
	{
		private static int _currentShop;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Potion Seller");

			Main.npcFrameCount[npc.type] = 25;

			NPCID.Sets.ExtraFramesCount[npc.type] = 9;
			NPCID.Sets.AttackFrameCount[npc.type] = 4;
			NPCID.Sets.DangerDetectRange[npc.type] = 700;
			NPCID.Sets.AttackType[npc.type] = 0;
			NPCID.Sets.AttackTime[npc.type] = 90;
			NPCID.Sets.AttackAverageChance[npc.type] = 30;
			NPCID.Sets.HatOffsetY[npc.type] = 4;
		}

		public override void SetDefaults()
		{
			npc.townNPC = true;
			npc.friendly = true;

			npc.width = 18;
			npc.height = 40;
			npc.aiStyle = 7;

			npc.damage = 10;
			npc.defense = 15;
			npc.lifeMax = 250;

			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;

			npc.knockBackResist = 0.5f;
			animationType = 22;
		}

		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
		{
			return NPC.downedBoss1;
		}

		public override string TownNPCName()
		{
			switch (WorldGen.genRand.Next(4))
			{
				case 0:
					return "Richard";
				case 1:
					return "Bernard";
				case 2:
					return "Beevis";
				case 3:
					return "Popo";
				default:
					return "Walter";
			}
		}

		public override string GetChat()
		{
			switch (Main.rand.Next(8))
			{
				case 0:
					return "I'd advise you against the mental and physical health risks of this, but at the same time I'm poor, so I won't.";
				case 1:
					return "You actually drink this stuff? You know half of these have liquidized fish in then, right?";
				case 2:
					return "Cocaine is one hell of a drug.";
				case 3:
					return "Try the juice that makes you give me money.";
				case 4:
					return "Please be careful, I broke some glass in one of these batches.";
				case 5:
					return "Walter White? That's a name I haven't heard in years.";
				case 6:
					return "Sure potions are cool and all, but have you tried pizza?";
				case 7:
					return "You can't hold me responsible for anything you do while under the effects of this";
				default:
					return "Don't tell anyone where you got this from, okay?";
			}
		}

		public override void SetChatButtons(ref string button, ref string button2)
		{
			button = ShopManager.GetShopName(_currentShop);
			button2 = ShopManager.ShopCount > 1 ? "Cycle Shop" : "";
		}

		public override void OnChatButtonClicked(bool firstButton, ref bool shop)
		{
			if (firstButton)
				shop = true;
			else
				CycleShop();
		}

		private void CycleShop()
		{
			_currentShop++;

			if (_currentShop >= ShopManager.ShopCount)
				_currentShop = 0;
		}

		public override void SetupShop(Chest shop, ref int nextSlot)
		{
			var items = ShopManager.GetShopItems(_currentShop);

			foreach (var item in items)
			{
				if (!item.CanSell())
					continue;

				int id = item.ItemID;
				int price = item.Price.Total;

				shop.item[nextSlot].SetDefaults(id);
				shop.item[nextSlot].shopCustomPrice = price;
				nextSlot++;
			}
		}

		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			damage = 10;
			knockback = 1f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			cooldown = 30;
			randExtraCooldown = 30;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
		{
			projType = 510;
			attackDelay = 4;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
			multiplier = 7f;
			randomOffset = 2f;
		}
	}
}