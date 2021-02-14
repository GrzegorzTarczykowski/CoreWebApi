using CoreWebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreWebApi.Services.Interfaces
{
    public interface IOrderStatusService
    {
        Task<IEnumerable<OrderStatusModel>> GetOrderStatusList();
        Task<OrderStatusModel> GetOrderStatus(int id);
        Task PutOrderStatus(int id, OrderStatusModel orderStatus);
        Task PostOrderStatus(OrderStatusModel orderStatus);
        Task<OrderStatusModel> DeleteOrderStatus(int id);
        Task<bool> OrderStatusExists(int id);
    }
}
