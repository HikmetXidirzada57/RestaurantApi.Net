using CloudinaryDotNet.Actions;
using Core.Concrete.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFOrderDal : EFEntityRepositoryBase<Order, RestaurantDbContext>, IOrderDal
    {
        public async Task<List<Order>> GetAllOrders()
        {
            using RestaurantDbContext context = new ();
            return await context.Orders.Include(x=>x.Waiter).
                Include(x=>x.Table).
                Include(x=>x.OrderItem).
                ThenInclude(x=>x.Status).ToListAsync();
        }

        public async Task<List<Order>> GetAllOrdersByTable(int tableId)
        {
            using RestaurantDbContext context=new ();
            return await context.Orders.Include(x => x.Waiter).
                Include(x => x.Table). 
                Include(x => x.OrderItem).
                ThenInclude(x => x.Status).Where(x => x.TableId == tableId).ToListAsync();
        }

        public async Task<List<Order>> GetAllOrdersByWaiter(int waiterId)
        {
            using RestaurantDbContext context = new ();

            return await context.Orders.Include(x => x.Waiter).
                Include(x => x.Table).
                Include(x => x.OrderItem).
                ThenInclude(x => x.Status).Where(x => x.WaiterId==waiterId).ToListAsync();
        }

        public async Task UpdateOrder(int id ,Order order)
        {
            using RestaurantDbContext context = new ();
            context.Orders.Update(order);
            await context.SaveChangesAsync();
        }
    }
}
