using CoreWebApi.Models;
using CoreWebApi.MsSqlServerDB;
using CoreWebApi.MsSqlServerDB.Models;
using CoreWebApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.Services
{
    public class OrderStatusService : IOrderStatusService
    {
        private readonly MsSqlServerContext context;

        public OrderStatusService(MsSqlServerContext context)
        {
            this.context = context;
        }

        public async Task<OrderStatusModel> GetOrderStatus(int id)
        {
            OrderStatus orderStatus = await context.OrderStatus.FindAsync(id);
            return new OrderStatusModel
            {
                OrderStatusId = orderStatus.OrderStatusId,
                Name = orderStatus.Name
            };
        }

        public async Task<IEnumerable<OrderStatusModel>> GetOrderStatusList()
        {
            IEnumerable<OrderStatus> orderStatusList = await context.OrderStatus.ToListAsync();
            return orderStatusList.Select(os => new OrderStatusModel
            {
                OrderStatusId = os.OrderStatusId,
                Name = os.Name
            });
        }

        public async Task<OrderStatusModel> DeleteOrderStatus(int id)
        {
            var orderStatus = await context.OrderStatus.FindAsync(id);
            if (orderStatus == null)
            {
                return null;
            }

            context.OrderStatus.Remove(orderStatus);
            await context.SaveChangesAsync();
            return new OrderStatusModel
            {
                OrderStatusId = orderStatus.OrderStatusId,
                Name = orderStatus.Name
            };
        }

        public async Task<bool> OrderStatusExists(int id)
        {
            return await context.OrderStatus.AnyAsync(e => e.OrderStatusId == id);
        }

        public async Task PostOrderStatus(OrderStatusModel orderStatus)
        {
            context.OrderStatus.Add(new OrderStatus
            {
                OrderStatusId = orderStatus.OrderStatusId,
                Name = orderStatus.Name
            });
            await context.SaveChangesAsync();
        }

        public async Task PutOrderStatus(int id, OrderStatusModel orderStatus)
        {
            context.Entry(new OrderStatus
            {
                OrderStatusId = orderStatus.OrderStatusId,
                Name = orderStatus.Name
            }).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
