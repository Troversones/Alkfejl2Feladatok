using Serilog;

namespace Testapp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            string hehe = Console.ReadLine();
            Console.WriteLine(hehe + " ezaz kristály");

            var log = new LoggerConfiguration()
                .WriteTo.Console()
                .MinimumLevel.Debug()
                .CreateLogger();

            log.Debug("hi");
            log.Information("hello");
        }
    }
}
