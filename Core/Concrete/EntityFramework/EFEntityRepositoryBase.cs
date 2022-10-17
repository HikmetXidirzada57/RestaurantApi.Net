using Core.Abstract;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concrete.EntityFramework
{
    public class EFEntityRepositoryBase< TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using TContext context = new();
            var myEntity = context.Entry(entity);
            myEntity.State = EntityState.Added;
            context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            using TContext context = new();
            var myEntity = context.Entry(entity);
            myEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using TContext context = new();
            return context.Set<TEntity>().FirstOrDefault(filter);
        }

        public List<TEntity>GetAll(Expression<Func<TEntity, bool>> filter)
        {
            using TContext context = new();
            return filter == null
                 ? context.Set<TEntity>().ToList()
                 : context.Set<TEntity>().Where(filter).ToList();
        }

        public void Update(TEntity entity)
        {
            using TContext context = new();
            var updateEntity = context.Entry(entity);
            updateEntity.State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
