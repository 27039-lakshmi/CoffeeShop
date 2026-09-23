using CoffeeShop.Domain.Entities;
using CoffeeShop.Infrastructure.Helper;

namespace CoffeeShop.Infrastructure.Repository
{
    internal class MenuRepo
    {
        private readonly FileHelper filehelper = new FileHelper("Data/menuitem.json");
        public void AddMenuItem(MenuItem menuItem)
        {
            var menuItems = GetAllMenuItems();
            menuItems.Add(menuItem);
            this.filehelper.WriteIntoFile(menuItems);
        }

        public List<MenuItem> GetAllMenuItems()
        {
            var menuItems = this.filehelper.ReadFromFile<MenuItem>();
            return menuItems;
        }

        public MenuItem? GetMenuItemById(int id)
        {
            var menuItems = this.GetAllMenuItems();
            var menuItem = menuItems.FirstOrDefault(item => item.Id == id);
            return menuItem;
        }
    }
}
