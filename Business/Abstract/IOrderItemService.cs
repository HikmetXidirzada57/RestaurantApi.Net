using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOrderItemService
    {
        void Add(OrderInfo orderInfo);
        void Remove(OrderInfo orderInfo);
        void Update(OrderInfo orderInfo);
        Task<List<OrderInfo>> GetAllList();
    }
}
