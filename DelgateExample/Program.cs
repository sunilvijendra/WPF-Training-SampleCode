using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelgateExample
{
    class Program
    {
        delegate int Operation(int a, int b);

        static void Main(string[] args)
        {
            DelegateExample ex = new DelegateExample();
            Operation op = ex.Add;

            int result = op.Invoke(3, 5);
            Console.WriteLine("Add Result = {0}", result);

            op += ex.Sub;
            result = op.Invoke(3, 5);
            Console.WriteLine("Add Result = {0}", result);

            Console.ReadKey();
        }
    }

    class DelegateExample
    {
        public int Add(int x, int y)
        {
            Console.WriteLine("Add method");
            return x + y;
        }

        public int Sub(int x, int y)
        {
            Console.WriteLine("Sub method");
            return x - y;
        }
    }
}
