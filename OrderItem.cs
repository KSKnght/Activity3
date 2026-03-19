using System;

namespace WindowsFormsApp1
{
    public class OrderItem
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal BasePrice { get; set; }
        public string Size { get; set; }
        public int ProductId { get; set; }
        public decimal TotalPrice => Quantity * UnitPrice;
    }
}
