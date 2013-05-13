using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udem.LlamaClothingCo.Managers;
using Udem.LlamaClothingCo.Entities;


namespace Udem.LlamaClothingCo.Business
{
    public class ClientLogic
    {
        private ClientManager _clientManager;

        public ClientManager Client_Manager
        {
            get
            {
                return _clientManager ;
            }
            set
            {
                _clientManager = value;
            }
        }

        public ClientLogic(TestContext context)
        {
            Client_Manager = new ClientManager(context);
        }

        #region CRUD
        public void AddClient(Client client)
        {
            Client_Manager.AddRecord(client);
        }

        public void DeleteClient(Client client)
        {
            Client_Manager.DeleteRecord(client);
        }

        public void UpdateClient(Client client)
        {
            Client_Manager.UpdateRecord(client);
        }


        public Client GetClientByID(int id)
        {
            return Client_Manager.GetByID(id);
        }

        public Client GetClientByEmail(string email)
        {
            return Client_Manager.FindBy(s => s.Email==email).ToList().First();
        }

        public ICollection<Client> GetAllActiveClients()
        {
            return Client_Manager.GetActiveClients().ToList();
        }

        public ICollection<Client> GetClientsByType(ClientType type)
        {
            return Client_Manager.FindBy(s => s.ClientType.Equals(type)).ToList();
        }

        public ICollection<Client> GetClientsByType(int type)
        {
            return Client_Manager.FindBy(s => s.ClientType.ClientTypeId.Equals(type)).ToList();
        }

        public ICollection<Client> GetClientsByName(string name)
        {
            return Client_Manager.FindBy(s => s.FirstName == name).ToList();
        }

        public ICollection<Client> GetClientsByLastName(string lastName)
        {
            return Client_Manager.FindBy(s => s.LastName == lastName).ToList();
        }

        public bool AuthenticateUser(string email, string password)
        {
            Client toAuth = GetClientByEmail(email);
            return toAuth.Password == password;
                
        }
        
        #endregion


    }
}
