using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abstract
{
    public interface IEntityRepository<TEntity>
    {
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
        List<TEntity>GetAll(Expression<Func<TEntity, bool>> filter=null); 
        TEntity Get(Expression<Func<TEntity, bool>> filter);
    }
}
