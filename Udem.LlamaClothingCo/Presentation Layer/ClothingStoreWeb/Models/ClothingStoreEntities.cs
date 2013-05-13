using System.Data.Entity;
using Udem.LlamaClothingCo.Entities;

namespace ClothingStoreWeb.Models
{
    public class ClothingStoreEntities : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Sale> Sale { get; set; }
        public DbSet<SaleDetail> SaleDetails { get; set; }
    }
}