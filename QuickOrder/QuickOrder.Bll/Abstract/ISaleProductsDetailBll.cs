using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickOrder.Entities.Entities.EntityFramework;
namespace QuickOrder.Bll.Abstract
{
    public interface ISaleProductsDetailBll
    {
        List<SaleProductsDetails> getAll();
        SaleProductsDetails getOne(int id);
        bool add(SaleProductsDetails SaleProductsDetails);
        bool update(SaleProductsDetails SaleProductsDetails);
        bool deleteById(int id);
    }
}
