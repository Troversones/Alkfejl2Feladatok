namespace Csalap2
{
    public class Pokemon
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Strength { get; set; }
    }
    internal class Program
    {
        delegate int TestDelegate(int x);

        static int Fun(int x)
        {
            Console.WriteLine(x - 1);
            return x - 1;
        }

        static void ActionTest(string nev)
        {
            Console.WriteLine("hello " + nev);
        }

        private static List<Pokemon> BuildList()
        {
            return new List<Pokemon> {
                { new Pokemon() { Name="Pokemon1", Type="Dragon", Strength=19}},
                { new Pokemon() { Name="Pokemon2", Type="Dragon", Strength=20}},
                { new Pokemon() { Name="Pokemon3", Type="Pixie", Strength=21}},
                { new Pokemon() { Name="Pokemon4", Type="Dragon", Strength=22}}
            };
        }

        static void Main(string[] args)
        {
            TestDelegate del;
            del = Fun;
            del += (x) => x + 1;


            Console.WriteLine(del(10));
            Console.WriteLine("----------------------");
            Action<string> act = ActionTest;
            act("Risitas");

            Console.WriteLine("----------------------");
            int[] scores = { 1, 2, 31, 3, 5, 8, 13, 21, 34, 97, 92, 81, 60 };

            var numbers = scores.Where(x => x > 20).Select(x => x).OrderBy(x => x).ToList();

            foreach (var number in numbers) {
                Console.WriteLine(number);
            }

            Console.WriteLine("Páros számok: ");
            var res1 = scores.Where(x => x % 2 == 0).Select(x => x).OrderBy(x => x).ToList();

            foreach (var number in res1) {
                Console.WriteLine(number);
            }
            Console.WriteLine("----------------------");

            List<Pokemon> xd = BuildList();

            var dragons = xd.Where(x => x.Type == "Dragon").Select(x => x).ToList();

            foreach (var dragon in dragons) {
                Console.WriteLine(dragon.Name);
            }
        }
    }
}
