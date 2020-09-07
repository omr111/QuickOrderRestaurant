using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickOrder.Entities.Entities.EntityFramework;
namespace QuickOrder.Bll.Abstract
{
    public interface IreviewBll
    {
        List<reviews> getAll();
        reviews getOne(int id);
        bool add(reviews reviews);
        bool update(reviews reviews);
        bool deleteById(int id);
    }
}
