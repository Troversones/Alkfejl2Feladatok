using Serilog;

namespace Testapp1
{
    partial class Player
    {
        public bool isPartial = true;

        public int fun(int i)
        {
            return i * i;
        }

        public void fun2(ref int i, out int qubic, int def = 5)
        {
            i *= i;
            qubic = i * i * i;
        }
    }

    internal class Program
    {
        static readonly double PI;
        const double euler = 2.77;

        static Program(){ 
            PI = Math.PI;
        }
        static void Main(string[] args)
        {
            //2. óra
            Console.WriteLine(PI + " --------- " + euler);
            int? fasz = null;
            if (fasz.HasValue) {
                Console.WriteLine($"value is: {fasz}");
            }
            else
            {
                Console.WriteLine("value is null");
            }
            //fapados megoldás az osztályra
            var x = new { name="VIKTOR", age=22 };
            Console.WriteLine(x.age);
            Console.WriteLine(x.name);
            
            Player p = new Player();
            p.ID = 10;
            p.userName = "test";

            int q = 25;
            int z;

            Console.WriteLine(p.ToString());
            Console.WriteLine(p.fun(10));
            p.fun2(ref q, out z);
            Console.WriteLine(q);
            Console.WriteLine(z);
            /* 1.óra
            Console.WriteLine("Hello, World!");
            string hehe = Console.ReadLine();
            Console.WriteLine(hehe + " ezaz kristály");

            var log = new LoggerConfiguration()
                .WriteTo.Console()
                .MinimumLevel.Debug()
                .CreateLogger();

            log.Debug("hi");
            log.Information("hello");
            */
         }
    }
}
