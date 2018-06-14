using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LockExample
{
    class Program
    {
        private static object lockObj = new object();

        static void Main(string[] args)
        {
            for (int i = 1; i <= 5; i++)
            {
                Thread t = new Thread(new ParameterizedThreadStart(Worker));

                // Start the thread, passing the number.
                //
                t.Start(i);
            }

            Console.WriteLine("Main thread exits.");

        }

        private static void Worker(object num)
        {
            Console.WriteLine("Thread {0} method entered", (int)num);

            if ((int)num == 3) Thread.Sleep(15000);

            lock(lockObj)
            {
                Console.WriteLine("Thread {0} inside lock doing some op", (int) num);
                Thread.Sleep(10000);
            }

            Console.WriteLine("Thread {0} after lock", (int)num);
            
        }
    }
}
