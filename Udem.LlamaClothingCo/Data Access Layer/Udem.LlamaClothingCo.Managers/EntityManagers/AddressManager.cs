using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Udem.LlamaClothingCo.Entities;


namespace Udem.LlamaClothingCo.Managers
{
    public class AddressManager : IManager<Address>
    {
        TestContext context;
        public AddressManager()
        {
            context = new TestContext();
        }

        public Address GetByID(int id)
        {
            
            Address address = context.Addresses.Single(a => id == a.AddressId);
            return address;
        }

        public IQueryable<Address> FindBy(Expression<Func<Address, bool>> criteria)
        {
            
            return GetActiveAddresses().Where(criteria);

        }

        public void AddRecord(Address address)
        {
            
            context.Addresses.AddObject(address);
            context.SaveChanges();
        }

        public void UpdateRecord(Address address)
        {
            if (address.EntityState == System.Data.EntityState.Detached)
            {
                context.Addresses.Attach(context.Addresses.Single(a => a.AddressId == address.AddressId));
            }
            context.Addresses.ApplyCurrentValues(address);
            context.SaveChanges();
        }

        public void DeleteRecord(Address address)
        {
            
            address.IsAddressActive = false;
            UpdateRecord(address);
        }

        public IQueryable<Address> GetActiveAddresses()
        {
            return context.Addresses.Where(a => a.IsAddressActive);
        }

       
        /*
        public List<Address> getAddressesByCity(String city)
        {
            
            return context.Addresses.Where(a => city == a.City).ToList();
        }

        public List<Address> getAddressesByState(String state)
        {
            
            return context.Addresses.Where(a => state == a.State).ToList();
        }

        public List<Address> getAddressesByZipCode(int zipCode)
        {
            
            return context.Addresses.Where(a => zipCode == a.ZipCode).ToList();
        }

        public List<Address> getAddressesByType(int typeId)
        {
            
            return context.Addresses.Where(a => typeId == a.AddressTypeId).ToList();
        }

        public List<Address> getAddressesByType(AddressType type)
        {
            
            return context.Addresses.Where(a => type.AddressTypeId == a.AddressTypeId).ToList();
        }

       
         */
    }
}
