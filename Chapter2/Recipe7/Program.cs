using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;
using static System.Threading.Thread;

namespace Recipe7
{
    /**
     * 使用Barrier类
     * 
     * 用于组织多个线程及时在某个时刻碰面。
     * 其提供了一个回调函数，每次线程调用了SignalAndWait方法后该回调函数会被执行。
     */
    internal class Program
    {
        /**
         * 我们创建了Barrier类，指定了我们想要同步两个线程。
         * 在两个线程中的任何一个调用了_barrier.SignalAndWait方法后，会执行一个回调函数来打印出阶段
         * 
         * 每个线程将想Barrier发送两次信号，所以会有两个阶段
         * 每次这两个线程调用SignalAndWait方法时，Barrier将执行回调函数。
         * 这在多线程迭代运算中非常有用，可以在每个迭代结束前执行一些计算
         * 当最后一个线程调用SignalAndWait方法是可以在迭代结束时进行交互
         */
        static void Main(string[] args)
        {
            Thread t1 = new Thread(() => PlayMusic("the guitarist", "play an amazing solo", 5));
            Thread t2 = new Thread(() => PlayMusic("the singer", "sing his song", 2));
            t1.Start();
            t2.Start();
        }

        static Barrier _barrier = new Barrier(2, b => WriteLine($"End of phase {b.CurrentPhaseNumber + 1}"));

        static void PlayMusic(string name,string message,int seconds)
        {
            for (int i = 0; i < 5; i++)
            {
                WriteLine("------------------------------------------");
                Sleep(TimeSpan.FromSeconds(seconds));
                WriteLine($"{name} starts to {message}");
                Sleep(TimeSpan.FromSeconds(seconds));
                WriteLine($"{name} finishes to {message}");
                _barrier.SignalAndWait();
            }
        }
    }
}
