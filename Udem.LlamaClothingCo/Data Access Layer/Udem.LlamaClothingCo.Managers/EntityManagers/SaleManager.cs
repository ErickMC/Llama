using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Udem.LlamaClothingCo.Entities;

namespace Udem.LlamaClothingCo.Managers
{
    public class SaleManager 
    {
        TestContext context;
        public SaleManager(TestContext context)
        {
            this.context = context;
        }
        #region Experimentales

        public Sale GetByID(int id)
        {
            
            return context.Sales.Single(s => s.SaleId == id);
        }

        public IQueryable<Sale> FindBy(Expression<Func<Sale, bool>> criteria)
        {
            
            return context.Sales.Where(criteria);
        }

        public void AddRecord(Sale sale)
        {

            context.Sales.AddObject(sale);
            
            context.SaveChanges();
        }
        public void AddRecord(ICollection<SaleDetail> saleDetails)
        {

            
            foreach (var item in saleDetails)
            {
               
                context.SaleDetails.AddObject(item);
            }
            context.SaveChanges();
        }
        public void AddRecord(Sale sale, ICollection<SaleDetail> saleDetails)
        {
            
            context.Sales.AddObject(sale);
            foreach (var item in saleDetails)
            {
                item.SaleId = sale.SaleId;
                context.SaleDetails.AddObject(item);
            }
            context.SaveChanges();
        }

        public void UpdateRecord(Sale sale, Item item, SaleDetail saleDetail)
        {
           
            context.Sales.Detach(sale);
            context.SaleDetails.Detach(saleDetail);
            if (sale.EntityState == System.Data.EntityState.Detached)
            {
                context.Sales.Attach(context.Sales.Single(c => c.SaleId == sale.SaleId));
            }
            if (saleDetail.EntityState == System.Data.EntityState.Detached)
            {
              context.SaleDetails.Attach(context.SaleDetails.Single(sd => sd.SaleId == sale.SaleId && sd.ItemId == item.ItemId));
            }
            context.Sales.ApplyCurrentValues(sale);
            context.SaleDetails.ApplyCurrentValues(saleDetail);
            context.SaveChanges();
        
        }

       
        public void DeleteRecord(Sale sale)
        {
            context.Sales.Detach(sale);
            context.Sales.Attach(context.Sales.Single(c => c.SaleId == sale.SaleId));
            context.Sales.DeleteObject(sale);
            context.SaveChanges();
        }

        public void DeleteRecord(Sale sale, Item item, SaleDetail saleDetail)
        {
            context.Sales.Detach(sale);
            context.SaleDetails.Detach(saleDetail);
            context.Sales.Attach(context.Sales.Single(c => c.SaleId == sale.SaleId));
            context.SaleDetails.Attach(context.SaleDetails.Single(sd => sd.SaleId == sale.SaleId && sd.ItemId == item.ItemId));
            context.SaleDetails.DeleteObject(saleDetail);
            context.SaveChanges();
        }

        public IQueryable<SaleDetail> GetDetails(Sale sale)
        {
            return context.SaleDetails.Where(s => s.SaleId == sale.SaleId);
        }

        #endregion
        #region Originales
        /*
        public void AddRecord(Sale sale)
        {
            
            context.Sales.AddObject(sale);
            context.SaveChanges();            
        }

        public void UpdateRecord(Sale sale)
        {
            
            context.Sales.Attach(context.Sales.Single(c => c.SaleId == sale.SaleId));
            context.Sales.ApplyCurrentValues(sale);
            context.SaveChanges();
        }

        public void DeleteRecord(Client sale)
        {
            
            sale.IsClientActive = false;
            UpdateRecord(sale);
        }


        
        public Sale getSaleById(int id)
        {
            
            return context.Sales.Single(s => s.SaleId == id);
        }

        public List<Sale> getSalesByClient(int clientId)
        {
            
            return context.Sales.Where(s => s.ClientId == clientId).ToList();
        }
        public List<Sale> getSalesByClient(Client client)
        {
            
            return context.Sales.Where(s => s.Client.ClientId == client.ClientId).ToList();
        }

        public List<Sale> getSalesByYear(int year)
        {
            
            return context.Sales.Where(s => s.Date.Year == year).ToList();
        }

        public List<Sale> getSalesByMonth(int month, int year)
        {
            
            return context.Sales.Where(s => s.Date.Year == year && s.Date.Month == month).ToList();  //Group By???
        }
        */
        #endregion
    }
}
