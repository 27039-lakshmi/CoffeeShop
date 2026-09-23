namespace CoffeeShop.Domain.Entities
{
    public class MenuItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int PreparationTime { get; set; }

        public decimal Cost { get; set; }
    }
}
