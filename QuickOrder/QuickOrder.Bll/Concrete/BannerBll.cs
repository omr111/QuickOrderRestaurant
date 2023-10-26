using QuickOrder.Bll.Abstract;
using QuickOrder.Dal.Abstract;
using QuickOrder.Entities.Entities.EntityFramework;
using System.Collections.Generic;

namespace QuickOrder.Bll.Concrete
{
    //banner interface classı implemente edilir yani içleri doldurulmak üzere çağrılır
    public class BannerBll : IBannerBll
    {
        //_bannerDal classı çağrılmakta. _bannerDal classı veritabanından verilerin çekildiği classtır. Bu class çağrılarak üzerinde istenilen iş kuralları uygulanarak
        //gönderilir. Örneğin a verisi geldi, bu veriyi b'ye dönüştürüp gönderebiliriz. Bunun adına iş kuralı denir.
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
            //id numarasına göre bir tek banner getirme işlemi yapar
            return _bannerDal.getOne(x => x.id == id);
        }

        public bool update(banners banners)
        {
            //Gönderilen değişikler mevcut banner'ı güncellemeye yarar
            return _bannerDal.update(banners);
        }
    }
}
