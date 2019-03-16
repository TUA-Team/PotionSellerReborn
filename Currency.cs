using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;

namespace PotionSellerReborn
{
	public class Currency
	{
		public int Copper;
		public int Silver;
		public int Gold;
		public int Platinum;

		public int Total
		{
			get
			{
				int ret = Copper + Silver * 100;
				ret += Gold * 100 * 100;
				return ret + Platinum * 100 * 100 * 100;
			}
			set
			{
				Copper = value % 100;
				value /= 100;
				Silver = value % 100;
				value /= 100;
				Gold = value % 100;
				value /= 100;
				Platinum = value;
			}
		}
		
		public Currency(int platinum = 0, int gold = 0, int silver = 0, int copper = 0)
		{
			Platinum = platinum;
			Gold = gold;
			Silver = silver;
			Copper = copper;
		}

		public Currency(int copper)
		{
			Total = copper;
		}
	}
}
