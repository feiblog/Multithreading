using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using static System.Console;

/// <summary>
/// 终止线程
/// </summary>
namespace Recipe4
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Starting program...");
            Thread t1 = new Thread(PrintNumbersWithDelay);
            t1.Start();
            Thread.Sleep(TimeSpan.FromSeconds(6));
            t1.Abort();
            WriteLine("A thread has been aborted");
            Thread t2 = new Thread(PrintNumbers);
            t2.Start();
            PrintNumbers();
            ReadKey();
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
        static void PrintNumbersWithDelay()
        {
            WriteLine("Starting...");
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(2));
                WriteLine(i);
            }
        }
    }
}
