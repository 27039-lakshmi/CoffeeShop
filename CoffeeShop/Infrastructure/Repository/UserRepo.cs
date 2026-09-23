using CoffeeShop.Domain.Entities;
using CoffeeShop.Infrastructure.Helper;
namespace CoffeeShop.Infrastructure.Repository
{
    public class UserRepo
    {
        private readonly FileHelper filehelper;
        public UserRepo(FileHelper filehelper)
        {
            this.filehelper = filehelper;
        }
        public void AddUser(User user)
        {
            var users = GetAllUsers();
            users.Add(user);
            this.filehelper.WriteIntoFile(users);
        }

        public List<User> GetAllUsers()
        {
            var users = this.filehelper.ReadFromFile<User>();
            return users;
        }

        public User? GetUserByUsername(string username)
        {
            var users = this.GetAllUsers();
            var user = users.FirstOrDefault(user => user.UserName == username);
            return user;
        }
    }
}
