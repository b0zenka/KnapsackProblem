namespace KnapsackProblem
{
    public class ThingsInShop
    {
        public string Name { get; private set; }
        public int Value { get; private set; }       //cena zł
        public int Weight { get; private set; }      //waga kg
        public double Propitability { get; private set; }                   //value/weight

        public static ThingsInShop Builder(int numer)
        {
            ThingsInShop tIS = new ThingsInShop();
            tIS.Name = string.Concat("Rzecz nr", numer.ToString());
            tIS.Value = Program.rand.Next(1, 50);
            tIS.Weight = Program.rand.Next(1, 20);
            tIS.Propitability = (double) tIS.Value / tIS.Weight;

            return tIS;
        }
    }
}
