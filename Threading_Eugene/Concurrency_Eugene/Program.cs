using System;
using System.Threading;
using static System.Console;
using static System.Threading.Thread;
using static System.Diagnostics.Process;

namespace Concurrency_Eugene
{
    class Program
    {
        static void PrintNumbers()
        {
            WriteLine("Starting...");
            for (int i = 1; i < 10; i++)
            {
                WriteLine(i);
            }
        }

        static void PrintNumbersWithDelay()
        {
            WriteLine("Starting...");
            for (int i = 1; i < 10; i++)
            {
                WriteLine(". " + i);
                Sleep(TimeSpan.FromSeconds(2));

            }
        }

        static void PrintNumbersWithStatus()
        {
            WriteLine("Starting...");
            WriteLine(CurrentThread.ThreadState.ToString());
            for (int i = 1; i < 10; i++)
            {
                Sleep(TimeSpan.FromSeconds(2));
                WriteLine(i);
            }
        }

        static void DoNothing()
        {
            Sleep(TimeSpan.FromSeconds(2));
        }

        //static void RunThreads()
        //{
        //    var sample = new ThreadSample();
        //    var threadOne = new Thread(sample.CountNumbers);
        //    threadOne.Name = "ThreadOne";
        //    var threadTwo = new Thread(sample.CountNumbers);
        //    threadTwo.Name = "ThreadTwo";
        //    threadOne.Priority = ThreadPriority.Highest;
        //    threadTwo.Priority = ThreadPriority.Lowest;
        //    threadOne.Start();
        //    threadTwo.Start();
        //    Sleep(TimeSpan.FromSeconds(2));
        //    sample.Stop();
        //}
        //class ThreadSample
        //{
        //    private readonly int _iterations;
        //    public ThreadSample(int iterations)
        //    {
        //        _iterations = iterations;
        //    }
        //    public void CountNumbers()
        //    {
        //        for (int i = 0; i < _iterations; i++)
        //        {
        //            Sleep(TimeSpan.FromSeconds(0.5));
        //            WriteLine($"{CurrentThread.Name} prints {i}");
        //        }
        //    }
        //}

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
        static void PrintNumber(int number)
        {
            WriteLine(number);
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
                for (int i = 1; i <= _iterations; i++)
                {
                    Sleep(TimeSpan.FromSeconds(0.5));
                    WriteLine($"{CurrentThread.Name} prints {i}");
                }
            }
        }

        static void Main(string[] args)
        {
            var sample = new ThreadSample(10);
            var threadOne = new Thread(sample.CountNumbers);
            threadOne.Name = "ThreadOne";
            threadOne.Start();
            threadOne.Join();
            WriteLine("--------------------------");
            var threadTwo = new Thread(Count);
            threadTwo.Name = "ThreadTwo";
            threadTwo.Start(8);
            threadTwo.Join();
            WriteLine("--------------------------");
            var threadThree = new Thread(() => CountNumbers(12));
            threadThree.Name = "ThreadThree";
            threadThree.Start();
            threadThree.Join();
            WriteLine("--------------------------");
            int i = 10;
            var threadFour = new Thread(() => PrintNumber(i));
            i = 20;
            var threadFive = new Thread(() => PrintNumber(i));
            threadFour.Start();
            threadFive.Start();
            ReadLine();
        }

    }
}
