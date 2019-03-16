using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotionSellerReborn
{
	public static class ShopManager
	{
		private static readonly Dictionary<string, List<ShopItem>> Shops = new Dictionary<string, List<ShopItem>>();
		private static readonly Dictionary<string, string> ShopIDToNameMap = new Dictionary<string, string>();

		public static int ShopCount => Shops.Count;

		public static void AddShop(string id, string name, List<ShopItem> items)
		{
			if (ContainsShop(id))
				return;

			ShopIDToNameMap.Add(id, name);
			Shops.Add(id, items);
		}

		public static void RemoveShop(string id)
		{
			if (ContainsShop(id))
			{
				Shops.Remove(id);
				ShopIDToNameMap.Remove(id);
			}
		}

		public static bool ContainsShop(string id)
		{
			return Shops.ContainsKey(id) && ShopIDToNameMap.ContainsKey(id);
		}

		public static string GetShopID(int index)
		{
			return Shops.Keys.ToArray()[index];
		}

		public static string GetShopName(string id)
		{
			return ContainsShop(id) ? ShopIDToNameMap[id] : null;
		}

		public static string GetShopName(int index)
		{
			return GetShopName(GetShopID(index));
		}

		public static List<ShopItem> GetShopItems(string id)
		{
			return ContainsShop(id) ? Shops[id] : null;
		}

		public static List<ShopItem> GetShopItems(int index)
		{
			return GetShopItems(GetShopID(index));
		}
	}
}
