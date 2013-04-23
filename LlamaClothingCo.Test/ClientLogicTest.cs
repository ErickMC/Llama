using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Udem.LlamaClothingCo.Business;
using Udem.LlamaClothingCo.Entities;

namespace LlamaClothingCo.Test
{
    [TestClass]
    public class ClientLogicTest
    {
       
        private static Client testClient = new Client();

        public static void CreateTestClient()
        {
           
            testClient.FirstName = "Erick";
            testClient.LastName = "Marroquin";
            testClient.RFC = "AAAAAA";
            testClient.BillingAddressId = 1;
            testClient.ClientTypeId = 1;
            testClient.IsClientActive = true;
            testClient.TelephoneNumber = "555555";
            testClient.Email = "a@a.com";
            testClient.Password = "aaa";
            testClient.ShippingAddressId = 1;
        }
        [TestMethod]
        public void Insert_Client_To_Database()
        {
            CreateTestClient();
            ClientLogic logic = new ClientLogic();
            logic.AddClient(testClient);
        }

        [TestMethod]
        public void Delete_Client_From_Database()
        {
            CreateTestClient();
            ClientLogic logic = new ClientLogic();
            Client testClient2 = logic.GetClientByEmail(testClient.Email);
            logic.DeleteClient(testClient2);
        }

        [TestMethod]
        public void Update_Client_From_Database()
        {
            CreateTestClient();
            ClientLogic logic = new ClientLogic();
            Client testClient2 = logic.GetClientByID(1);
            testClient2.RFC = "Changed by Update";
            logic.UpdateClient(testClient2);
        }
        [TestMethod]
        public void Get_Client_From_Database_By_Id()
        {
            CreateTestClient();
            ClientLogic logic = new ClientLogic();
            logic.GetClientByID(1);
        }
        [TestMethod]
        public void Get_Client_From_Database_By_Email()
        {
            CreateTestClient();
            ClientLogic logic = new ClientLogic();
            logic.GetClientByEmail("a@a.com");
        }

        [TestMethod]
        public void Get_All_Active_Clients()
        {
            CreateTestClient();
            ClientLogic logic = new ClientLogic();
            logic.GetAllActiveClients();
        }

        [TestMethod]
        public void Get_Clients_From_Database_By_Name()
        {
            CreateTestClient();            
            ClientLogic logic = new ClientLogic();
            logic.GetClientsByName("Erick");
        }

        [TestMethod]
        public void Get_Clients_From_Database_By_LastName()
        {
            CreateTestClient();
            ClientLogic logic = new ClientLogic();
            logic.GetClientsByLastName("Marroquin");
        }

        [TestMethod]
        public void Authenticate_Client()
        {
            CreateTestClient();
            ClientLogic logic = new ClientLogic();
            logic.AuthenticateUser(testClient.Email, testClient.Password);
        }

    }
}
