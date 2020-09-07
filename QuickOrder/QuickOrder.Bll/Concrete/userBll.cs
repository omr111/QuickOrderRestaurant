using QuickOrder.Dal.Abstract;
using System.Collections.Generic;
using QuickOrder.Bll.Abstract;
using QuickOrder.Entities.Entities.EntityFramework;
using System.Linq;

namespace QuickOrder.Bll.Concrete
{
    public class userBll : IuserBll
    {
        private IuserDal _userDal;
        public userBll(IuserDal userDal)
        {
            _userDal = userDal;
        }
        public users getOneByEmail(string email)
        {
            return _userDal.getOne(x => x.email == email);
        }
        public bool add(users users)
        {
            return _userDal.add(users);
        }

        public bool deleteById(int id)
        {
            return _userDal.delete(getOne(id));
        }

        public List<users> getAll()
        {
            return _userDal.getAll();
        }

        public users getOne(int id)
        {
            return _userDal.getOne(x => x.id == id);
        }

        public bool update(users users)
        {
            return _userDal.update(users);
        }

        public users getOneByEmailAndPassword(string email, string password)
        {
            return _userDal.getOne(x => x.email==email && x.password==password);
        }

        public List<users> getAllWithoutCustomer()
        {
            return _userDal.getAll(x => x.roleOfUsers.Any(y => y.roles.roleName != "customer")).ToList();
        }

        public List<users> getAllJustCustomer()
        {
            return _userDal.getAll(x => x.roleOfUsers.Any(y => y.roles.roleName == "customer")).ToList();
        }
    }
}
