using Projeto_Pedidos.Entities;
using Projeto_Pedidos.Entities.Enums;
using System;
using System.Globalization;

namespace Projeto_Pedidos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            Console.WriteLine("Enter client data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter order data:");
            

            Client client = new Client(name, email, birthDate);
            Order order = new Order(DateTime.Now, client);


            Console.Write("How many items to this order? ");
            int quantity = int.Parse(Console.ReadLine());

           
            for (int i = 1; i <= quantity; i++)
            {
                Console.WriteLine($"Enter #{i} item data:");
                Console.Write("Product name: ");
                string nameproduct = Console.ReadLine();
                Console.Write("Product price: ");
                double priceproduct = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Product product = new Product(nameproduct, priceproduct);


                Console.Write("Quantity: ");
                int quantityproduct = int.Parse(Console.ReadLine());

                
                OrderItem orderItem = new OrderItem(quantityproduct, priceproduct, product);     
                
                order.AddItem(orderItem);
                

            }


            Console.WriteLine();
            Console.WriteLine("ORDER SUMMARY:");
            Console.WriteLine(order);

        }

       
    }
}
