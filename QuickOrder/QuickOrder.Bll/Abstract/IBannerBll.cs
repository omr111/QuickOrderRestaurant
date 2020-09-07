using QuickOrder.Entities.Entities.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickOrder.Bll.Abstract
{
    public interface IBannerBll
    {
        List<banners> getAll();
        banners getOne(int id);
        bool add(banners banner);
        bool update(banners banners);
        bool deleteById(int id);


    }
}
