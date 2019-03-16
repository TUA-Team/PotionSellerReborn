using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;

namespace PotionSellerReborn
{
	public class ShopItem
	{
		public int ItemID;
		public Currency Price;
		private readonly Func<bool> _canSellCallback;

		public ShopItem(int itemID, Currency price, Func<bool> canSellCallback = null)
		{
			ItemID = itemID;
			Price = price;
			_canSellCallback = canSellCallback;
		}

		public bool CanSell()
		{
			if (_canSellCallback == null)
				return true;

			return _canSellCallback();
		}
	}
}
