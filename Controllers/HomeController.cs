using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace StoreAppLearn.Controllers
{
    public class HomeController:Controller
    {
        private readonly IStoreRepository _storerepository;
        public HomeController(IStoreRepository storerepository)
        {
            _storerepository = storerepository;
        }
        public IActionResult Index() => View();
    }
}