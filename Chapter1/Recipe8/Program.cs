using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;
using static System.Threading.Thread;

namespace Recipe8
{
    /**
     * 向线程传递参数
     * 
     */
    internal class Program
    {

        static void Main(string[] args)
        {
            /**
             * 方法1：
             * 当主程序启动时,首先创建ThreadSample类的对象，并提供了一个迭代次数。
             * 然后使用该对象的CountNumbers方法启动线程
             */
            ThreadSample sample = new ThreadSample(10);
            Thread threadOne = new Thread(sample.CountNumber);
            threadOne.Name = "ThreaadOne";
            threadOne.Start();
            threadOne.Join();

            WriteLine("------------------------------");

            /**
             * 方法2：
             * 使用Thread.start方法。
             * 该方法会接收一个对象，并将该对象传递给吸纳城，
             * 在线程中启动的方法必须接收object类型的单个参数
             */
            Thread threadTwo = new Thread(Count);
            threadTwo.Name = "ThreadTwo";
            threadTwo.Start(8);
            threadTwo.Join();

            WriteLine("-----------------------");

            /**
             * 方法3：
             * 使用lambda表达式。
             * lambda表达式定义了一个不属于任何类的方法。
             * 我们创建了一个方法，该方法使用需要的参数调用了另一个方法，并在另一个线程中运行该方法。
             */
            Thread threadThree = new Thread(() => CountNumbers(12));
            threadThree.Name = "ThreadThree";
            threadThree.Start();
            threadThree.Join();

            WriteLine("---------------------------------");

            /**
             * 使用lambda表达式应用另一个C#对象的方式被称为闭包。
             * 当在lambda表达式中使用任何局部变量时，C#会生成一个类，并将该变量作为该类的一个属性。所以实际上该方式与方法1使用的一样，但我们无须定义该类，C#编译器会自动帮我们实现
             * 
             * 问题：
             * 如果多个lambda表达式中使用相同变量，他们会共享该变量值。如下：两个线程均会打印20，因为两个线程启动之前变量被修改为20。
             * 
             */
            int i = 10;
            Thread threadFour = new Thread(() => printNumber(i));
            i = 20;
            Thread threadFive = new Thread(() => printNumber(i));
            threadFour.Start();
            threadFive.Start();

        }

        static void Count(object iterations)
        {
            CountNumbers((int)iterations);
        }

        static void CountNumbers(int iterations)
        {
            for (int i = 1; i <= iterations; i++)
            {
                Sleep(TimeSpan.FromSeconds(0.5));
                WriteLine($"{CurrentThread.Name} prints {i}");
            }
        }
        
         static void printNumber(int number)
        {
            WriteLine(number);
        }
    }

    class ThreadSample
    {
        private readonly int _iterations;
        public ThreadSample(int iterations)
        {
            _iterations = iterations;
        }
        public void CountNumber()
        {
            for (int i = 1; i <= _iterations; i++)
            {
                Sleep(TimeSpan.FromSeconds(0.5));
                WriteLine($"{CurrentThread.Name} print {i}");
            }
        }
    }
}
