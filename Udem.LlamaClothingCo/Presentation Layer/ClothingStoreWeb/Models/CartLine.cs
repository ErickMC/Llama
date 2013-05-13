using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Udem.LlamaClothingCo.Entities;

namespace ClothingStoreWeb.Models
{
    public class CartLine
    {
        public Item Product { get; set; }

        public int Quantity { get; set; }
    }
}