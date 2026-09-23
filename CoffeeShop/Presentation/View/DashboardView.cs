using CoffeeShop.Presentation.Validators;
using CoffeeShop.Infrastructure.Repository;
using CoffeeShop.Application.Services;
using CoffeeShop.Domain.Entities;

namespace CoffeeShop.Presentation.View
{
    public class DashboardView
    {
        private MenuService menuService = new MenuService();
        private OrderService orderService = new OrderService();
        public void DisplayDashboard(User user)
        {            
            do
            {
                Console.WriteLine("Welcome "+user.Name);
                Console.WriteLine("[1] Display Coffee Menu\n" +
                                  "[2] Order Coffee\n" +
                                  "[3] Logout");
                if (!Validator.IsValidInteger(Console.ReadLine()!, out int userChoice))
                {
                    Console.WriteLine("Choice must be an integer");
                    continue;
                }
                switch (userChoice)
                {
                    case 1:
                        DisplayMenu();
                        break;
                    case 2:
                        DisplayOrderPage(user);
                        break;
                    case 3:
                        break;
                }
            }
            while (true);
        }

        private void DisplayOrderPage(User user)
        {
            var menu = this.menuService.GetAllMenuItems();
            for(int i = 0; i < menu.Count; i++)
            {
                Console.WriteLine($"{i+1}. {menu[i].Name} Price:{menu[i].Price} Preparation Time:{menu[i].PreparationTime}");
            }
            var orderItems = new List<MenuItem>();
            do
            {
                Console.WriteLine("Enter your coffee number");
                Console.WriteLine("press enter to exit");
                string input = Console.ReadLine() ?? string.Empty;
                if (input == "exit") break;
                if (!Validator.IsValidInteger(input, out int itemNo))
                {
                    Console.WriteLine("Enter valid integer");
                    return;
                }
                orderItems.Add(menu[itemNo - 1]);
            }
            while (true);
            this.orderService.ProcessOrder(user, orderItems);
        }

        private void DisplayMenu()
        {
            var menu = this.menuService.GetAllMenuItems();
            foreach (var menuItem in menu)
            {
                Console.WriteLine($"- {menuItem.Name}: ${menuItem.Price} :{menuItem.PreparationTime}");
            }
            ClearScreen();
        }

        private void ClearScreen()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
