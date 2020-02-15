using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OptionalParameterMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            CSharp1();

            Customer customer1, customer2, customer3;
            GetCustomerObjects(out customer1, out customer2, out customer3);
            var customers = GetCustomerList(customer1, customer2, customer3);

            if (customers.TryGetValue(1, out Customer customer))
            {
                Console.WriteLine("ID is {0}, Name is {1}, Salary is {2}",
                    customer.ID, customer.Name, customer.Salary);
            }
            else
            {
                Console.WriteLine("Key is not found");
            }
            Console.WriteLine("Number of {0} ", customers.Count(cust => cust.Value.Salary < 40000));
            Console.ReadKey();
        }

        private static Dictionary<int, Customer> GetCustomerList(Customer customer1, Customer customer2, Customer customer3)
        {
            Dictionary<int, Customer> Customers = new Dictionary<int, Customer>();
            Customers.Add(customer1.ID, customer1);
            Customers.Add(customer2.ID, customer2);
            Customers.Add(customer3.ID, customer3);
            return Customers;
        }

        private static void GetCustomerObjects(out Customer customer1, out Customer customer2, out Customer customer3)
        {
            customer1 = new Customer { ID = 1, Name = "QWERTY", Salary = 456555 };
            customer2 = new Customer { ID = 2, Name = "QWERTY12", Salary = 123555 };
            customer3 = new Customer { ID = 3, Name = "QWERTY23", Salary = 455455 };
        }

        private static void CSharp1()
        {
            AddNumbers(10, 20, new int[] { 10, 5, 5, 5 });
            int i = 0;
            int j = 0;
            PassByValue(i);
            Console.WriteLine(i);

            PassByReference(ref j);
            Console.WriteLine(j);
        }

        public static void AddNumbers(int a, int b, [Optional] int[] numbers)
        {
            int result = a + b;

            if (numbers != null)
            {
                foreach (var number in numbers)
                {
                    result += number;
                }
            }

            Console.WriteLine("Addition is {0}", result);
        }

        public static void PassByValue(int number)
        {
            number = 100;
        }

        public static void PassByReference(ref int number)
        {
            number = 100;
        }
    }
}
