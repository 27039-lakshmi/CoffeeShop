using CoffeeShop.Domain.Enums;

namespace CoffeeShop.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public List<MenuItem> MenuItems { get; set; }
        public Guid UserId { get; set; }
        public int TotalCost { get; set; }
        public int OrderId { get; set; }
        public OrderStatus Status { get; set; }

    }
}
