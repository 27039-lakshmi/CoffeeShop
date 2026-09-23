using CoffeeShop.Domain.Entities;
using CoffeeShop.Infrastructure.Repository;
using System.Security.Cryptography;
using System.Text;

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

        public string HashPassword(string password)
        {
            byte[] hashBytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
            return Convert.ToHexString(hashBytes);
        }
    }
}
