using Business.Abstract;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        public void Add(AddOrderDTO dto)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> GetAllOrdersByRable(int tableId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> GetAllOrdersByWaiter(int waiterId)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrder(OrderDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
