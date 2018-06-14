using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefOutExample
{
    class Example
    {
        public string value;

        public Example(string val)
        {
            value = val;
        }
    }

    class Program
    {
        static void Swap (ref int a, ref int b, ref Example ex)
        {
            int temp;

            temp = a;
            a = b;
            b = temp;

            ex = new Example("Swap_With_Ref");
        }

        static bool SwapNoRef( int a,  int b, Example ex, out Example exOut)
        {
            int temp;

            temp = a;
            a = b;
            b = temp;

            ex = new Example("Swap_NO_Ref");
            exOut = ex;

            return true;
        }

        static void Main(string[] args)
        {
            int a = 4;
            int b = 999;
            Example exOut = null ;

            Example ex = new Example("Default_Value");
            SwapNoRef( a,  b, ex, out exOut);
            Console.WriteLine("NoREF: a = {0}, b = {1}, value = {2}, out.value = {3}", a, b, ex.value, exOut.value);

            Example ex1 = new Example("Default_Value");
            Swap(ref a, ref b, ref ex1);
            Console.WriteLine("PassByRef: a = {0}, b = {1}, value = {2}", a, b, ex1.value);

            Console.ReadKey();

        }
    }
}
