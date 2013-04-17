using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Udem.LlamaClothingCo.Entities;


namespace Udem.LlamaClothingCo.Managers
{
    public class ClientManager : IManager<Client>
    {
        TestContext context;
        public ClientManager()
        {
            context = new TestContext();
        }
        
        public Client GetByID(int id)
        {
           
            Client client = context.Clients.Single(c => id == c.ClientId);
            return client;
        }

        public IQueryable<Client> FindBy(Expression<Func<Client, bool>> criteria)
        {
           
            return GetActiveClients().Where(criteria);
            
        }

        public void AddRecord(Client client)
        {
           
            context.Clients.AddObject(client);
            context.SaveChanges();
        }

       
        public void UpdateRecord(Client client)
        {
            if (client.EntityState == System.Data.EntityState.Detached)
            {
                context.Clients.Attach(context.Clients.Single(c => c.ClientId == client.ClientId));
            }
            context.Clients.ApplyCurrentValues(client);
            context.SaveChanges();
        }

        public void DeleteRecord(Client client)
        {
            client.IsClientActive = false;
            UpdateRecord(client);
        }

        public IQueryable<Client> GetActiveClients()
        {
           
            return context.Clients.Where(c => c.IsClientActive);
            
        }

        /*
         *   public List<Client> getClientByLastName(String lastName)
        {
           
            return context.Clients.Where(c => c.LastName.Equals(lastName)).ToList();
        }

        public List<Client> getClientsByType(int typeId)
        {
           
            return context.Clients.Where(c => c.ClientTypeId == typeId).ToList();
        }

        public List<Client> getClientsByType(ClientType type)
        {
           
            return context.Clients.Where(c => c.ClientType.ClientTypeId == type.ClientTypeId).ToList();
        }
         */

    }
}
