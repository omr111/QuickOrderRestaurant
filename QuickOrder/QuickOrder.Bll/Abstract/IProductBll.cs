﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickOrder.Entities.Entities.EntityFramework;
namespace QuickOrder.Bll.Abstract
{
    public interface IProductBll
    {
        List<Products> getAll();
        Products getOne(int id);
        bool add(Products Products);
        bool update(Products Products);
        bool deleteById(int id);
        
    }
}
