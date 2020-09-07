using System;
using System.Collections.Generic;
using QuickOrder.Dal.Abstract;
using QuickOrder.Bll.Abstract;
using QuickOrder.Entities.Entities.EntityFramework;
namespace QuickOrder.Bll.Concrete
{
    public class ProductBll : IProductBll
    {
        private IProductDal _productDal;
        public ProductBll(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public bool add(Products Products)
        {
            return _productDal.add(Products);
        }

        public bool deleteById(int id)
        {
            return _productDal.delete(getOne(id));
        }

        public List<Products> getAll()
        {
            return _productDal.getAll();
        }

        public Products getOne(int id)
        {
            return _productDal.getOne(x => x.id == id);
        }

        public bool update(Products Products)
        {
            return _productDal.update(Products);
        }
    }
}
