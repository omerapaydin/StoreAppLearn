using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreAppLearn.Entity;

namespace StoreAppLearn.Data.Abstract
{
    public interface IStoreRepository
    {
         IQueryable<Product> Products { get; }
            IQueryable<Category> Categories { get; }
        void CreateProduct(Product entity);
    }
}