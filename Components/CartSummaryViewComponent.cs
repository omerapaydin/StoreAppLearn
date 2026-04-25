using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreAppLearn.Helpers;
using StoreAppLearn.Models;

namespace StoreAppLearn.Components
{
    public class CartSummaryViewComponent:ViewComponent
    {
       
        public IViewComponentResult Invoke()
        {
             var cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();

            return View(cart);
        }
    }
}