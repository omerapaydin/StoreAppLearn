using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreAppLearn.Data.Abstract;
using StoreAppLearn.Entity;

namespace StoreAppLearn.Data.Concrete
{
    public class EfStoreRepository : IStoreRepository
    {
        private readonly StoreDbContext _context;
        public EfStoreRepository(StoreDbContext context)
        {
            _context = context;
        }
        public IQueryable<Product> Products => _context.Products;

        public void CreateProduct(Product entity)
        {
            _context.Products.Add(entity);
            _context.SaveChanges();
        }
    }
}