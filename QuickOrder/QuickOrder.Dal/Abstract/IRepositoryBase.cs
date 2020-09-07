using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QuickOrder.Dal.Abstract
{
    public interface IRepositoryBase<T> where T:class
    {
        List<T> getAll(Expression<Func<T, bool>> filter=null);
        T getOne(Expression<Func<T, bool>> filter);
        bool add(T entity);
        bool update(T entity);
        bool delete(T entity);
    }
}
