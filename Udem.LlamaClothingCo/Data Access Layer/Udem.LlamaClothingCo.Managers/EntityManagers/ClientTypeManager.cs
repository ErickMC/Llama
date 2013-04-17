using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Udem.LlamaClothingCo.Entities;

namespace Udem.LlamaClothingCo.Managers
{
    public class ClientTypeManager : IManager<ClientType>
    {
        TestContext context;
        public ClientTypeManager()     
        {
            context = new TestContext();
        }

        public ClientType GetByID(int id)
        {
            
            return context.ClientTypes.Single(ct => ct.ClientTypeId == id);
        }

        public IQueryable<ClientType> FindBy(Expression<Func<ClientType, bool>> criteria)
        {
            
            return GetActiveClientTypes().Where(criteria);
        }

        public void AddRecord(ClientType clientType)
        {
            
            context.ClientTypes.AddObject(clientType);
            context.SaveChanges();
        }

        public void UpdateRecord(ClientType clientType)
        {
            context.ClientTypes.Detach(clientType);
            context.ClientTypes.Attach(context.ClientTypes.Single(at => at.ClientTypeId == clientType.ClientTypeId));
            context.ClientTypes.ApplyCurrentValues(clientType);
            context.SaveChanges();
        }

        public void DeleteRecord(ClientType clientType)
        {
            
            clientType.IsClientTypeActive = false;
            UpdateRecord(clientType);
        }

        public IQueryable<ClientType> GetActiveClientTypes()
        {
            
            return context.ClientTypes.Where(ct => ct.IsClientTypeActive);

        }
       
        /*
        public ClientType getClientTypeByName(String name)
        {
            
            return context.ClientTypes.Single(ct => ct.TypeName.Equals(name));
        }
        */
    }
}
