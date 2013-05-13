using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Udem.LlamaClothingCo.Managers;
using Udem.LlamaClothingCo.Entities;

namespace Udem.LlamaClothingCo.Business
{
    public class AddressLogic
    {
        private AddressManager _addressManager;

        public AddressManager Address_Manager
        {
            get
            {
                return _addressManager;
            }
            set
            {
                _addressManager = value;
            }
        }
        public AddressLogic(TestContext context)
        {
            Address_Manager = new AddressManager(context);            
        }

        public void AddAddress(Address address)
        {
            Address_Manager.AddRecord(address);
        }

        public void DeleteAddress(Address address)
        {
            Address_Manager.DeleteRecord(address);
        }

        public void UpdateAddress(Address address)
        {
            Address_Manager.UpdateRecord(address);
        }



        public Address GetAddressByID(int id)
        {
            return Address_Manager.GetByID(id);
        }

        public ICollection<Address> GetActiveAddresses()
        {
            return Address_Manager.GetActiveAddresses().ToList();
        }

        public ICollection<Address> GetAddressesByCity(string city)
        {
            return Address_Manager.FindBy(a => a.City == city).ToList();
        }

        public ICollection<Address> GetAddressesByState(string state)
        {
            return Address_Manager.FindBy(a => a.State == state).ToList();
        }

        public ICollection<Address> GetAddressesByZipCode(int zipCode)
        {
            return Address_Manager.FindBy(a => a.ZipCode == zipCode).ToList();
        }

        public ICollection<Address> GetAddressesByType(AddressType type)
        {
            return Address_Manager.FindBy(a => a.AddressType.Equals(type)).ToList();
        }

        public ICollection<Address> GetAddressesByType(int type)
        {
            return Address_Manager.FindBy(i => i.AddressType.AddressTypeId.Equals(type)).ToList();
        }
    }
}
