using System;
using System.Threading;
using static System.Console;
using static System.Threading.Thread;

namespace Recipe10
{
    /**
     * 使用Monitor类锁定资源 
     * 
     * 本节演示另一个常见的多线程错误，被称为死锁（deadlock）
     * 由于死锁将导致程序停止工作，使用Monitor类来避免死锁
     * 
     * lock关键字则用于创建死锁
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            object lock1 = new object();
            object lock2 = new object();

            /**
             *LockTooMuch方法:先锁定第一个对象，等待一秒后锁定第二个对象。
             *然后在另一个线程中启动该方法。
             */
            new Thread(() => LockTooMuch(lock1, lock2)).Start();
            /**
             * 最后尝试在主线程中先后锁定第二个和第一个对象
             */
            lock (lock2)
            {
                Thread.Sleep(1000);
                WriteLine("Monitor.TryEnter allows not to get stuck,returning false after a specified timeout is elapsed");

                if (Monitor.TryEnter(lock1,TimeSpan.FromSeconds(5)))
                {
                    WriteLine("Acquired a protected resource succesfully");
                }
                else
                {
                    WriteLine("Timeout acquiring a resource");
                }
            }

            new Thread(() => LockTooMuch(lock1,lock2)).Start();

            WriteLine("--------------------------------------------------------");

            lock (lock2)
            {
                WriteLine("This will be a deadlock");
                Sleep(1000);
                lock (lock1)
                {
                    WriteLine("Acquired a protected resource succesfully");
                }
            }
        }
        static void LockTooMuch(object lock1,object lock2)
        {
            lock (lock1)
            {
                Sleep(1000);
                lock (lock2) ;
            }
        }

    }
}
