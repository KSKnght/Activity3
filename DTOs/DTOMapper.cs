using System.Collections.Generic;
using System.Linq;
using WindowsFormsApp1.DTOs;

namespace WindowsFormsApp1.DTOs
{
    public static class DTOMapper
    {
        // Product Mappings
        public static ProductDTO ToDTO(Product product)
        {
            if (product == null) return null;

            return new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                ImagePath = product.ImagePath
            };
        }

        public static List<ProductDTO> ToDTO(List<Product> products)
        {
            return products?.Select(ToDTO).ToList() ?? new List<ProductDTO>();
        }

        public static Product ToModel(ProductDTO dto)
        {
            if (dto == null) return null;

            return new Product
            {
                Id = dto.Id,
                Name = dto.Name,
                Price = dto.Price,
                ImagePath = dto.ImagePath
            };
        }

        // User Mappings
        public static UserDTO ToDTO(User user)
        {
            if (user == null) return null;

            return new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
                Role = user.Role
            };
        }

        public static List<UserDTO> ToDTO(List<User> users)
        {
            return users?.Select(ToDTO).ToList() ?? new List<UserDTO>();
        }

        public static User ToModel(UserDTO dto)
        {
            if (dto == null) return null;

            return new User
            {
                Id = dto.Id,
                Name = dto.Name,
                Role = dto.Role
            };
        }

        // Order Mappings
        public static OrderDTO ToDTO(Order order)
        {
            if (order == null) return null;

            return new OrderDTO
            {
                Id = order.Id,
                TotalAmount = order.TotalAmount,
                AmountTendered = order.AmountTendered,
                Change = order.Change,
                OrderItems = order.OrderItems?.Select(item => new OrderItemDTO
                {
                    Id = item.Id,
                    OrderId = order.Id,
                    ProductId = item.ProductId,
                    ProductName = item.ProductName,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice,
                    BasePrice = item.BasePrice,
                    Size = item.Size
                }).ToList() ?? new List<OrderItemDTO>()
            };
        }

        public static Order ToModel(OrderDTO dto)
        {
            if (dto == null) return null;

            return new Order
            {
                Id = dto.Id,
                TotalAmount = dto.TotalAmount,
                AmountTendered = dto.AmountTendered,
                Change = dto.Change,
                OrderItems = dto.OrderItems?.Select(item => new OrderItem
                {
                    Id = item.Id,
                    ProductId = item.ProductId,
                    ProductName = item.ProductName,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice,
                    BasePrice = item.BasePrice,
                    Size = item.Size
                }).ToList() ?? new List<OrderItem>()
            };
        }
    }
}