using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{

    public static class MyExtensions
    {
        public static int GetWordCount(this String str)
        {
            return str.Split(new char[] { ' ', '.', '?' },
                             StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string str = "This is a sample string.";
            int res = str.GetWordCount();
            Console.WriteLine("Wordcount = {0}", res);
            Console.ReadKey();
        }
    }
}
