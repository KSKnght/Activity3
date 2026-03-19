using System;
using System.Collections.Generic;

namespace WindowsFormsApp1
{
    public class Order
    {
        public int Id { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal AmountTendered { get; set; }
        public decimal Change { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}