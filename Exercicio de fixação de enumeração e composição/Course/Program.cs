using Course.Entities;
using Course.Entities.Enums;
using System.Globalization;

namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter cliente data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth Day: (DD/MM/YYYY): ");
            DateTime birthDat = DateTime.Parse(Console.ReadLine());

            Client client = new Client(name, email, birthDat);

            Console.WriteLine();
            Console.WriteLine("Enter order data:");
            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());
            Console.Write("How many items to this order? ");
            int hmOrder = int.Parse(Console.ReadLine());

            Order order = new Order(DateTime.Now, status, client);

            for(int i = 1; i <= hmOrder; i++) 
            {
                Console.WriteLine($"Enter #{i} item data:");
                Console.Write("Product name: ");
                string nameProdutc = Console.ReadLine();
                Console.Write("Product price: ");
                double priceProduct = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine()); 

                Product product = new Product(nameProdutc, priceProduct);

                OrderItem orderItem = new OrderItem(quantity, priceProduct, product);

                order.AddOrderItem(orderItem);
            }

            Console.WriteLine();
            Console.WriteLine("ORDER SUMMARY: ");
            Console.WriteLine(order);
            


        }
    }
}