using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SerializationExample
{

    [Serializable]
    public class Employee
    {
        private int _id;
        private string _name;

        public Employee(int id, string name)
        {
            _id = id;
            _name = name;
        }

        
        public int Id { get { return _id; } set { _id = value; } }

        public string Name { get { return _name; } set { _name = value; } }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> lstEmployee = new List<Employee>();
            lstEmployee.Add(new Employee(1, "Ram"));
            lstEmployee.Add(new Employee(2, "Laxman"));
            lstEmployee.Add(new Employee(3, "Ravana"));
            lstEmployee.Add(new Employee(4, "Bharat"));
            lstEmployee.Add(new Employee(5, "Sita"));
            lstEmployee.Add(new Employee(6, "Vibishan"));

            JsonExample(lstEmployee);

            BinaryExample(lstEmployee);

        }

        private static void BinaryExample(List<Employee> lstEmployee)
        {
            // Serialize
            FileStream fs = new FileStream("employees.bin", FileMode.OpenOrCreate);

            BinaryFormatter binformat = new BinaryFormatter();
            binformat.Serialize(fs, lstEmployee);

            fs.Close();

            // Deserialize
            fs = new FileStream("employees.bin", FileMode.Open);
            List<Employee> newList = (List<Employee>)binformat.Deserialize(fs, null);
            Console.WriteLine("-- Binary Deserialize --");
            foreach (Employee e in newList)
            {
                Console.WriteLine("Id = {0}; Name = {1}", e.Id, e.Name);
            }
            Console.ReadKey();
        }

        private static void JsonExample(List<Employee> lstEmployee)
        {
            // Serialize
            FileStream fs = new FileStream("employees.json", FileMode.OpenOrCreate);

            StreamWriter sw = new StreamWriter(fs);
            JsonSerializer jsonSerializer = new JsonSerializer();
            jsonSerializer.Serialize(sw, lstEmployee);

            sw.Close();
            fs.Close();

            //Deserialize

            StreamReader sr = new StreamReader("employees.json");
            List<Employee> newList = (List<Employee>)jsonSerializer.Deserialize(sr, typeof(List<Employee>));
            sr.Close();
            Console.WriteLine("-- JSON Deserialize --");
            foreach (Employee e in newList)
            {
                Console.WriteLine("Id = {0}; Name = {1}", e.Id, e.Name);
            }
            Console.ReadKey();
        }
    }
}
