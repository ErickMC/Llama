using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Udem.LlamaClothingCo.Entities;

namespace Udem.LlamaClothingCo.Managers
{
    public class AddressTypeManager : IManager<AddressType>
    {
        TestContext context;
        public AddressTypeManager(TestContext context)
        {
            this.context = context;
        }

        public AddressType GetByID(int id)
        {
            
            return context.AddressTypes.Single(ct => ct.AddressTypeId == id);
        }

        public IQueryable<AddressType> FindBy(Expression<Func<AddressType, bool>> criteria)
        {
            
            return  getActiveAddressTypes().Where(criteria);
        }
        public void AddRecord(AddressType addressType)
        {
            
            context.AddressTypes.AddObject(addressType);
            context.SaveChanges();
        }

        public void UpdateRecord(AddressType addressType)
        {
            context.AddressTypes.Detach(addressType);
            context.AddressTypes.Attach(context.AddressTypes.Single(at => at.AddressTypeId == addressType.AddressTypeId));
            context.AddressTypes.ApplyCurrentValues(addressType);
            context.SaveChanges();
        }

        public void DeleteRecord(AddressType addressType)
        {
            
            addressType.IsAddressTypeActive = false;
            UpdateRecord(addressType);
        }

        public IQueryable<AddressType> getActiveAddressTypes()
        {
            
            return context.AddressTypes.Where(at => at.IsAddressTypeActive );
        }
        /*
        public AddressType getAddressTypeByName(String name)
        {
            
            return context.AddressTypes.Single(ct => ct.TypeName.Equals(name));
        }
         */

    }
}
