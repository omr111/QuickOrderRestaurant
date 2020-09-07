using System;
using System.Collections.Generic;
using QuickOrder.Dal.Abstract;
using QuickOrder.Bll.Abstract;
using QuickOrder.Entities.Entities.EntityFramework;
namespace QuickOrder.Bll.Concrete
{
    public class reviewBll : IreviewBll
    {
        private IreviewDal _reviewDal;
        public reviewBll(IreviewDal reviewDal)
        {
            _reviewDal = reviewDal;
        }
        public bool add(reviews reviews)
        {
            return _reviewDal.add(reviews);
        }

        public bool deleteById(int id)
        {
            return _reviewDal.delete(getOne(id));
        }

        public List<reviews> getAll()
        {
            return _reviewDal.getAll();
        }

        public reviews getOne(int id)
        {
            return _reviewDal.getOne(x => x.id == id);
        }

        public bool update(reviews reviews)
        {
            return _reviewDal.update(reviews);
        }
    }

}
