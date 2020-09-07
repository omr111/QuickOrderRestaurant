using QuickOrder.Bll.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickOrder.UnitOfWork.Abstract
{
   public interface IUnitOfWork
    {
         IProductBll productBll { get; set; }
         IBannerBll bannerBll { get; set; }
         IBillBll billBll { get; set; }
         ICategoryBll categoryBll { get; set; }
        ICompanyInformationBll companyInformationBll { get; set; }
         IPhoneBll phoneBll { get; set; }
         IreviewBll reviewBll { get; set; }
         IrezervationBll rezervationBll { get; set; }
         IroleBll roleBll { get; set; }
         IroleOfUserBll roleOfUserBll { get; set; }
         ISaleProductBll saleProductBll { get; set; }
         ISaleProductsDetailBll saleProductsDetailBll { get; set; }
         IserviceBll serviceBll { get; set; }
         IuserBll userBll { get; set; }
 
        

    }
}
