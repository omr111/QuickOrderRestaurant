using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickOrder.Entities.Entities.EntityFramework;
namespace QuickOrder.Bll.Abstract
{
    public interface IPhoneBll
    {
        List<Phones> getAll();
        Phones getOne(int id);
        bool add(Phones Phones);
        bool update(Phones Phones);
        bool deleteById(int id);
        Phones getOneByNumberAndCompanyId(string phone, int companyId);
    }
}
