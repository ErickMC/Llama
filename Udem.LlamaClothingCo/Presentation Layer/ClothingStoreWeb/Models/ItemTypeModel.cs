using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothingStoreWeb.Models
{
    public class ItemTypeModel
    {
        public int ItemTypeID { get; set; }
        public string TypeName { get; set; }
        public string Description { get; set; }
        public bool IsItemActive { get; set; }
        public List<ItemModel> Items { get; set; }
    }
}