using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreAppLearn.Data.Abstract;
using StoreAppLearn.Entity;
using StoreAppLearn.Models;

namespace StoreAppLearn.Controllers
{
    public class HomeController:Controller
    {
        public int pageSize = 3;
        private readonly IStoreRepository _storerepository;
        public HomeController(IStoreRepository storerepository)
        {
            _storerepository = storerepository;
        }
        public IActionResult Index(int page = 1)
        {
            var products = 
            _storerepository
            .Products
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(p => 
            new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    Category = p.Category
                }).ToList();
            return View(new ProductListViewModel { 
                Products = products,
                PagingInfo = new PagingInfo
                {
                    TotalItems = _storerepository.Products.Count(),
                    ItemsPerPage = pageSize
                }
                 });
        }
    }
}