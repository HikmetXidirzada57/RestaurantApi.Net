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
    public class EFWaiterDal : EFEntityRepositoryBase<Waiter, RestaurantDbContext>, IWaiterDal
    {
        public async Task<List<Waiter>> GetAll()
        {
            RestaurantDbContext context = new();
            return await context.Waiters.Where(x => !x.IsDeleted).ToListAsync();
        }

        public async Task<Waiter> GetByid(int id)
        {
            RestaurantDbContext context = new();
            return await context.Waiters.Where(x=>!x.IsDeleted).FirstOrDefaultAsync();
        }
    }
}
