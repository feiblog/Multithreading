using System.Threading;
using static System.Console;

namespace Recipe1
{
    /**
     * 本节介绍如何对对象执行基本的原子操作，从而不用阻塞线程就可避免竞争条件
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Incorrect counter");

            Counter c = new Counter();

            Thread t1 = new Thread(() => TestCounter(c));
            Thread t2 = new Thread(() => TestCounter(c));
            Thread t3 = new Thread(() => TestCounter(c));
            t1.Start();
            t2.Start();
            t3.Start();
            t1.Join();
            t2.Join();
            t3.Join();

            WriteLine($"Total count: {c.Count}");
            WriteLine("---------------------------------------");
            WriteLine("Correct counter");

            CounterNoLock c1 = new CounterNoLock();

            t1 = new Thread(() => TestCounter(c1));
            t2 = new Thread(() => TestCounter(c1));
            t3 = new Thread(() => TestCounter(c1));

            t1.Start();
            t2.Start();
            t3.Start();
            t1.Join();
            t2.Join();
            t3.Join();

            WriteLine($"Total count: {c1.Count}");
            ReadKey();

        }
        static void TestCounter(CounterBase c)
        {
            for (int i = 0; i < 100000; i++)
            {
                c.Increment();
                c.Decrement();
            }
        }
    }
    class Counter : CounterBase
    {
        private int _count;
        public int Count => _count;

        public override void Increment()
        {
            _count++;
        }

        public override void Decrement()
        {
            _count--;
        }
    }

    class CounterNoLock : CounterBase
    {
        private int _count;
        public int Count => _count;

        public override void Increment()
        {
            //以原子操作的形式递增指定变量的值并存储结果。
            Interlocked.Increment(ref _count);
        }

        public override void Decrement()
        {
            //以原子操作的形式递减指定变量的值并存储结果。
            Interlocked.Decrement(ref _count);
        }
    }

    abstract class CounterBase
    {
        public abstract void Increment();
        public abstract void Decrement();
    }
}
