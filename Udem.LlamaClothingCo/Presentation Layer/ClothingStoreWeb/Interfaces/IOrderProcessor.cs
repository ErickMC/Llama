using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using Udem.LlamaClothingCo.Entities;
using ClothingStoreWeb.Models;

namespace ClothingStoreWeb.Interfaces
{
    public interface IOrderProcessor
    {
        void ProcessOrder(Cart cart, Address shippingDetails);
    }
}