using Course.Entities.Enums;
using System.Globalization;
using System.Text;
using System.Xml.Linq;

namespace Course.Entities
{
    class Order
    {
        public DateTime Moment { get; set; }
        OrderStatus Status { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> OrderItem { get; set;} = new List<OrderItem>();

        public Order() 
        { 
        }
        public Order(DateTime moment, OrderStatus status, Client client) {
            Moment = moment;
            Status = status;
            Client = client;
        }

        public void AddOrderItem(OrderItem orderItem)
        {
            OrderItem.Add(orderItem);
        }
        public void RemoveOrderItem(OrderItem orderItem)
        {
            OrderItem.Remove(orderItem);
        }

        public double Total()
        {
            double total = 0.00; 
            foreach (OrderItem orderItem in OrderItem) 
            {
                total += orderItem.SubTotal();     
            }
            return total;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Order moment: ");
            sb.AppendLine(Moment.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.Append("Order Status: ");
            sb.AppendLine(Status.ToString());

            sb.Append("Client: ");
            sb.Append(Client.Name);
            sb.Append(" (" + Client.BirthDate.ToString("dd/MM/yyyy") + ") - ");
            sb.AppendLine(Client.Email);

            sb.AppendLine("Order items:");
            foreach (OrderItem orderItem in OrderItem)
            {
                sb.AppendLine(orderItem.ToString());
            }
            sb.AppendLine("Total Price: $" + Total().ToString("F2", CultureInfo.InvariantCulture));

            return sb.ToString();
        }
    }
}
