using QuickOrder.Entities.Entities.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickOrder.Bll.Abstract
{
    //interface oluşturulacak olan metodların özeti anlamındadır. Bu metodlar burada oluşturulur
    //daha sonra  çağrıldığı yerde içleri doldurulur
    public interface IBannerBll
    {
        List<banners> getAll();
        banners getOne(int id);
        bool add(banners banner);
        bool update(banners banners);
        bool deleteById(int id);


    }
}
