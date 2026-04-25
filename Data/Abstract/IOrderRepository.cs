using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreAppLearn.Entity;

namespace StoreAppLearn.Data.Abstract
{
    public interface IOrderRepository
    {
        IQueryable<Order> Orders { get; }
        void SaveOrder(Order order);
    }
}