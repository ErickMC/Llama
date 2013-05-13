using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothingStoreWeb.Models
{
    public class SaleDetailModel
    {
        public int SaleDetailId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public virtual ItemModel Album { get; set; }
        public virtual SaleModel Sale { get; set; }
    }
}