using Orders.Contracts.Customer;
using System;


namespace Orders.Contracts.Order
{
    public class OrderModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Company { get; set; }
        public CustomerModel Customer { get; set; }
        public string Minister { get; set; }
        public string Email { get; set; }
    }
}
