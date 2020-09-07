using System;
using System.Collections.Generic;
using QuickOrder.Dal.Abstract;
using QuickOrder.Bll.Abstract;
using QuickOrder.Entities.Entities.EntityFramework;
namespace QuickOrder.Bll.Concrete
{
    public class rezervationBll : IrezervationBll
    {
        private IrezervationDal _rezervationDal;
        public rezervationBll(IrezervationDal rezervationDal)
        {
            _rezervationDal = rezervationDal;
        }
        public bool add(rezervations rezervations)
        {
            return _rezervationDal.add(rezervations);
        }

        public bool deleteById(int id)
        {
            return _rezervationDal.delete(getOne(id));
        }

        public List<rezervations> getAll()
        {
            return _rezervationDal.getAll();
        }

        public rezervations getOne(int id)
        {
            return _rezervationDal.getOne(x=>x.id==id);
        }

        public bool update(rezervations rezervations)
        {
            return _rezervationDal.update(rezervations);
        }
    }
}
