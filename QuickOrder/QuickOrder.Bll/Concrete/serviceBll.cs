using QuickOrder.Dal.Abstract;
using System.Collections.Generic;
using QuickOrder.Bll.Abstract;
using QuickOrder.Entities.Entities.EntityFramework;

namespace QuickOrder.Bll.Concrete
{
    public class serviceBll : IserviceBll
    {
        private IserviceDal _serviceDal;
        public serviceBll(IserviceDal serviceDal)
        {
            _serviceDal = serviceDal;
        }
        public bool add(services services)
        {
            return _serviceDal.add(services);
        }

        public bool deleteById(int id)
        {
            return _serviceDal.delete(getOne(id));
        }

        public List<services> getAll()
        {
            return _serviceDal.getAll();
        }

        public services getOne(int id)
        {
            return _serviceDal.getOne(x => x.id == id);
        }

        public bool update(services services)
        {
            return _serviceDal.update(services);
        }
    }
}
