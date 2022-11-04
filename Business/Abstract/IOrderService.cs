using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOrderService
    {
        void Add(AddOrderDTO dto);
        void UpdateOrder(OrderDTO dto);
        void Delete(int id);
        Task<List<Order>> GetAllOrders();
        Task<List<Order>> GetAllOrdersByWaiter(int waiterId);
        Task<List<Order>> GetAllOrdersByRable(int tableId);
    }
}
