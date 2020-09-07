using QuickOrder.Bll.Abstract;
using QuickOrder.Dal.Abstract;
using QuickOrder.Entities.Entities.EntityFramework;
using System.Collections.Generic;

namespace QuickOrder.Bll.Concrete
{
    public class BannerBll : IBannerBll
    {
        private IBannerDal _bannerDal;
        public BannerBll(IBannerDal bannerDal)
        {
            _bannerDal = bannerDal;
        }
        public bool add(banners banner)
        {
            return _bannerDal.add(banner);
        }

        public bool deleteById(int id)
        {
            return _bannerDal.delete(getOne(id));
        }

        public List<banners> getAll()
        {
            return _bannerDal.getAll();
        }

        public banners getOne(int id)
        {
            return _bannerDal.getOne(x => x.id == id);
        }

        public bool update(banners banners)
        {
            return _bannerDal.update(banners);
        }
    }
}
