using System;
using System.Collections.Generic;

namespace KnapsackProblem
{
    class Shop
    {
        private List<ThingsInShop> thingsList;

        public Shop(int amount)
        {
            thingsList = new List<ThingsInShop>();
            for (int i = 0; i < amount; i++)
            {
                thingsList.Add(ThingsInShop.Builder(i + 1));
            }
        }
        
        public void ShowThingnsInShop()
        {
            Console.WriteLine("Sklep posiada:");
            foreach (var thing in thingsList)
            {
                Console.WriteLine("{0} o wartości {1}zł i wadze: {2}kg", thing.Name, thing.Value, thing.Weight);
            }
        }

        public List<ThingsInShop> GetShopThings()
        {
            return thingsList;
        }
    }
}
