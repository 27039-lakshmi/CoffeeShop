using CoffeeShop.Domain.Entities;
using CoffeeShop.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Application.Services
{
    internal class MenuService
    {
        public readonly MenuRepo menuRepo = new MenuRepo();
        public void AddMenuItem(MenuItem menuItem)
        {
            this.menuRepo.AddMenuItem(menuItem);
        }

        public MenuItem? GetMenuItemById(int id)
        {
            return this.menuRepo.GetMenuItemById(id);
        }

        public List<MenuItem> GetAllMenuItems()
        {
            return this.menuRepo.GetAllMenuItems();
        }
    }
}
