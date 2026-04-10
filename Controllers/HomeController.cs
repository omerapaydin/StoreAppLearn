using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreAppLearn.Data.Abstract;
using StoreAppLearn.Models;

namespace StoreAppLearn.Controllers
{
    public class HomeController:Controller
    {
        private readonly IStoreRepository _storerepository;
        public HomeController(IStoreRepository storerepository)
        {
            _storerepository = storerepository;
        }
        public IActionResult Index()
        {
            var products = _storerepository.Products.Select(p => new ProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Category = p.Category
            }).ToList();
            return View(products);
        }
    }
}