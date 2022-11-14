using Business.Abstract;
using DataAccess.Abstract;
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

        private readonly IOrderDal _dal;

        public OrderManager(IOrderDal dal)
        {
            _dal = dal;
        }

        public void Add(AddOrderDTO dto)
        {
           Order order = new Order()
           {
               ModifiedDate = dto.ModifiedDate,
               PurchaseDate=DateTime.Now,
               WaiterId=dto.WaiterId,
               TableId=dto.TableId,
                TotalPrice=dto.TotalPrice,
           };
            _dal.Add(order);
        }

        public void Delete(Order order)
        {
            _dal.Delete(order);
        }

        public List<Order> GetAllOrders()
        {
           return  _dal.GetAllOrders();
        }

        public async Task<List<Order>> GetAllOrdersByTable(int tableId)
        {
            return await _dal.GetAllOrdersByTable(tableId);
        }

        public Task<List<Order>> GetAllOrdersByWaiter(int waiterId)
        {
            return _dal.GetAllOrdersByWaiter(waiterId);
        }

        public Order GetById(int id)
        {
           return _dal.Get(x=>x.Id==id);
        }

        public async Task UpdateOrder(int id, Order order)
        {
           await _dal.UpdateOrder(id ,order);
        }
    }
}
