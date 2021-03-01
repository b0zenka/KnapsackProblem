using System.Collections.Generic;

namespace KnapsackProblem
{
    interface IRobStrategy
    {
        Dictionary<ThingsInShop, int> Rob(Shop shop, double weightBackBag);
    }
}
