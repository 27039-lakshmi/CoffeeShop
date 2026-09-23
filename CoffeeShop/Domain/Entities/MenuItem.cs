namespace CoffeeShop.Domain.Entities
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PreparationTime { get; set; }

        public decimal Price { get; set; }
    }
}
