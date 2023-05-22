using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using static System.Console;
using static System.Threading.Thread;
using static System.Diagnostics.Process;

/// <summary>
/// 线程优先级
/// 线程优先级决定了该线程可占用多少CPU时间
/// </summary>
namespace Recipe6
{
    public class Program
    {
        static void Main(string[] args)
        {
            WriteLine($"Current thread priority:{CurrentThread.Priority}");
            WriteLine("Running on all cores available");
            RunThreads();
            Sleep(TimeSpan.FromSeconds(2));
            WriteLine("Running on a single core");
            GetCurrentProcess().ProcessorAffinity = new IntPtr(1);
            RunThreads();
        }

        static void RunThreads()
        {
            var sample = new ThreadSample();
            var threadOne = new Thread(sample.CountNumbers);
            threadOne.Name = "ThreadOne";
            var threadTwo = new Thread(sample.CountNumbers);
            threadTwo.Name = "ThreadTwo";

            threadOne.Priority = ThreadPriority.Highest;
            threadTwo.Priority = ThreadPriority.Lowest;
            threadOne.Start();
            threadTwo.Start();
        }
    }

    class ThreadSample
    {
        private bool _isStopped = false;
        public void Stop()
        {
            _isStopped = true;
        }
        public void CountNumbers()
        {
            long counter = 0;
            while (!_isStopped)
            {
                counter++;
            }
            WriteLine($"{CurrentThread.Name} with {CurrentThread.Priority,11} priority has a count = {counter,13:NO}");
        }
    }
}
