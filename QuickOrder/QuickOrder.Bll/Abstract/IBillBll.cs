using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickOrder.Entities.Entities.EntityFramework;
namespace QuickOrder.Bll.Abstract
{
    public interface IBillBll
    {
        List<Bills> getAll();
        Bills getOne(int id);
        Bills getOneIsThereSaleProduct(int id);
        bool add(Bills Bills);
        bool update(Bills Bills);
        bool deleteById(int id);
    }
}
