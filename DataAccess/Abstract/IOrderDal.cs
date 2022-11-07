using Core.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IOrderDal:IEntityRepository<Order>
    {
        Task<List<Order>> GetAllOrders();
        Task<List<Order>> GetAllOrdersByWaiter(int waiterId);
        Task<List<Order>> GetAllOrdersByTable(int tableId);
        Task UpdateOrder( int id ,Order order);
    }
}
