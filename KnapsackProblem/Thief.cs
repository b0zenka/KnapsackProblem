using System.Collections.Generic;

namespace KnapsackProblem
{
    class Thief
    {
        private IRobStrategy strategy = null;
        private int capacityBackBag;

        public Thief(int capacityBackBag)
        {
            this.capacityBackBag = capacityBackBag;
        }

        public Dictionary<ThingsInShop, int> RobShop(Shop shop)
        {
           return this.strategy.Rob(shop, capacityBackBag);
        }

        public void SetStrategy(IRobStrategy strategy)
        {
            this.strategy = strategy;
        }
    }
}
