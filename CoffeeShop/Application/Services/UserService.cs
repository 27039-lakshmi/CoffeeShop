using CoffeeShop.Infrastructure.Repository;
using CoffeeShop.Domain.Entities;

namespace CoffeeShop.Application.Services
{
    public class UserService
    {
        public readonly UserRepo userRepo;

        public UserService(UserRepo userRepo)
        {
            this.userRepo = userRepo;
        }

        public void AddUser(User user)
        {
            this.userRepo.AddUser(user);
        }

        public User? GetUserByUsername(string username)
        {
            return this.userRepo.GetUserByUsername(username);
        }

        public bool DoesUserExist(string username)
        {
            if (this.GetUserByUsername(username) == null) return false;
            else return true;
        }

        public bool AuthenticateUser(string username, string password)
        {
            var user = this.GetUserByUsername(username);
            return user != null && user.Password == password;
        }
    }
}
