using QuickOrder.Entities.Entities.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickOrder.Bll.Abstract
{
    public interface ICategoryBll
    {
        List<Categories> getAll();
        Categories getOne(int id);
        Categories getOneByName(string name);
        bool add(Categories Categories);
        bool update(Categories Categories);
        bool deleteById(int id);
    }
}
