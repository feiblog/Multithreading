using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using static System.Console;
using static System.Threading.Thread;

namespace Recipe7
{
    /**
     * 前台线程与后台线程的主要区别：
     * 进程会等待所有的前台线程完成后再结束工作，但是如果只剩下后台线程，则会直接结束工作
     * 
     */

    class Program
    {
        static void Main(string[] args)
        {
            var sampleForeground = new ThreadSample(10);
            var sampleBackground = new ThreadSample(20);

            var threadOne = new Thread(sampleForeground.CountNumbers);
            threadOne.Name = "ForegroundThread";
            var threadTwo = new Thread(sampleBackground.CountNumbers);
            threadTwo.Name = "BackgroundThread";
            threadTwo.IsBackground = true;

            threadOne.Start();
            threadTwo.Start();
            Console.ReadKey();
        }
    }

    class ThreadSample
    {
        private readonly int _iterations;
        public ThreadSample(int iterations)
        {
            _iterations = iterations;
        }
        public void CountNumbers()
        {
            for (int i = 0; i < _iterations; i++)
            {
               Sleep(TimeSpan.FromSeconds(0.5));
               WriteLine($"{CurrentThread.Name} prints {i}");
            }
        }
    }
}
