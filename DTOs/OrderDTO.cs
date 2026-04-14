using System;
using System.Collections.Generic;

namespace WindowsFormsApp1.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal AmountTendered { get; set; }
        public decimal Change { get; set; }
        public DateTime CreatedAt { get; set; }
        public int AddedBy { get; set; }
        public string CashierName { get; set; }
        public List<OrderItemDTO> OrderItems { get; set; } = new List<OrderItemDTO>();
    }
}