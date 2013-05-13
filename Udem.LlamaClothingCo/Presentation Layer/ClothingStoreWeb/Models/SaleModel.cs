using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ClothingStoreWeb.Models
{
    public class SaleModel
    {
        [ScaffoldColumn(false)]
        public int SaleId { get; set; }

        [ScaffoldColumn(false)]
        public System.DateTime Date { get; set; }

        [ScaffoldColumn(false)]
        public int ClientId { get; set; }

        [ScaffoldColumn(false)]
        public int SaleTotal { get; set; }

        public virtual AddressModel ShippingAddress { get; set; }

    }
}