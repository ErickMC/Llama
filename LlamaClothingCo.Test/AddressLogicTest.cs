using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Udem.LlamaClothingCo.Business;
using Udem.LlamaClothingCo.Entities;

namespace LlamaClothingCo.Test
{
    [TestClass]
    public class AddressLogicTest
    {
        private static Address testAddress = new Address();

        public static void CreateTestAddress()
        {
            testAddress.Street = "Baker Street";
            testAddress.Number = 221;
            testAddress.City = "Monterrey";
            testAddress.State = "Nuevo León";
            testAddress.ZipCode = 64040;
            testAddress.AddressTypeId = 1;
        }

        [TestMethod]
        public void Insert_Address_To_Database()
        {
            CreateTestAddress();
            AddressLogic logic = new AddressLogic();
            logic.AddAddress(testAddress);
        }

        [TestMethod]
        public void Update_Address_From_Database()
        {
            CreateTestAddress();
            AddressLogic logic = new AddressLogic();
            Address testAddress2 = logic.GetAddressByID(1);
            testAddress2.City = "changed by Update";
            logic.UpdateAddress(testAddress2);
        }

        [TestMethod]
        public void Delete_Address_From_Database()
        {
            CreateTestAddress();
            AddressLogic logic = new AddressLogic();
            logic.AddAddress(testAddress);
            logic.DeleteAddress(testAddress);
        }

        [TestMethod]
        public void Get_Address_From_Database_By_ID()
        {
            CreateTestAddress();
            AddressLogic logic = new AddressLogic();
            logic.GetAddressByID(1);
        }

        [TestMethod]
        public void Get_Active_Addresses()
        {
            CreateTestAddress();
            AddressLogic logic = new AddressLogic();
            logic.GetActiveAddresses();
        }

        [TestMethod]
        public void Get_Addresses_From_Database_By_City()
        {
            CreateTestAddress();
            AddressLogic logic = new AddressLogic();
            logic.GetAddressesByCity("Monterrey");
        }

        [TestMethod]
        public void Get_Addresses_From_Database_By_State()
        {
            CreateTestAddress();
            AddressLogic logic = new AddressLogic();
            logic.GetAddressesByState("Nuevo León");
        }

        [TestMethod]
        public void Get_Addresses_From_Database_By_ZipCode()
        {
            CreateTestAddress();
            AddressLogic logic = new AddressLogic();
            logic.GetAddressesByZipCode(64040);
        }

        [TestMethod]
        public void Get_Addresses_From_Database_By_Type()
        {
            CreateTestAddress();
            AddressLogic logic = new AddressLogic();
            logic.GetAddressesByType(1);
        }

    }
}
