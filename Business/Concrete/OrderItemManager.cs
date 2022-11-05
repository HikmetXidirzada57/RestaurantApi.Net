using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OrderItemManager : IOrderItemService
    {
        public void Add(OrderInfo orderInfo)
        {
            throw new NotImplementedException();
        }

        public Task<List<OrderInfo>> GetAllList()
        {
            throw new NotImplementedException();
        }

        public void Remove(OrderInfo orderInfo)
        {
            throw new NotImplementedException();
        }

        public void Update(OrderInfo orderInfo)
        {
            throw new NotImplementedException();
        }
    }
}
