using QuickOrder.Dal.Abstract;
using System.Collections.Generic;
using QuickOrder.Bll.Abstract;
using QuickOrder.Entities.Entities.EntityFramework;

namespace QuickOrder.Bll.Concrete
{
    public class SaleProductBll : ISaleProductBll
    {
        private ISaleProductDal _saleProductDal;
        public SaleProductBll(ISaleProductDal saleProductDal)
        {
            _saleProductDal = saleProductDal;
        }
        public bool add(SaleProducts SaleProducts)
        {
            return _saleProductDal.add(SaleProducts);
        }

        public bool deleteById(int id)
        {
            return _saleProductDal.delete(getOne(id));
        }

        public List<SaleProducts> getAll()
        {
            return _saleProductDal.getAll();
        }

      
        public SaleProducts getOne(int id)
        {
            return _saleProductDal.getOne(x => x.id == id);
        }
        public bool update(SaleProducts SaleProducts)
        {
            return _saleProductDal.update(SaleProducts);
        }
    }
}
