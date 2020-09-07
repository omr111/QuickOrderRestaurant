using QuickOrder.Dal.Abstract;
using System.Collections.Generic;
using QuickOrder.Bll.Abstract;
using QuickOrder.Entities.Entities.EntityFramework;

namespace QuickOrder.Bll.Concrete
{
    public class SaleProductsDetailBll : ISaleProductsDetailBll

    {
        private ISaleProductsDetailDal _saleProductsDetailDal;
        public SaleProductsDetailBll(ISaleProductsDetailDal saleProductsDetailDal)
        {
            _saleProductsDetailDal = saleProductsDetailDal;
        }
        public bool add(SaleProductsDetails SaleProductsDetails)
        {
            return _saleProductsDetailDal.add(SaleProductsDetails);
        }

        public bool deleteById(int id)
        {
            return _saleProductsDetailDal.delete(getOne(id));
        }

        public List<SaleProductsDetails> getAll()
        {
            return _saleProductsDetailDal.getAll();
        }

        public SaleProductsDetails getOne(int id)
        {
            return _saleProductsDetailDal.getOne(x => x.id == id);
        }

        public bool update(SaleProductsDetails SaleProductsDetails)
        {
            return _saleProductsDetailDal.update(SaleProductsDetails);
        }
    }
}
