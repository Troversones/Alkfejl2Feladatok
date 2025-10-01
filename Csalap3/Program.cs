using System.Runtime.CompilerServices;
using System.Text;

namespace Csalap3
{
    class Vec2
    {
        public int x {  get; set; }
        public int y { get; set; }

        public Vec2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static Vec2 operator +(Vec2 v1, Vec2 v2) => new Vec2(v1.x + v2.x, v1.y + v2.y);
        public void Print()
        {
            Console.WriteLine($"X: {this.x}, Y: {this.y}");
        }
    }
    internal class Program
    {
        static void Work()
        {
            for (int i = 0; i < 20; i++)
                Console.WriteLine($"Work: {i}");
        }

        static void WorkWork()
        {
            for (int i = 0; i < 20; i++)
                Console.WriteLine($"WorkWork: {i}");
        }

        static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            //await TaskWhenAll();
            //
            //Thread t1 = new Thread(Work);
            //Thread t2 = new Thread(WorkWork);
            //
            //t1.Start();
            //t2.Start();
            //ParallelFor_WithLock();
            //
            //Console.WriteLine("\n Done");

            string workDir = Path.Combine(@"C:\Users\valaki\source\repos\Alkfejl2Feladatok\Csalap3\bin", "fajlok");
            Directory.CreateDirectory(workDir);
            WriteReadText(workDir);
            WriteReadLines(workDir);
            StreamWriterReader(workDir);
            BinaryRW(workDir);

            Vec2 v1 = new Vec2(1, 2);
            Vec2 v2 = new Vec2(2, 1);

            Vec2 v3 = v1 + v2;
            v3.Print();
        }

        static void WriteReadText(string dir)
        {
            string path = Path.Combine(dir, "else.txt");
            File.WriteAllText(path, "Hello \n this is a new line");
            string all = File.ReadAllText(path);
            File.AppendAllText(path, "\nfasz");
            string all2 = File.ReadAllText(path);
            Console.WriteLine(all);
            Console.WriteLine(all2);
        }

        static void WriteReadLines(string dir)
        {
            string path = Path.Combine(dir, "lines.txt");

            var line = new string[] { "alma", "ananász", "pityesz" };

            File.WriteAllLines(path, line);
        }

        static void StreamWriterReader(string dir)
        {
            string path = Path.Combine(dir, "stream.txt");

            using (StreamWriter sw = new StreamWriter(path, append:false, encoding: Encoding.UTF8))
            {
                sw.WriteLine("First line.");
                sw.WriteLine("Second line.");
                sw.WriteLine("Third line.");
            }

            using (StreamReader sr = new StreamReader(path, encoding: Encoding.UTF8)) {
                string? line;
                while ((line = sr.ReadLine()) != null) {
                    Console.WriteLine(line);
                }
            }
        }

        static void BinaryRW(string dir)
        {
            string path = Path.Combine(dir, "binary.bin");

            using (BinaryWriter bw = new BinaryWriter(File.Open(path,
                FileMode.OpenOrCreate,
                FileAccess.Write)))
            {
                bw.Write(42);
                bw.Write(42.4F);
                bw.Write(0xabc);
                bw.Write(true);
                bw.Write("false");
            }

            using (BinaryReader br = new BinaryReader(File.Open(path, 
                FileMode.Open,
                FileAccess.Read)))
            {
                int a = br.ReadInt32();
                float f = br.ReadSingle();
                int hex = br.ReadInt32();
                bool b = br.ReadBoolean();
                string s = br.ReadString();

                Console.WriteLine($"int: {a}, float: {f} hex: {hex} boolean: {b} string: {s}");
            }
        }

        static async Task TaskWhenAll()
        {
            Console.WriteLine("Start");
            Task t1 = WorkAsync("A", stepCount: 5, delay: 120);
            Task t2 = WorkAsync("B", stepCount: 10, delay: 180);
            Task t3 = WorkAsync("C", stepCount: 15, delay: 140);

            await Task.WhenAll(t1, t2, t3);
        }

        static async Task WorkAsync(string name, int stepCount, int delay)
        {
            for (int i = 0; i < stepCount; i++) { 
                await Task.Delay(delay);
                Console.WriteLine($"{name}: step: {stepCount}");
            }
        }

        static void ParallelFor_WithLock()
        {
            long sum = 0;
            object lck = new object();

            Parallel.For(1, 100_000, i =>
            {
                long sq = (long)i * i;
                lock (lck)
                {
                    sum += sq;
                }
            });

            Console.WriteLine($"1-100_000: {sum:N0}\n");
        }
    }
}
