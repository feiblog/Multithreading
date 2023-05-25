using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace Recipe2
{
    /**
     * 使用Mutex类
     * 
     * 描述如何使用Mutex类来同步两个单独的程序。
     * Mutex是一种原始的同步方式，其只对一个线程授予对共享资源的独占访问
     */
    internal class Program
    {
        /**
         * 当主程序启动时，定义了一个指定名称的互斥量，设置initialOwner标志为false。
         * 这意味着如果互斥量已经被创建，则允许程序获取该互斥量。
         * 如果没有获取到互斥量，程序则简单地显示Running，等待直到按下任意键，然后释放该互斥量并退出。
         * 
         * 如果再运行同样一个程序，则会在5秒钟内尝试获取互斥量。
         * 如果此时在第一个程序中按下任意键，第二个程序则会开始执行。
         * 然后，如果保持等待5秒钟，第二个程序将无法获取到该互斥量。
         */
        static void Main(string[] args)
        {
            const string MutexName = "Fei Pan";

            using (Mutex m = new Mutex(false,MutexName))
            {
                if (!m.WaitOne(TimeSpan.FromSeconds(5),false))
                {
                    WriteLine("Second instance is running");
                    ReadLine();
                }
                else
                {
                    WriteLine($"Running");
                    ReadLine();
                    m.ReleaseMutex();
                }
            }
        }



    }
}
