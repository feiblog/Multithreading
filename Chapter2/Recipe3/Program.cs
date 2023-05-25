using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;
using static System.Threading.Thread;

namespace Recipe3
{
    /**
     * 展示semaphoreSlim类是如何作为semaphore类的轻量级版本
     * 该类限制了同时访问同一个资源的线程数量 
     */
    internal class Program
    {
        /**
         * 工作原理
         * 
         * 当主程序启动时，创建了SemaphoreSlim的一个实例，并在其构造函数中指定允许的并发线程数量。
         * 然后启动了六个不同名称和不同初始运行时间的线程。
         * 
         * 每个线程都尝试获取数据库的访问，但是我们借助于信号系统限制了访问数据库的并发数为四个线程。
         * 当有四个线程获取了数据库的访问后，其他两个线程需要等待，直到之前线程中的某一个完成工作并调用_semaphore.Release方法来发出信号。
         */

        /**
         * 更多信息 
         * 
         * 这里我们使用了混合模式，其允许我们在等待时间很短的情况下无需使用上下文切换。
         * 然而，有一个叫做Semaphore的SemaphoreSlim类的老版本。
         * 该版本使用纯粹的内核时间（kernel-time）方式。
         * 一般没必要使用它，除非是非常重要的场景。
         * 我们可以创建一个具名的semaphore,就像一个具名的mutex一样，从而在不同的程序中同步线程。
         * SemaphoreSlim并不适用Windows内核信号量，而且也不支持进程间同步。
         * 所以在跨程序同步的场景下可以使用Semaphore。
         * 
         */

        static SemaphoreSlim _semaphore = new SemaphoreSlim(4);
        static void Main(string[] args)
        {
            for (int i = 1; i <= 6; i++)
            {
                string threadname = "Thread" + i;
                int secondsToWait = 2 + 2 * i;
                var t = new Thread(() => AccessDatabase(threadname, secondsToWait));
                t.Start();
            }
        }

        static void AccessDatabase(string name,int seconds)
        {
            WriteLine($"{name} waits to access to a database");
            _semaphore.Wait();
            WriteLine($"{name} was granted an access to a database");
            Sleep(TimeSpan.FromSeconds(seconds));
            WriteLine($"{name} is completed");
            _semaphore.Release();
        }
    }
}
