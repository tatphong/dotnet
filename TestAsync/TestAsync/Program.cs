using System;
using System.Threading;
using System.Threading.Tasks;

namespace TestAsync
{
    class Program
    {
        static void Main(string[] args)
        {

            //Task taskone = ThreadOne();
            //Task tasktwo = ThreadTwo();
            Task.WaitAll(ThreadOne(4), ThreadTwo(7));

            Console.WriteLine("Execution End");
        }

        private static async Task<string> ThreadOne(int n)
        {
            Task<string> t1 = new Task<string>(
                () =>
                {
                    for (int i = 0; i < n; i++)
                        Console.WriteLine("T1: " + i);
                    return "thread 1 complete";
                }
                );
            t1.Start();
            string k1 = await t1;
            Console.WriteLine("ThreadOne");
            return k1;
        }

        private static async Task<string> ThreadTwo(int n)
        {
            Task<string> t2 = new Task<string>(
                () =>
                {
                    for (int i = 0; i < n; i++)
                        Console.WriteLine("T2: " + i);
                    return "thread 2 complete";
                }
                );
            t2.Start();
            string k2 = await t2;
            Console.WriteLine("ThreadTwo");
            return k2;
        }
    }
}
