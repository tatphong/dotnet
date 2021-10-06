using System;
using System.Threading;
using static System.Console;
using static System.Threading.Thread;
using static System.Diagnostics.Process;

namespace Concurrency_Eugene
{
    class Program3
    {
        static void TestCounter(CounterBase c)
        {
            for (int i = 0; i < 100000; i++)
            {
                c.Increment();
                c.Decrement();
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
                Interlocked.Increment(ref _count);
            }
            public override void Decrement()
            {
                Interlocked.Decrement(ref _count);
            }
        }
        abstract class CounterBase
        {
            public abstract void Increment();
            public abstract void Decrement();
        }
        static void Main(string[] args)
        {
            const string MutexName = "CSharpThreadingCookbook";
            using (var m = new Mutex(false, MutexName))
            {
                if (!m.WaitOne(TimeSpan.FromSeconds(5), false))
                {
                    WriteLine("Second instance is running!");
                }
                else
                {
                    WriteLine("Running!");
                    ReadLine();
                    m.ReleaseMutex();
                }
            }
            ReadLine();
        }

    }
}
