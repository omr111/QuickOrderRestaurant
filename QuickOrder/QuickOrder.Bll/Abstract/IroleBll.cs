using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickOrder.Entities.Entities.EntityFramework;
namespace QuickOrder.Bll.Abstract
{
    public interface IroleBll
    {
        List<roles> getAll();
        roles getOne(int id);
        bool add(roles roles);
        bool update(roles roles);
        bool deleteById(int id);
    }
}
