using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
        public IQueryable<Category> Categories => _context.Categories;

        public void CreateProduct(Product entity)
        {
            _context.Products.Add(entity);
            _context.SaveChanges();
        }

        public int GetProductCount(string category)
        {
           return category == null ? Products.Count():
                Products.Include(p => p.Categories)
                        .Where(p => p.Categories.Any(c => c.Url == category))
                        .Count();
        }

        public IEnumerable<Product> GetProductsByCategory(string category, int page, int pageSize)
        {
           var products = Products;

            if (!string.IsNullOrEmpty(category))
            {
                products = products.Include(p => p.Categories)
                             .Where(p => p.Categories.Any(c => c.Url == category));
            }

              return products.Skip((page - 1) * pageSize).Take(pageSize);


              
        }
    }
}