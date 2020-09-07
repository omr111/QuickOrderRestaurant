using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickOrder.Entities.Entities.EntityFramework;
namespace QuickOrder.Bll.Abstract
{
    public interface IserviceBll
    {
        List<services> getAll();
        services getOne(int id);
        bool add(services services);
        bool update(services services);
        bool deleteById(int id);
    }
}
