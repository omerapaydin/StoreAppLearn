using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreAppLearn.Entity;

namespace StoreAppLearn.Models
{
    public class Cart
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();
        
        public void AddItem(Product product, int quantity)
        {
            var item = Items.FirstOrDefault(i=>i.Product.Id == product.Id);
            if(item != null)
            {
                item.Quantity += quantity;
            }
            else
            {
                Items.Add(new CartItem { Product = product, Quantity = quantity });
            }
        }
        public void RemoveItem(Product product)
        {
            Items.RemoveAll(i => i.Product.Id == product.Id);
        }

        public decimal CalculateTotal()
        {
            return Items.Sum(i => i.Product.Price * i.Quantity);
        }

        public void Clear()
        {
            Items.Clear();

        }

    }


    public class CartItem
    {
        public int CartItemId { get; set; }
        public Product Product { get; set; } = new();
        public int Quantity { get; set; }
    }

}