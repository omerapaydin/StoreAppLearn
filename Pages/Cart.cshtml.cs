using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using StoreAppLearn.Data.Abstract;
using StoreAppLearn.Helpers;
using StoreAppLearn.Models;

namespace StoreAppLearn.Pages
{
    public class CartModel : PageModel
    {
        private IStoreRepository _storeRepository;

        public CartModel(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
            
        }
        public Cart? Cart { get; set; }

        public void OnGet()
        {
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(int productId)
        {
            var product = _storeRepository.Products.FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
                Cart.AddItem(product, 1);
                HttpContext.Session.SetJson("cart", Cart);
            }
           
            return RedirectToPage("/Cart");
        }
        public IActionResult OnPostRemove(int id)
        {
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            var product = Cart.Items.FirstOrDefault(p => p.Product.Id == id)?.Product;
            Cart?.RemoveItem(product);
            HttpContext.Session.SetJson("cart", Cart);
            return RedirectToPage("/Cart");
        }
    }
}