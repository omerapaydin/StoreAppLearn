using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreAppLearn.Helpers;
using StoreAppLearn.Models;

namespace StoreAppLearn.Controllers
{
    public class OrderController:Controller
    {
       
        public IActionResult Checkout()
        {            
                var cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            return View(new OrderModel() { Cart = cart });
        }
        
    }
}