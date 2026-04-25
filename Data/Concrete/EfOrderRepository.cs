using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreAppLearn.Data.Abstract;
using StoreAppLearn.Entity;

namespace StoreAppLearn.Data.Concrete
{
    public class EfOrderRepository : IOrderRepository
    {
        private readonly StoreDbContext _context;
        public EfOrderRepository(StoreDbContext context)
        {
            _context = context;
        }
        public IQueryable<Order> Orders => _context.Orders;

        public void SaveOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }
    }
}