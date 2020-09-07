using System;
using System.Collections.Generic;
using QuickOrder.Dal.Abstract;
using QuickOrder.Bll.Abstract;
using QuickOrder.Entities.Entities.EntityFramework;
namespace QuickOrder.Bll.Concrete
{
    public class CompanyInformationBll : ICompanyInformationBll
    {
        private ICompanyInformationDal _companyInformationDal;
        public CompanyInformationBll(ICompanyInformationDal companyInformationDal)
        {
            _companyInformationDal = companyInformationDal;
        }
        public bool add(CompanyInformations CompanyInformations)
        {
            return _companyInformationDal.add(CompanyInformations);
        }

        public bool deleteById(int id)
        {
            return _companyInformationDal.delete(getOne(id));
        }

        public List<CompanyInformations> getAll()
        {
            return _companyInformationDal.getAll();
        }

        public CompanyInformations getOne(int id)
        {
            return _companyInformationDal.getOne(x => x.id == id);
        }

        public bool update(CompanyInformations CompanyInformations)
        {
            return _companyInformationDal.update(CompanyInformations);
        }
    }
}
