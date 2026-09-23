using CoffeeShop.Infrastructure.Repository;
using CoffeeShop.Infrastructure.Helper;
using CoffeeShop.Application.Services;
using CoffeeShop.Presentation.View;

namespace CoffeeShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string userDataFilePath = "Data/users.json";
            var userRepo = new UserRepo(new FileHelper(userDataFilePath));
            var userService = new UserService(userRepo);
            var authenticationView = new AuthenticationView(userService);
            authenticationView.DisplayAuthenticationPage();

        }
    }
}
