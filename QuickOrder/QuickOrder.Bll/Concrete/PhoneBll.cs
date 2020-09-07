using System;
using System.Collections.Generic;
using QuickOrder.Dal.Abstract;
using QuickOrder.Bll.Abstract;
using QuickOrder.Entities.Entities.EntityFramework;
namespace QuickOrder.Bll.Concrete
{
    public class PhoneBll : IPhoneBll
    {
        private IPhoneDal _phoneDal;
        public PhoneBll(IPhoneDal phoneDal)
        {
            _phoneDal = phoneDal;
        }
        public bool add(Phones Phones)
        {
            return _phoneDal.add(Phones);
        }

        public bool deleteById(int id)
        {
            return _phoneDal.delete(getOne(id));
        }

        public List<Phones> getAll()
        {
            return _phoneDal.getAll();
        }

        public Phones getOne(int id)
        {
            return _phoneDal.getOne(x => x.id == id);
        }

        public Phones getOneByNumberAndCompanyId(string phone, int companyId)
        {
            return _phoneDal.getOne(x => x.phoneNumber == phone&&x.CompanyID==companyId);
        }

        public bool update(Phones Phones)
        {
            return _phoneDal.update(Phones);
        }
    }
}
