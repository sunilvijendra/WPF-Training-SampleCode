using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleLambda
{
    class Employee
    {
        private int _id;
        private string _name;

        public Employee(int id, string name)
        {
            _id = id;
            _name = name;
        }

        public int Id { get { return _id; } set { _id = value;  } }

        public string Name { get { return _name; } set { _name = value; } }
    }

    class Program
    {
        delegate int Operation(int a, int b);

        static void Main(string[] args)
        {
            // Add
            Operation op = (x, y) => x + y;
            Console.WriteLine("Output = {0}", op(5, 4));

            // Multiply
            op = (x, y) =>
            {
                Console.WriteLine("Inside Lambda - mul = {0}", x * y);
                return 0;
            };
            op(5, 3);

            // Arrays
            int[] numbers = { 8, 10, 6, 7, 43, 22, 3, 5 };

            int[] subset = numbers.TakeWhile(x => x != 0 ).ToArray();
            foreach( int i in subset)
            {
                Console.WriteLine(i);
            }

            // Lists
            List<Employee> lstEmployee = new List<Employee>();
            lstEmployee.Add(new Employee(1, "Ram"));
            lstEmployee.Add(new Employee(2, "Laxman"));
            lstEmployee.Add(new Employee(3, "Ravana"));
            lstEmployee.Add(new Employee(4, "Bharat"));
            lstEmployee.Add(new Employee(5, "Sita"));
            lstEmployee.Add(new Employee(6, "Vibishan"));

            if (lstEmployee.Count(x => x.Name.StartsWith("R")) > 0)
                Console.WriteLine("Found our employee");
            else
                Console.WriteLine("Employee NOT found!!");

            List<Employee> lstSubset = lstEmployee.FindAll(x => x.Name.StartsWith("R"));

            Console.ReadKey();
        }
    }
}
