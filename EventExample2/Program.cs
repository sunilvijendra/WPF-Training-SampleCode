using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventExample2
{
    class Program
    {
        static void Main(string[] args)
        {
            CounterClass counter = new CounterClass(10);
            counter.ThresholdReached = HandlerThresholdReached;

            while (Console.ReadKey(false).KeyChar == 'u')
            {
                counter.UpdateCounter();
                Console.WriteLine("Counter = {0}", counter.Counter);
            }
        }

        private static void HandlerThresholdReached(object sender, EventArgs e)
        {
            Console.WriteLine("Threshold reached.");
            Environment.Exit(0);
        }
    }

    class CounterClass
    {
        private int threshold;
        private int counter;

        public EventHandler ThresholdReached;

        public int Counter { get => counter; set => counter = value; }

        public CounterClass(int t)
        {
            Counter = 0;
            threshold = t;
        }

        public void UpdateCounter()
        {
            if (Counter >= threshold)
            {
                ThresholdReached?.Invoke(this, EventArgs.Empty);
            }
            Counter++;
        }
    }
}
