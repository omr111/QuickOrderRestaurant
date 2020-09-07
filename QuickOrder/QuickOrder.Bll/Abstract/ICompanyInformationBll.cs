using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickOrder.Entities.Entities.EntityFramework;

namespace QuickOrder.Bll.Abstract
{
    public interface ICompanyInformationBll
    {
        List<CompanyInformations> getAll();
        CompanyInformations getOne(int id);
        bool add(CompanyInformations CompanyInformations);
        bool update(CompanyInformations CompanyInformations);
        bool deleteById(int id);
    }
}
