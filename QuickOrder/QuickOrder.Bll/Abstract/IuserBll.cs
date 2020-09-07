using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickOrder.Entities.Entities.EntityFramework;
namespace QuickOrder.Bll.Abstract
{
    public interface IuserBll
    {
        List<users> getAll();
        List<users> getAllWithoutCustomer();
        List<users> getAllJustCustomer();
        users getOne(int id);
        bool add(users users);
        bool update(users users);
        bool deleteById(int id);
        users getOneByEmail(string email);
        users getOneByEmailAndPassword(string email, string password);
    }
}
