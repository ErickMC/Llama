using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Udem.LlamaClothingCo.Business;
using Udem.LlamaClothingCo.Entities;

namespace LlamaClothingCo.Test
{
    [TestClass]
    public class SaleLogicTest
    {
        private static Sale testSale = new Sale();
        private static ICollection<SaleDetail> testDetails = new List<SaleDetail>();
        private static SaleDetail detail = new SaleDetail();
        private static SaleDetail detail2 = new SaleDetail();

        public static void CreateTestSale()
        {
            testSale.ClientId = 1;
            testSale.ShippingAddressId = 1;
            testSale.Date = DateTime.Now;

            
            detail.ItemId = 2;
            detail.Quantity = 2;
            detail.SaleId = testSale.SaleId;
            detail2.ItemId = 3;
            detail2.Quantity = 1;
            detail2.SaleId = testSale.SaleId;
            
            testDetails.Add(detail);
            testDetails.Add(detail2);


            SaleLogic logic = new SaleLogic();
            decimal total = logic.CalculateSaleTotal(testSale, testDetails);
            testSale.SaleTotal = total;
        }

        [TestMethod]
        public void Insert_Sale_To_Database()
        {
            CreateTestSale();
            SaleLogic logic = new SaleLogic();
            logic.AddSale(testSale, testDetails);
        }

        [TestMethod]
        public void Delete_Sale_From_Database()
        {
            CreateTestSale();
            SaleLogic logic = new SaleLogic();
            logic.AddSale(testSale,testDetails);
            logic.DeleteSale(testSale);
        }

        [TestMethod]
        public void Delete_Detail_From_Sale()
        {
            ItemLogic itemlogic = new ItemLogic();
            Item item = itemlogic.GetItemByID(1);

            SaleLogic logic = new SaleLogic();
            decimal total = logic.CalculateSaleTotal(testSale, testDetails);
            logic.AddSale(testSale, testDetails);
            logic.DeleteDetailFromSale(testSale, item, detail);
        }

        [TestMethod]
        public void Update_Sale_From_Database()
        {
            CreateTestSale();

            ItemLogic itemlogic = new ItemLogic();
            Item item = itemlogic.GetItemByID(1);

            SaleLogic logic = new SaleLogic();
            decimal total = logic.CalculateSaleTotal(testSale, testDetails);
            detail.Quantity = 3;
            logic.UpdateSale(testSale, item, detail);
        }

        [TestMethod]
        public void Get_Sales_Of_A_Client()
        {
            CreateTestSale();
            ClientLogic clientLogic = new ClientLogic();
            Client testClient = clientLogic.GetClientByID(1);
            SaleLogic logic = new SaleLogic();
            logic.GetSalesOfAClient(testClient);
        }

        [TestMethod]
        public void Get_Total_Sales_By_Year()
        {
            CreateTestSale();
            SaleLogic logic = new SaleLogic();
            logic.GetTotalSalesByYear(2013);
        }

        [TestMethod]
        public void Get_Total_Sales_By_Month()
        {
            CreateTestSale();
            SaleLogic logic = new SaleLogic();
            logic.GetTotalSalesByMonth(04,2013);
        }

        [TestMethod]
        public void Validate_Sale_Total()
        {
            CreateTestSale();
            SaleLogic logic = new SaleLogic();
            logic.ValidateSaleTotal(testSale,testDetails);
        }

        [TestMethod]
        public void Calculate_Sale_Total()
        {
            CreateTestSale();
            ItemLogic itemLogic = new ItemLogic();
            Item item1 = itemLogic.GetItemByID(2);
            Item item2 = itemLogic.GetItemByID(3);

            decimal trueTotal = detail.Quantity * item1.Cost + detail2.Quantity * item2.Cost;

            SaleLogic logic = new SaleLogic();
            decimal calculatedTotal = logic.CalculateSaleTotal(testSale, testDetails);
            Assert.AreEqual(trueTotal, calculatedTotal, "Not equal");
        }

    }
}
