using Projeto_Pedidos.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Pedidos.Entities
{
    internal class Order
    {
        public DateTime Moment = new DateTime();
        public Client Client = new Client();
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();  

        public Order()
        {

        }

        public Order(DateTime moment, Client client) { 
            Moment = moment;
            Client = client;
        }


        public void AddItem(OrderItem orderItem)
        {
            OrderItems.Add(orderItem);
            
        }

        public void RemoveItem(OrderItem orderItem)
        {
            OrderItems.Remove(orderItem);

        }
              

        public double Total()
        {
            double total = 0;
            foreach (OrderItem item in OrderItems)
            {
                total += item.SubTotal();
            }

            return total;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Order moment: " + Moment.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.AppendLine("Client: " + Client);
            sb.AppendLine("Order items:");
            foreach (OrderItem item in OrderItems)
            {
                sb.AppendLine(item.ToString());
            }
            sb.AppendLine("Total price: $" + Total().ToString("F2", CultureInfo.InvariantCulture));
            return sb.ToString();
        }
    }
}
