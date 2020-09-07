using System;
using System.Collections.Generic;
using QuickOrder.Dal.Abstract;
using QuickOrder.Bll.Abstract;
using QuickOrder.Entities.Entities.EntityFramework;
using System.Linq;

namespace QuickOrder.Bll.Concrete
{
    public class BillBll : IBillBll
    {
        private IBillDal _billDal;
        public BillBll(IBillDal billDal)
        {
            _billDal = billDal;
        }
        public bool add(Bills Bills)
        {
            return _billDal.add(Bills);
        }

        public bool deleteById(int id)
        {
            return _billDal.delete(getOne(id));
        }

        public List<Bills> getAll()
        {
            return _billDal.getAll();
        }

        public Bills getOne(int id)
        {
            return _billDal.getOne(x => x.id == id);
        }

        public Bills getOneIsThereSaleProduct(int id)
        {
            return _billDal.getOne(x => x.SaleProducts.Any(y => y.id == id));
        }

        public bool update(Bills Bills)
        {
            return _billDal.update(Bills);
        }
    }
}
