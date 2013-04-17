//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Udem.LlamaClothingCo.Presentation.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Item
    {
        public Item()
        {
            this.SaleDetail = new HashSet<SaleDetail>();
            this.Cart = new HashSet<Cart>();
        }
    
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<double> Cost { get; set; }
        public Nullable<bool> IsItemActive { get; set; }
        public int ItemID { get; set; }
        public int ItemTypeID { get; set; }
    
        public virtual ICollection<SaleDetail> SaleDetail { get; set; }
        public virtual ICollection<Cart> Cart { get; set; }
        public virtual ItemType ItemType { get; set; }
    }
}