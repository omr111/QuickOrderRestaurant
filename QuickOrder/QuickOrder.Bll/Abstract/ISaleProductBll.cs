using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickOrder.Entities.Entities.EntityFramework;
namespace QuickOrder.Bll.Abstract
{
    public interface ISaleProductBll
    {
        List<SaleProducts> getAll();
        SaleProducts getOne(int id);
        bool add(SaleProducts SaleProducts);
        bool update(SaleProducts SaleProducts);
        bool deleteById(int id);
    }
}
