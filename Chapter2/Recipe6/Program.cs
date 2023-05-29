using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;
using static System.Threading.Thread;

namespace Recipe6
{
    /**
     * 使用CountDownEvent类
     * 
     * 使用CountDownEvent信号类来等待直到一定数量的操作完成
     */
    internal class Program
    {
        /**
         * 当主程序启动时，创建了一个CountdownEvent实例，在其构造函数中指定了当两个操作完成时会发出信号。
         * 然后我们启动了两个线程，当它们执行完成后会发出信号。
         * 一旦第二个线程完成，主线程会从等待CountdownEvent的状态中返回并继续执行。
         * 针对需要等待多个异步操作完成的情形，使用该方式是非常便利的。
         * 
         * 然而这有一个重大的缺点。
         * 如果调用_countdown。Signal()没达到指定的次数，那么_countdown.Wait()将一直等待。
         * 请确保使用CountdownEvent时，所有线程完成后都要调用Signal方法。
         * 
         */
        static void Main(string[] args)
        {
            WriteLine(DateTime.Now.ToString("ss") + ":  Starting two operations");
            Thread t1 = new Thread(() => PerformOperation("Operation 1 is completed", 4));
            Thread t2 = new Thread(() => PerformOperation("Operation 2 is completed", 8));
            t1.Start();
            t2.Start();
            _countdown.Wait();
            WriteLine(DateTime.Now.ToString("ss") + ":  Both operations have been completed.");
            _countdown.Dispose();

            ReadKey();
        }

        /// <summary>
        /// 表示在计数变为零时处于有信号状态的同步基元。
        /// 默认：最初所需设置信号的数量为2
        /// </summary>
        static CountdownEvent _countdown = new CountdownEvent(2);
        static void PerformOperation(string message,int seconds)
        {
            Sleep(TimeSpan.FromSeconds(seconds));
            WriteLine(DateTime.Now.ToString("ss") + ":  " + message);
            _countdown.Signal();
        }
    }
}
