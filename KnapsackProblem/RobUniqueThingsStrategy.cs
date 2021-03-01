using System.Collections.Generic;
using System.Linq;

namespace KnapsackProblem
{
    class RobUniqueThingsStrategy : IRobStrategy
    {
        public Dictionary<ThingsInShop, int> Rob(Shop shop, double weightBackBag)
        {
            Dictionary<ThingsInShop, int> robbedThings = new Dictionary<ThingsInShop, int>();
            List<ThingsInShop> list = shop.GetShopThings();

            var sortedList = list.OrderByDescending(x => x.Propitability).ThenBy(x => x.Weight);

            foreach (var item in sortedList)
            {
                if (item.Weight <= weightBackBag)
                {
                    robbedThings.Add(item, 1);
                    weightBackBag -= item.Weight;
                }

            }

            return robbedThings;
        }
    }
}
