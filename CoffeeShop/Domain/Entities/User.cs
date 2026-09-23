namespace CoffeeShop.Domain.Entities
{
    public class User
    {
        public User(string username, string password, string name)
        {
            Id = Guid.NewGuid();
            UserName = username;
            Password = password;
            Name = name;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Password { get; set; }

        public string UserName { get; set; }

    }
}
