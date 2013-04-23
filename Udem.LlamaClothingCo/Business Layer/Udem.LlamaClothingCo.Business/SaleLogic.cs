using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Udem.LlamaClothingCo.Managers;
using Udem.LlamaClothingCo.Entities;


namespace Udem.LlamaClothingCo.Business
{
    public class SaleLogic
    {
        private SaleManager _saleManager;

        public SaleManager Sale_Manager
        {
            get
            {
                return _saleManager ?? new SaleManager();
            }
            set
            {
                _saleManager = value;
            }
        }
        //Using a ItemManager as the Sales are very interconnected to Items.
        private ItemManager _itemManager;

        public ItemManager Item_Manager
        {
            get
            {
                return _itemManager ?? new ItemManager();
            }
            set
            {
                _itemManager = value;
            }
        }

        public SaleLogic()
        {
            Sale_Manager = new SaleManager();
            Item_Manager = new ItemManager();   
        }
        #region CRUD

        public void AddSale(Sale sale, ICollection<SaleDetail> details)
        {
            bool correctTotal = ValidateSaleTotal(sale, details);
            if (!correctTotal)
            {
                sale.SaleTotal = CalculateSaleTotal(sale, details);
            }
            Sale_Manager.AddRecord(sale, details);
        }

        public void DeleteSale(Sale sale)
        {
            Sale_Manager.DeleteRecord(sale);
        }

        public void DeleteDetailFromSale(Sale sale, Item item, SaleDetail detail)
        {
            sale.SaleTotal -= item.Cost * detail.Quantity;
            Sale_Manager.UpdateRecord(sale, item, detail); //Updates the total in the database
            Sale_Manager.DeleteRecord(sale, item, detail);
        }

        public void UpdateSale(Sale sale, Item item, SaleDetail detail)
        {
            Sale_Manager.UpdateRecord(sale, item, detail);
        }
       

        public ICollection<Sale> GetSalesOfAClient(Client client)
        {
            return Sale_Manager.FindBy(s => s.Client.ClientId == client.ClientId).ToList();
        }

        /*TENTATIVO, PUEDE NO SERVIR ESTE METODO
        public ICollection<Sale> GetSalesByShippingAddress(ShippingAddress address)
        {
            return Sale_Manager.FindBy(s => s.ShippingAddress.Equals(address)).ToList();
        } 
         */
        #endregion
        #region Reports
        public IDictionary<int, decimal> GetTotalSalesByYear(int year)
        {
            IDictionary<int, decimal> totalSales = new Dictionary<int, decimal>();
            var salesByYear = Sale_Manager.FindBy(s => s.Date.Year == year).GroupBy(s => s.Date.Year);
            foreach (var sale in salesByYear)
            {
                totalSales.Add(sale.Key, sale.AsQueryable().Sum(s => s.SaleTotal)); 
            }
            return totalSales;
        }

        public IDictionary<int, decimal> GetTotalSalesByMonth(int month, int year)
        {
            IDictionary<int, decimal> totalSales = new Dictionary<int, decimal>();
            var salesByYear = Sale_Manager.FindBy(s => s.Date.Year == year && s.Date.Month == month)
                                .GroupBy(s => s.Date.Month);
            foreach (var sale in salesByYear)
            {
                totalSales.Add(sale.Key, sale.AsQueryable().Sum(s => s.SaleTotal));
            }
            return totalSales;
        }
        #endregion

        public bool ValidateSaleTotal(Sale sale, ICollection<SaleDetail> details)
        {
            var totalSale = CalculateSaleTotal(sale, details);            
            return sale.SaleTotal == totalSale;
        }

        public decimal CalculateSaleTotal(Sale sale, ICollection<SaleDetail> details)
        {
            decimal sum = 0;
            decimal cost;
            foreach (var item in details)
            {
                cost = Item_Manager.GetByID(item.ItemId).Cost;
                sum += item.Quantity * cost;
                cost = 0;
            }

            return sum;
        }
    }
}
