using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;
using Udem.LlamaClothingCo.Entities;

namespace ClothingStoreWeb.Models
{
    public class ItemModel
    {
        public int ItemID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public bool IsItemActive { get; set; }
        public virtual ItemTypeModel Catego { get; set; }
        public virtual List<SaleDetail> OrderDetails { get; set; }
    }
    public class LocalProductModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Street")]
        public string Street { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Number")]
        public string Number { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "State")]
        public string State { get; set; }

        [Required]
        [DataType(DataType.PostalCode)]
        [Display(Name = "ZipCode")]
        public string ZipCode { get; set; }

    }
}