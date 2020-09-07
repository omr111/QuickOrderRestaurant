using QuickOrder.Dal.Abstract;
using System.Collections.Generic;
using QuickOrder.Bll.Abstract;
using QuickOrder.Entities.Entities.EntityFramework;

namespace QuickOrder.Bll.Concrete
{
    public class roleOfUserBll : IroleOfUserBll
    {
        private IroleOfUserDal _roleOfUserDal;
        public roleOfUserBll(IroleOfUserDal roleOfUserDal)
        {
            _roleOfUserDal = roleOfUserDal;
        }
        public bool add(roleOfUsers roleOfUsers)
        {
            return _roleOfUserDal.add(roleOfUsers);
        }

        public bool deleteById(int id)
        {
            return _roleOfUserDal.delete(getOne(id));
        }

        public List<roleOfUsers> getAll()
        {
            return _roleOfUserDal.getAll();
        }

        public List<roleOfUsers> getAllByEmail(string email)
        {
            return _roleOfUserDal.getAll(x => x.users.email == email);
        }

        public roleOfUsers getOne(int id)
        {
            return _roleOfUserDal.getOne(x => x.id == id);
        }

        public roleOfUsers getOneByRoleIdAndUserId(int roleId, int userId)
        {
            return _roleOfUserDal.getOne(x => x.id == roleId&&x.userID==userId);
        }

        public roleOfUsers getOneByUserId(int userId)
        {
            return _roleOfUserDal.getOne(x => x.userID == userId);
        }

        public bool update(roleOfUsers roleOfUsers)
        {
            return _roleOfUserDal.update(roleOfUsers);
        }
    }
}
