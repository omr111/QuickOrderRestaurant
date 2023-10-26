using QuickOrder.Bll.Abstract;
using QuickOrder.Dal.Abstract;
using QuickOrder.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickOrder.Bll.Concrete
{
  
    public class PromotionBll : IPromotionBll
    {
        private IPromotionDal _PromotionDal;
        public PromotionBll(IPromotionDal PromotionDal)
        {
            _PromotionDal = PromotionDal;
        }
        public bool add(Promotion Promotion)
        {
            return _PromotionDal.add(Promotion);
        }

        public bool deleteById(int id)
        {
            return _PromotionDal.delete(getOne(id));
        }

        public List<Promotion> getAll()
        {
            return _PromotionDal.getAll();
        }

        public Promotion getOne(int id)
        {
            return _PromotionDal.getOne(x => x.id == id);
        }

        public Promotion getOneByName(string name)
        {
            return _PromotionDal.getOne(x => x.PromotionKey == name);
        }

        public bool update(Promotion Promotion)
        {
            return _PromotionDal.update(Promotion);
        }
    }
}