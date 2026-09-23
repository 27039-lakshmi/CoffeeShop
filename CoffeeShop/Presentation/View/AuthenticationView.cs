using CoffeeShop.Application.Services;
using CoffeeShop.Presentation.Validators;
using CoffeeShop.Domain.Entities;
using System.Text;
using System.Security.Cryptography;

namespace CoffeeShop.Presentation.View
{
    public class AuthenticationView
    {
        private UserService userService;
        private DashboardView dashboardView = new();

        public AuthenticationView(UserService userService)
        {
            this.userService = userService;
        }

        public void DisplayAuthenticationPage()
        {
            do
            {
                Console.WriteLine("[1] Login\n" +
                                  "[2] Signup\n" +
                                  "[3] Exit\n" +
                                  "Enter your choice");
                if (!Validator.IsValidInteger(Console.ReadLine()!, out int userChoice))
                {
                    Console.WriteLine("Choice must be an integer");
                    continue;
                }
                switch (userChoice)
                {
                    case 1:
                        DisplayLoginPage();
                        break;
                    case 2:
                        DisplaySignupPage();
                        break;
                    case 3:
                        break;
                }
            }
            while (true);
        }

        private void DisplaySignupPage()
        {
            string? username = GetUsernameInput();
            if (username == null)
            {
                return;
            }
            if (this.userService.DoesUserExist(username))
            {
                Console.WriteLine("Username already exist");
                return;
            }
            string password = GetPasswordInput();
            string? name = GetNameInput();
            if (name == null)
            {
                return;
            }
            this.userService.AddUser(new User(username, password, name));
            Console.WriteLine("User Added successfully");
            ClearScreen();
        }

        private string? GetNameInput()
        {
            Console.WriteLine("Enter name");
            string name = Console.ReadLine() ?? string.Empty;
            string? failureResult = null;
            if (!Validator.IsValidName(name))
            {
                Console.WriteLine("Name should not contain digits or symbols");
                return failureResult;
            }
            return name;
        }

        private string GetPasswordInput()
        {
            Console.WriteLine("Enter password");
            var password = new StringBuilder();
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter) break;
                if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password.Remove(password.Length - 1, 1);
                    Console.Write("\b \b");
                }
                else if (!char.IsControl(key.KeyChar))
                {
                    password.Append(key.KeyChar);
                    Console.Write("*");
                }
            }
            Console.WriteLine();
            return this.userService.HashPassword(password.ToString());
        }

        
        private string? GetUsernameInput()
        {
            Console.WriteLine("Enter username");
            string username = Console.ReadLine() ?? string.Empty;
            string? failureResult = null;
            if (!Validator.IsValidUsername(username))
            {
                Console.WriteLine("Username should not contain spaces");
                return failureResult;
            }
            return username;
        }

        private void DisplayLoginPage()
        {
            string? username = GetUsernameInput();
            if (username == null)
            {
                return;
            }
            if (!this.userService.DoesUserExist(username))
            {
                Console.WriteLine("Username doesnt exist");
                return;
            }
            string password = GetPasswordInput();
            if (!this.userService.AuthenticateUser(username, password))
            {
                Console.WriteLine("Password incorrect");
                return;
            }
            Console.WriteLine("Logged In successfully");
            ClearScreen();
            var user = this.userService.GetUserByUsername(username);
            dashboardView.DisplayDashboard(user);
        }

        private void ClearScreen()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
