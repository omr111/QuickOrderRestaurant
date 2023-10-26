using QuickOrder.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickOrder.Bll.Abstract
{
    public interface IPromotionBll
    {
        List<Promotion> getAll();
        Promotion getOne(int id);
        Promotion getOneByName(string name);
        bool add(Promotion Promotion);
        bool update(Promotion Promotion);
        bool deleteById(int id);


    }
}
