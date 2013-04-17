using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Udem.LlamaClothingCo.Business;
using Udem.LlamaClothingCo.Entities;

namespace LlamaClothingCo.Test
{
    [TestClass]
    public class ClientLogicTest
    {
       
        [TestMethod]
        public void TestMethod1()
        {
            Client client = new Client();
            client.FirstName = "Erick";
            client.LastName = "Marroquin";
            client.RFC = "AAAAAA";
            client.BillingAddressId = 1;
            client.ClientTypeId = 1;
            client.IsClientActive = true;
            client.TelephoneNumber = "555555";
            client.Email = "a@a.com";
            client.Password = "aaa";
            client.ShippingAddressId = 1;

            ClientLogic logic = new ClientLogic();
            logic.AddClient(client);
            
            
        }
    }
}
