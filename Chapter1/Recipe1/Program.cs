using System.Threading;
using static System.Console;

namespace Recipe1
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(PrintNumbers);
            t.Start();
            PrintNumbers();
        }

        static void PrintNumbers()
        {
            /**
             * 使用C# 6.0提供的using static特性,可以使用System.Console类型的静态方法而不用指定类型名
             */
            WriteLine("Starting...");
            for (int i = 0; i < 10; i++)
            {
                WriteLine(i);
            }
        }
    }
}
