using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using static System.Console;
using static System.Threading.Thread;

/// <summary>
/// 检测线程状态
/// </summary>
namespace Recipe5
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Starting program...");
            Thread t = new Thread(PrintNumbersWithStatus);
            Thread t2 = new Thread(DoNothing);
            WriteLine(t.ThreadState.ToString());
            t2.Start();
            t.Start();
            for (int i = 0; i < 30; i++)
            {
                WriteLine(t.ThreadState.ToString());
            }
            Sleep(TimeSpan.FromSeconds(6));
            t.Abort();
            WriteLine("A thread has been aborted");
            WriteLine(t.ThreadState.ToString());
            WriteLine(t2.ThreadState.ToString());
            ReadKey();
        }

        static void DoNothing()
        {
            Sleep(TimeSpan.FromSeconds(2));
        }

        static void PrintNumbersWithStatus()
        {
            WriteLine("Starting...");
            WriteLine(CurrentThread.ThreadState.ToString());
            for (int i = 0; i < 10; i++)
            {
                Sleep(TimeSpan.FromSeconds(2));
                WriteLine(i);
            }
        }
    }
}
