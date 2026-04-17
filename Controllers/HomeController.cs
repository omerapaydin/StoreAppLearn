using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult Index(string category, int page = 1)
        {
              
            return View(new ProductListViewModel { 
                Products = _storerepository.GetProductsByCategory(category, page, pageSize).Take(pageSize)
            .Select(p => 
            new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    Category = p.Categories.FirstOrDefault()!.Name
                }).ToList(),
                PagingInfo = new PagingInfo
                {
                    TotalItems = _storerepository.GetProductCount(category),
                    ItemsPerPage = pageSize,
                }
                 });
        }
    }
}