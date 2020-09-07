using System;
using System.Collections.Generic;
using QuickOrder.Dal.Abstract;
using QuickOrder.Bll.Abstract;
using QuickOrder.Entities.Entities.EntityFramework;

namespace QuickOrder.Bll.Concrete
{
    public class roleBll : IroleBll
    {
        private IroleDal _roleDal;
        public roleBll(IroleDal roleDal)
        {
            _roleDal = roleDal;
        }
        public bool add(roles roles)
        {
            return _roleDal.add(roles);
        }

        public bool deleteById(int id)
        {
            return _roleDal.delete(getOne(id));
        }

        public List<roles> getAll()
        {
            return _roleDal.getAll();
        }

        public roles getOne(int id)
        {
            return _roleDal.getOne(x => x.id == id);
        }

        public bool update(roles roles)
        {
            return _roleDal.update(roles);
        }
    }
}
