using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickOrder.Entities.Entities.EntityFramework;
namespace QuickOrder.Bll.Abstract
{
    public interface IrezervationBll
    {
        List<rezervations> getAll();
        rezervations getOne(int id);
        bool add(rezervations rezervations);
        bool update(rezervations rezervations);
        bool deleteById(int id);
    }
}
