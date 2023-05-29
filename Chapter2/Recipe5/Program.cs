using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;
using static System.Threading.Thread;

namespace Recipe5
{
    /**
     * 使用ManualResetEventSlim类
     * 
     * 描述使用ManualResetEventSlim类来在线程间以更灵活的方式传递信号
     */
    internal class Program
    {
        /**
         *  ManualResetEventSlim的整个工作方式有点像人群通过大门。
         *  AutoResetEvent事件像一个旋转门，一次只允许一人通过。
         *  ManualResetEventSlim是ManualResetEvent的混合版本，一直保持大门敞开直到手动调用Reset方法。
         * 当调用_mainEvent.Set时，相当于打开了大门从而允许准备好的线程接收信号并继续工作。
         * 然而线程3还处于睡眠状态，没有赶上时间。
         * 当调用_mainEvent.Reset相当于关闭了大门。
         * 最后一个线程已经准备好执行，但是不得不等待下一个信号，即要等待好几秒种。
         * 
         */
        static void Main(string[] args)
        {
            Thread t1 = new Thread(() => TravelThroughGates("Thread 1", 5));
            Thread t2 = new Thread(() => TravelThroughGates("Thread 2", 6));
            Thread t3 = new Thread(() => TravelThroughGates("Thread 3", 12));
            t1.Start();
            t2.Start();
            t3.Start();
            Sleep(TimeSpan.FromSeconds(6));
            WriteLine($"{DateTime.Now.ToString("ss")} : The gates are now open!");
            _mainEvent.Set();
            Sleep(TimeSpan.FromSeconds(2));
            _mainEvent.Reset();
            WriteLine($"{DateTime.Now.ToString("ss")} : The gates have been closed!");
            Sleep(TimeSpan.FromSeconds(10));
            WriteLine($"{DateTime.Now.ToString("ss")} : The gates are now open for the second time!");
            _mainEvent.Set();
            Sleep(TimeSpan.FromSeconds(2));
            WriteLine($"{DateTime.Now.ToString("ss")} : The gates have been closed!");
            _mainEvent.Reset();
            ReadKey();
        }

        /// <summary>
        /// ManualResetEvent:通知一个或多个正在等待的线程已发生事件
        /// 
        /// ManualResetEventSlim:简化版本的ManualResetEvent。
        /// 
        /// </summary>
        static ManualResetEventSlim _mainEvent = new ManualResetEventSlim(false);

        static void TravelThroughGates(string threadName,int seconds)
        {
            WriteLine($"{DateTime.Now.ToString("ss")} : {threadName} falls to sleep");
            Sleep(TimeSpan.FromSeconds(seconds));
            WriteLine($"{DateTime.Now.ToString("ss")} : {threadName} waits fot the gates to open!");
            _mainEvent.Wait();
            WriteLine($"{DateTime.Now.ToString("ss")} : {threadName} enters the gates!");
        }
    }
}
