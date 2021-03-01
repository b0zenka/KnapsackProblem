using System;
using System.Collections.Generic;

namespace KnapsackProblem
{
    class Program
    {
        public static Random rand = new Random();
        const string MENU = "Ustaw strategię:\n"
                          + "1 - Kradnij zachłannie - RobGreedly\n"
                          + "2 - Kradnij unikatowe rzeczy - RobUniqueThings\n";

        static void Main(string[] args)
        {
            Console.WriteLine("--->Problem plecakowy<--- \nPodaj udźwig plecaka w kg (nie więcej niż 100kg): ");
            Shop shop;
            Thief thief;

            try
            {
                int capacityBackBag = int.Parse(Console.ReadLine());
                if (capacityBackBag <= 100)
                    thief = new Thief(capacityBackBag);
                else
                    throw new Exception("Testujemy małe liczby!");

                Console.WriteLine("Podaj ilość rzeczy w sklepie (nie więcej niż 100): ");
                int amountOfThingsInShop = int.Parse(Console.ReadLine());
                if (amountOfThingsInShop <= 100)
                {
                    shop = new Shop(amountOfThingsInShop);
                }
                else
                    throw new Exception("Testujemy małe liczby!");

                
                Console.WriteLine(MENU);
                byte choice = byte.Parse(Console.ReadLine());
                switch (choice)
                {
                        case 1:
                            thief.SetStrategy(new RobGreedlyStrategy());
                            break;
                        case 2:
                            thief.SetStrategy(new RobUniqueThingsStrategy());
                            break;
                        default:
                            throw new Exception("Nie ma takiej strategii!!!");
                }

                shop.ShowThingnsInShop();

                Dictionary<ThingsInShop, int> robbedThings = thief.RobShop(shop);
                DisplayRobThings(robbedThings);
            }
            catch (Exception e)
            {
                Console.WriteLine("Błąd: {0}.", e.Message);
            }
            
            Console.ReadKey();
        }

        private static void DisplayRobThings(Dictionary<ThingsInShop, int> robbedThings)
        {
            int sumValue = 0;
            int sumOfRobbedThings= 0;
            int sumWeight = 0;

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("----->Skradzione rzecz<-----");
            Console.ResetColor();
            foreach (var item in robbedThings)
            {
                Console.WriteLine("Skradziono {0} o wartości = {1}zł i wadze = {2}kg: {3} szt.", 
                    item.Key.Name, item.Key.Value, item.Key.Weight, item.Value);
                sumValue += (item.Key.Value * item.Value);
                sumOfRobbedThings += item.Value;
                sumWeight += (item.Key.Weight * item.Value);
            }
            Console.WriteLine("Skradziono {0} rzeczy o łącznej wartości: {1}zł i łącznej wadze: {2}kg.", sumOfRobbedThings, sumValue, sumWeight);
        }

        
    }
}
