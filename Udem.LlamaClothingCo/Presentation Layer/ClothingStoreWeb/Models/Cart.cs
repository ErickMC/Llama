using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using Udem.LlamaClothingCo.Entities;

namespace ClothingStoreWeb.Models
{
    public class Cart
    {
        private readonly List<CartLine> _items = new List<CartLine>();

        public void AddItem(Item product, int quantity)
        {
            lock (this)
            {
                var storedItem = _items
                .Where(prod => prod.Product.ItemId == product.ItemId)
                .FirstOrDefault();

                if (storedItem == null)
                {
                    _items.Add(new CartLine() { Product = product, Quantity = quantity });
                }
                else
                {
                    storedItem.Quantity += quantity;
                }
            }
        }

        public void RemoveItem(Item product)
        {
            lock (this)
            {
                _items.RemoveAll(cartLine => cartLine.Product.ItemId == product.ItemId);
            }
        }

        public decimal ComputeTotalValue()
        {
            lock (this)
            {
                return _items.Sum(cartLine => cartLine.Product.Cost * cartLine.Quantity);
            }
        }

        public IEnumerable<CartLine> Lines
        {
            get
            {
                return _items;
            }
        }

        public void Clear()
        {
            lock (this)
            {
                _items.Clear();
            }
        }
    }
}