using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lab1.Quantity;

namespace Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new();
            List<Product> products = new List<Product>();

            person.FirstName = ReadValue("First name: ");
            person.LastName = ReadValue("Last name: ");
            person.PhoneNumber = ReadValue("Phone number: ");
            person.Address = ReadValue("Address: ");

            do
            {
                string code = ReadValue("Code: ");
                if (string.IsNullOrEmpty(code))
                {
                    break;
                }

                string quantity = ReadValue("Quantity: ");
                if (string.IsNullOrEmpty(quantity))
                {
                    break;
                }

                Product product = new Product();
                product.Code = code;
                product.Quantity = new Number(quantity);

                products.Add(product);
            } while (true);

            Order order = new Order
            {
                Person = person,
                Products = products
            };

            Console.WriteLine(order.Person);
            foreach (Product product in products)
            {
                Console.WriteLine(product);
            }
        }

        private static string ReadValue(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine();
        }
    }
}
