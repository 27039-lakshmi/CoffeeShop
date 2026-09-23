using CoffeeShop.Domain.Entities;
using CoffeeShop.Infrastructure.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Infrastructure.Repository
{
    internal class OrderRepo
    {
        private readonly FileHelper filehelper = new FileHelper("Data/orders.json");
        private Dictionary<Order, System.Timers.Timer> coffeeMachines = new();
        public Queue<Order> orderQueue = new Queue<Order>();
        private int coffeeMachineCount = 2;

        internal void AddOrderToMachine(Order order)
        {
            var timer = new System.Timers.Timer();
            coffeeMachines[order] = timer;
            timer.AutoReset = false;
        }

        internal void AddOrderToQueue(Order order)
        {
            throw new NotImplementedException();
        }

        public int GetAvaialableSlots () { return coffeeMachineCount - coffeeMachines.Count; } 
    }
}
