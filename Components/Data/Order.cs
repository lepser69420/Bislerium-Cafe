using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeCoffee.Components.Data
{
    // Order Class - Use to store orders info 
    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public string OrderItem { get; set; }
        public DateTime Date { get; set; }
        public float TotalBill { get; set; }
        public float Discount { get; set; }
        public float TotalPaid { get; set; }


        public Order()
        {

        }

        public Order(int id, string name, string phone, string order, DateTime odate, float tbill, float discount, float pbill)
        {
            Id = id;
            CustomerName = name;
            PhoneNumber = phone;
            OrderItem = order;
            Date = odate;
            TotalBill = tbill;
            Discount = discount;
            TotalPaid = pbill;
        }
    }
}
