using QuickOrder.Dal.Abstract;
using QuickOrder.Entities.Entities.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QuickOrder.Dal.Concrete
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        QuickOrderContext ctx = new QuickOrderContext();
        public bool add(T entity)
        {
            ctx.Entry(entity).State = EntityState.Added;
            return ctx.SaveChanges() > 0 ? true : false;
        }

        public bool delete(T entity)
        {

            ctx.Entry(entity).State = EntityState.Deleted;
            return ctx.SaveChanges() > 0 ? true : false;
        }

        public List<T> getAll(Expression<Func<T, bool>> filter = null)
        {
            if (filter!=null)
                return ctx.Set<T>().Where(filter).ToList();
            return ctx.Set<T>().ToList();
            
        }

        public T getOne(Expression<Func<T, bool>> filter)
        {
            return ctx.Set<T>().FirstOrDefault(filter);
        }

        public bool update(T entity)
        {
            ctx.Entry(entity).State = EntityState.Modified;
            return ctx.SaveChanges() > 0? true:false;
        }
    }
}
