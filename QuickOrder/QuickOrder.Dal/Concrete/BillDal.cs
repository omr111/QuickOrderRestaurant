using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickOrder.Dal.Abstract;
using QuickOrder.Entities.Entities.EntityFramework;
namespace QuickOrder.Dal.Concrete
{
    public class BillDal : RepositoryBase<Bills>, IBillDal
    {
    }
}
