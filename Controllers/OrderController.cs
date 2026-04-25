using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreAppLearn.Data.Abstract;
using StoreAppLearn.Entity;
using StoreAppLearn.Helpers;
using StoreAppLearn.Models;

namespace StoreAppLearn.Controllers
{
    public class OrderController:Controller
    {
       
        private readonly IOrderRepository _orderRepository;
        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public IActionResult Checkout()
        {            
            var cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            return View(new OrderModel() { Cart = cart });
        }
        [HttpPost]
        public IActionResult Checkout(OrderModel model)
        {            
            var cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            if(cart.Items.Count == 0)
            {
                ModelState.AddModelError("","Sepetniz boş");
            }

            if(ModelState.IsValid)
            {
                var order = new Order
                {
                    Name = model.Name,
                    Email = model.Email,
                    City = model.City,
                    Phone = model.Phone,
                    AddressLine = model.AddressLine,
                    OrderDate = DateTime.Now,
                    OrderItems = cart.Items.Select(i => new OrderItem
                    {
                        ProductId = i.Product.Id,
                        Price = (double)i.Product.Price,
                        Quantity = i.Quantity
                    }).ToList()
                };
                _orderRepository.SaveOrder(order);
                cart.Clear();
                HttpContext.Session.SetJson("cart", cart);
                return RedirectToPage("/Completed",new { orderId = order.Id });
            }

            else
            {
                model.Cart = cart;
                return View(model);
            }


        }
    }
}