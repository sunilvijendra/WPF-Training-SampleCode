using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods2
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator c1 = new Calculator();

            Console.WriteLine("Add = " + c1.Add(3, 5));
            Console.WriteLine("Sub = " + c1.Subtract(4, 5));
            Console.WriteLine("Mul = " + c1.Multiply(5, 10));

            Console.ReadKey();


        }
    }

    public static class CalculatorExtension
    {
        public static int Multiply(this Calculator c, int x, int y)
        {
            return x * y;
        }
    }

    public class Calculator
    {
        public int Add (int x, int y)
        {
            return x + y;
        }

        public int Subtract(int x, int y)
        {
            return x + y;
        }
    }
}
