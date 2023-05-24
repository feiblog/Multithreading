using System;
using System.Threading;
using static System.Console;
using static System.Threading.Thread;

namespace Recipe11
{
    /**
     * 处理异常
     * 
     * 在线程中始终使用try-catch代码块是非常重要的，因为不可能在线程代码之外来捕获异常
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(FaultyThread);
            t.Start();
            t.Join();

            try
            {
                t = new Thread(BadFaultyThread);
                t.Start();
            }
            catch (Exception ex)
            {
                WriteLine("We won't get here!");
            }
        }

        static void BadFaultyThread()
        {
            WriteLine("Starting a faulty thread...");
            Sleep(TimeSpan.FromSeconds(2));
            throw new Exception("Boom!");
        }

        static void FaultyThread()
        {
            try
            {
                WriteLine("Starting a faulty thread...");
                Sleep(TimeSpan.FromSeconds(1));
                throw new Exception("Boom!");
            }
            catch (Exception ex)
            {
                WriteLine($"Exception handled: {ex.Message}");
            }
        }
    }
}
