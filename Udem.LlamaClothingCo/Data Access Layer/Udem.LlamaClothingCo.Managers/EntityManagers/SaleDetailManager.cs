using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udem.LlamaClothingCo.Entities;

namespace Udem.LlamaClothingCo.Managers
{
    public class SaleDetailManager 
    {
        public SaleDetailManager()
        {
        }

        public SaleDetail GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<SaleDetail> FindBy(System.Linq.Expressions.Expression<Func<SaleDetail, bool>> criteria)
        {
            throw new NotImplementedException();
        }

        public void UpdateRecord(SaleDetail record)
        {
            throw new NotImplementedException();
        }

        public void DeleteRecord(SaleDetail record)
        {
            throw new NotImplementedException();
        }

        public void AddRecord(SaleDetail saleDetail)
        {
            TestContext context = new TestContext();
            context.SaleDetails.AddObject(saleDetail);
            context.SaveChanges();
        }


        /*
        public List<SaleDetail> getSaleDetailsBySale(int saleId)
        {
            TestContext context = new TestContext();
            return context.SaleDetails.Where(sd => sd.SaleId == saleId).ToList();
        }

        public List<SaleDetail> getSaleDetailsBySale(Sale sale)
        {
            TestContext context = new TestContext();
            return context.SaleDetails.Where(sd => sd.Sale.SaleId == sale.SaleId).ToList();
        }

        public List<SaleDetail> getSaleDetailsByItem(int id)
        {
            TestContext context = new TestContext();
            return context.SaleDetails.Where(sd => sd.ItemId == id).ToList();
        }

        public List<SaleDetail> getSaleDetailsByItem(Item item)
        {
            TestContext context = new TestContext();
            return context.SaleDetails.Where(sd => sd.Item.ItemId == item.ItemId).ToList();
        }
         * 
         * */

        
    }
}
