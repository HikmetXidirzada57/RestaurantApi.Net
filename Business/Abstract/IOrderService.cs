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
        Task UpdateOrder(int id ,Order order);
        void Delete(Order order);
        Order GetById(int id);
        List<Order> GetAllOrders();
        Task<List<Order>> GetAllOrdersByWaiter(int waiterId);
        Task<List<Order>> GetAllOrdersByTable(int tableId);

    }
}
