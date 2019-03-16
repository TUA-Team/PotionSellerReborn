using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace PotionSellerReborn
{
    internal static class ModExtension
    {
       
        internal static ModItem[] GetInternalItemList(this Mod mod)
        {
            Dictionary<string, ModItem> itemList = (Dictionary<string, ModItem>) typeof(Mod)
                .GetField("items", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(mod);
            return itemList.Values.ToArray();
        }
    }
}
