using CoffeeShop.Domain.Enums;

namespace CoffeeShop.Domain.Entities
{
    public class Order
    {
        public Order(Guid id, List<MenuItem> orderItems, decimal totalCost, OrderStatus status)
        {
            Id = Guid.NewGuid();
            UserId = id;
            OrderItems = orderItems;
            TotalCost = totalCost;
            OrderedAt = DateTime.Now;
            Status = status;

        }

        public Guid Id { get; set; }
        public List<MenuItem> OrderItems { get; set; }
        public Guid UserId { get; set; }
        public decimal TotalCost { get; set; }

        public DateTime OrderedAt { get; set; }
        public OrderStatus Status { get; set; }

    }
}
