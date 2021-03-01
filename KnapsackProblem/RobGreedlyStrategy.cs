using System.Collections.Generic;
using System.Linq;

namespace KnapsackProblem
{
    class RobGreedlyStrategy : IRobStrategy
    {
        public Dictionary<ThingsInShop, int> Rob(Shop shop, double weightBackBag)
        {
            Dictionary<ThingsInShop, int> robbedThings = new Dictionary<ThingsInShop, int>();
            List<ThingsInShop> list = shop.GetShopThings();

            //najpierw sortujemy po  opłacalności a później po wadze w przypadku gdyby elementy miały taka samą opłacalność.
            var sortedList = list.OrderByDescending(x => x.Propitability).ThenBy(x => x.Weight);

            foreach (var item in sortedList)
            {
                while (item.Weight <= weightBackBag)
                {
                    if (robbedThings.ContainsKey(item))
                    {
                        robbedThings[item]++;
                    }
                    else
                        robbedThings.Add(item, 1);
                    weightBackBag -= item.Weight;
                }

            }

            return robbedThings;
        }
    }
}
