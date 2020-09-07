using System;
using System.Collections.Generic;
using QuickOrder.Dal.Abstract;
using QuickOrder.Bll.Abstract;
using QuickOrder.Entities.Entities.EntityFramework;
namespace QuickOrder.Bll.Concrete
{
    public class CategoryBll : ICategoryBll
    {
        private ICategoryDal _categoryDal;
        public CategoryBll(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public bool add(Categories Categories)
        {
            return _categoryDal.add(Categories);
        }

        public bool deleteById(int id)
        {
            return _categoryDal.delete(getOne(id));
        }

        public List<Categories> getAll()
        {
            return _categoryDal.getAll();
        }

        public Categories getOne(int id)
        {
            return _categoryDal.getOne(x => x.id == id);
        }

        public Categories getOneByName(string name)
        {
            return _categoryDal.getOne(x => x.categoryName == name);
        }

        public bool update(Categories Categories)
        {
            return _categoryDal.update(Categories);
        }
    }
}
