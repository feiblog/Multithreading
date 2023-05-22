using System;
using System.Threading;
using static System.Console;
using static System.Threading.Thread;

namespace Recipe3
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Starting...");
            Thread t = new Thread(PrintNumbersWithDelay);
            t.Start();
            t.Join();
            WriteLine("Thread completed");
            ReadKey();
        }
         static void PrintNumbersWithDelay()
        {
            WriteLine("Starting...");
            for (int i = 0; i < 5; i++)
            {
                Sleep(TimeSpan.FromSeconds(2));
                WriteLine(i);
            }
        }
    }
}
