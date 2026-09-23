using CoffeeShop.Domain.Entities;
using CoffeeShop.Domain.Enums;
using CoffeeShop.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Application.Services
{
    internal class OrderService
    {
        public readonly OrderRepo orderRepo = new OrderRepo();

        internal void ProcessOrder(User user, List<MenuItem> orderItems)
        {
            decimal totalCost = orderItems.Sum(item => item.Price);
            orderRepo.orderQueue.Enqueue(new Order(user.Id, orderItems, totalCost, OrderStatus.Waiting));
            //if(orderRepo.GetAvaialableSlots() > 0)
            //{
            //    var order = new Order(user.Id, orderItems,totalCost,OrderStatus.Making);
            //    orderRepo.AddOrderToMachine(order);
            //}
            //else
            //{
            //    var order = new Order(user.Id, orderItems, totalCost, OrderStatus
            //    .Waiting);
            //    orderRepo.AddOrderToQueue(order);
            //}
        }
    }
}
