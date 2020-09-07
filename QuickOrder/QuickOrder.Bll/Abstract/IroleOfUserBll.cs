using QuickOrder.Entities.Entities.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickOrder.Bll.Abstract
{
    public interface IroleOfUserBll
    {
        List<roleOfUsers> getAll();
        roleOfUsers getOne(int id);
        bool add(roleOfUsers roleOfUsers);
        bool update(roleOfUsers roleOfUsers);
        bool deleteById(int id);
        roleOfUsers getOneByRoleIdAndUserId(int roleId,int userId);
        roleOfUsers getOneByUserId(int userId);
        List<roleOfUsers> getAllByEmail(string email);
    }
}
