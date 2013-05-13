using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using Udem.LlamaClothingCo.Entities;

namespace ClothingStoreWeb.Interfaces
{
        public interface IProductRepository
        {
            IQueryable<Item> Products { get; }

            void SaveProduct(Item product);

            void DeleteProduct(Item product);
        }
}