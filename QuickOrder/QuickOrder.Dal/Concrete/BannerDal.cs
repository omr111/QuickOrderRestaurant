using QuickOrder.Dal.Abstract;
using QuickOrder.Entities.Entities.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickOrder.Dal.Concrete
{
    public class BannerDal:RepositoryBase<banners>,IBannerDal
    {
    }
}
