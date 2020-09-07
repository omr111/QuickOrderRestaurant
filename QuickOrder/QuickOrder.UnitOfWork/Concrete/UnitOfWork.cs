using QuickOrder.Bll.Abstract;
using QuickOrder.Bll.Concrete;
using QuickOrder.Dal.Concrete;
using QuickOrder.Entities.Entities.EntityFramework;
using QuickOrder.UnitOfWork.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickOrder.UnitOfWork.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        
        public UnitOfWork()
        {
            
            productBll = new ProductBll(new ProductDal());
            bannerBll = new BannerBll(new BannerDal());
            billBll = new BillBll(new BillDal());
            categoryBll = new CategoryBll(new CategoryDal());
            companyInformationBll = new CompanyInformationBll(new CompanyInformationDal());
            phoneBll = new PhoneBll(new PhoneDal());
            reviewBll = new reviewBll(new reviewDal());
            rezervationBll = new rezervationBll(new rezervationDal());
            roleBll = new roleBll(new roleDal());
            roleOfUserBll = new roleOfUserBll(new roleOfUserDal());
            saleProductBll = new SaleProductBll(new SaleProductDal());
            saleProductsDetailBll = new SaleProductsDetailBll (new SaleProductsDetailDal());
            serviceBll = new serviceBll(new serviceDal());
            userBll = new userBll(new userDal());
        }
        public IProductBll productBll { get; set; }
        public IBannerBll bannerBll { get; set; }
        public IBillBll billBll { get; set; }
        public ICategoryBll categoryBll { get; set; }
        public ICompanyInformationBll companyInformationBll { get; set; }
        public IPhoneBll phoneBll { get; set; }
        public IreviewBll reviewBll { get; set; }
        public IrezervationBll rezervationBll { get; set; }
        public IroleBll roleBll { get; set; }
        public IroleOfUserBll roleOfUserBll { get; set; }
        public ISaleProductBll saleProductBll { get; set; }
        public ISaleProductsDetailBll saleProductsDetailBll { get; set; }
        public IserviceBll serviceBll { get; set; }
        public IuserBll userBll { get; set; }

      

    }
}
