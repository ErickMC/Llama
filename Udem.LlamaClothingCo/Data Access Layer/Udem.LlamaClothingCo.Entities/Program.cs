

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Entity;
using System.Data.EntityClient;
using System.Data.EntityModel;

namespace FirstTest
{
    class Program
    {
        static String answer = "";
        
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the test. Please indicate your desired action");
            Console.WriteLine("1-Add a new record\n2-See a record\n3-Update a record\n4-Delete a record");
            answer = Console.In.ReadLine();

            switch (answer)
            {
                case "1":
                    printMenuAdd();
                    break;
                case "2":
                    printMenuRead();
                    break;
                case "3":
                    printMenuUpdate();
                    break;
                case "4":
                    printMenuDelete();
                    break;
            }

            Console.ReadLine();
        }

        static void printMenuAdd()
        {
            Console.WriteLine("Would you like to add a: \n1-Customer\n2-Address\n3-Item?");
            answer = Console.In.ReadLine();

            switch (answer)
            {
                case "1":
                    printMenuAddingClient();
                    break;
                case "2":
                    printMenuAddingAddress();
                    break;
                case "3":
                    printMenuAddingItem();
                    break;
            }


        }

        static void printMenuRead()
        {
            Console.WriteLine("Would you like to update a: \n1-Customer\n2-Address\n3-Item?");
            answer = Console.In.ReadLine();

            switch (answer)
            {
                case "1":
                    printMenuReadingClient();
                    break;
                case "2":
                    printMenuReadingAddress();
                    break;
                case "3":
                    printMenuReadingItems();
                    break;
            }


        }

        static void printMenuUpdate()
        {
            Console.WriteLine("Would you like to see the: \n1-Customers\n2-Addresses\n3-Items?");
            answer = Console.In.ReadLine();

            switch (answer)
            {
                case "1":
                    printMenuUpdatingClient();
                    break;
                case "2":
                    printMenuUpdatingAddress();
                    break;
                case "3":
                    printMenuUpdatingItem();
                    break;
            }


        }


        static void printMenuDelete()
        {
            Console.WriteLine("Would you like to delete a: \n1-Customer\n2-Address\n3-Item?");
            answer = Console.In.ReadLine();

            switch (answer)
            {
                case "1":
                    printMenuDeletingClient();
                    break;
                case "2":
                    printMenuDeletingAddress();
                    break;
                case "3":
                    printMenuDeletingItem();
                    break;
            }


        }

        static void printMenuAddingClient()
        {
            TestContext context = new TestContext();
            Console.WriteLine("First Name:");
            String firstName = Console.In.ReadLine();
            Console.WriteLine("Last Name:");
            String lastName = Console.In.ReadLine();
            Console.WriteLine("RFC:");
            String rfc = Console.In.ReadLine();
            Console.WriteLine("Select a valid Address ID:");
            foreach (Address a in context.Addresses.ToList())
            {
                Console.Write("Id:" + a.AddressId + " Address:" + a.Street + " #" + a.Number + "\nCity:" + a.City + " State:" + a.State + " Zip Code:" + a.ZipCode+"\n");
            }
            String addressId = Console.In.ReadLine();
            Console.WriteLine("Select a valid Billing Address ID from the following:");
            foreach (Address a in context.Addresses.ToList())
            {
                Console.Write("Id:" + a.AddressId + "\nAddress:" + a.Street + " #" + a.Number + "\nCity:" + a.City + " State:" + a.State + " Zip Code:" + a.ZipCode + "\n");
            }
            String billingAddressId = Console.In.ReadLine();
            Console.WriteLine("Select a valid Client Type ID from the following:");
            foreach (ClientType c in context.ClientTypes.ToList())
            {
                Console.Write("Id: " + c.ClientTypeId + "\tName: "+ c.TypeName + "\t Description: " + c.Description+"\n");
            }
            String clientTypeId = Console.In.ReadLine();
            Client client = new Client
            {
                FirstName = firstName,
                LastName = lastName,
                RFC = rfc,
                AddressID = int.Parse(addressId),
                BillingAddressID = int.Parse(billingAddressId),
                ClientTypeId = int.Parse(clientTypeId)
            };

            AddRecord(client);
            Console.WriteLine("Your client has been succesfully added to the database");
        }

        static void printMenuAddingAddress()
        {
            TestContext context = new TestContext();
            Console.WriteLine("Street:");
            String street = Console.In.ReadLine();
            Console.WriteLine("Number:");
            String number = Console.In.ReadLine();
            Console.WriteLine("City:");
            String city = Console.In.ReadLine();
            Console.WriteLine("State:");
            String state = Console.In.ReadLine();
            Console.WriteLine("Select a valid Address Type ID from the following:");
            foreach (AddressType a in context.AddressTypes.ToList())
            {
                Console.Write("Id: " + a.AddressTypeId + "\tName: "+a.TypeName+"\n Description: "+a.Description);
            }
            String addressTypeId = Console.In.ReadLine();
            Address address = new Address
            {
                Street = street, Number = int.Parse(number), City = city, State = state, AddressTypeId = int.Parse(addressTypeId)
            };

            AddRecord(address);
            Console.WriteLine("The address has been succesfully added to the database");
        }

        static void printMenuAddingItem()
        {
            TestContext context = new TestContext();
            Console.WriteLine("Name:");
            String name = Console.In.ReadLine();
            Console.WriteLine("Description:");
            String description = Console.In.ReadLine();
            Console.WriteLine("Cost (No commas or dollar signs):");
            String cost = Console.In.ReadLine();
            Console.WriteLine("Select a valid Item Type ID from the following:");
            foreach (ItemType i in context.ItemTypes.ToList())
            {
                Console.Write("Id: " + i.ItemTypeId + "\tName: " + i.TypeName + "\n Description: " + i.Description);
            }
            String itemTypeId = Console.In.ReadLine();
            Item item = new Item
            {
               Name = name, Description = description, Cost = Decimal.Parse(cost), ItemTypeId = int.Parse(itemTypeId) 
            };

            AddRecord(item);
            Console.WriteLine("The item has been succesfully added to the database");
        }


        static void printMenuReadingClient()
        {
            TestContext context = new TestContext();
            Console.WriteLine("Enter the ID of the client (Or -1 to see all clients)");
            answer = Console.In.ReadLine();

            if (answer.Equals("-1"))
            {
                foreach (Client c in context.Clients.ToList())
                {
                    Console.WriteLine("Id: " + c.ClientId + "\n First Name: " + c.FirstName
                                      + "\nLast Name:" + c.LastName + "\nRFC: " + c.RFC
                                      + "\nAddress Id :" + c.AddressID + "\nBilling Address Id:" + c.BillingAddressID
                                      + "\nClient Type Id: " + c.ClientTypeId);
                }
            }
            else
            {
                int id = int.Parse(answer);
               Client c = context.Clients.FirstOrDefault(cl => cl.ClientId == id);
               Console.WriteLine("Id: " + c.ClientId + "\n First Name: " + c.FirstName
                                     + "\nLast Name:" + c.LastName + "\nRFC: " + c.RFC
                                     + "\nAddress Id :" + c.AddressID + "\nBilling Address Id:" + c.BillingAddressID
                                     + "\nClient Type Id: " + c.ClientTypeId);
            }

        }

        static void printMenuReadingAddress()
        {
            TestContext context = new TestContext();
            Console.WriteLine("Enter the ID of the address (Or -1 to see all addressess)");
            answer = Console.In.ReadLine();

            if (answer.Equals("-1"))
            {
                foreach (Address a in context.Addresses.ToList())
                {
                    Console.WriteLine("Id: " + a.AddressId + "\n Street: " + a.Street
                                      + "\nNumber:" + a.Number + "\nCity: " + a.City
                                      + "\nState :" + a.State + "\nZip Code:" + a.ZipCode
                                      + "\nAddress Type Id: " + a.AddressTypeId);
                }
            }
            else
            {
                int id = int.Parse(answer);
                Address a = context.Addresses.FirstOrDefault(ad => ad.AddressId == id);
                Console.WriteLine("Id: " + a.AddressType + "\n Street: " + a.Street
                                     + "\nNumber:" + a.Number + "\nCity: " + a.City
                                     + "\nState :" + a.State + "\nZip Code:" + a.ZipCode
                                     + "\nAddress Type Id: " + a.AddressTypeId);
            }
        }

        static void printMenuReadingItems()
        {
            TestContext context = new TestContext();
            Console.WriteLine("Enter the ID of the items (Or -1 to see all items)");
            answer = Console.In.ReadLine();

            if (answer.Equals("-1"))
            {
                foreach (Item i in context.Items.ToList())
                {
                    Console.WriteLine("Id: " + i.ItemId + "\n Name: " + i.Name
                                      + "\nDescription:" + i.Description + "\nCost: " + i.Cost
                                      + "\nItem Type Id :" + i.ItemTypeId);
                }
            }
            else
            {
                int id = int.Parse(answer);
                Item i = context.Items.FirstOrDefault(it => it.ItemId == id);
                Console.WriteLine("Id: " + i.ItemId + "\n Name: " + i.Name
                                      + "\nDescription:" + i.Description + "\nCost: " + i.Cost
                                      + "\nItem Type Id :" + i.ItemTypeId);
            }
        }

        static void printMenuUpdatingClient()
        {
            TestContext context = new TestContext();

            
            Console.WriteLine("Enter the ID of the client to update");
            answer = Console.In.ReadLine();
            
            int id = int.Parse(answer);
            Client c = context.Clients.FirstOrDefault(cl => cl.ClientId == id);
            Console.WriteLine("Id: " + c.ClientId + "\n First Name: " + c.FirstName
                                    + "\nLast Name:" + c.LastName + "\nRFC: " + c.RFC
                                    + "\nAddress Id :" + c.AddressID + "\nBilling Address Id:" + c.BillingAddressID
                                    + "\nClient Type Id: " + c.ClientTypeId);

            Console.WriteLine("\nEnter the new data for this client");
            Console.WriteLine("First Name:");
            String firstName = Console.In.ReadLine();
            Console.WriteLine("Last Name:");
            String lastName = Console.In.ReadLine();
            Console.WriteLine("RFC:");
            String rfc = Console.In.ReadLine();
            Console.WriteLine("Select a valid Address ID:");
            foreach (Address a in context.Addresses.ToList())
            {
                Console.Write("Id:" + a.AddressId + " Address:" + a.Street + " #" + a.Number + "\nCity:" + a.City + " State:" + a.State + " Zip Code:" + a.ZipCode + "\n");
            }
            String addressId = Console.In.ReadLine();
            Console.WriteLine("Select a valid Billing Address ID from the following:");
            foreach (Address a in context.Addresses.ToList())
            {
                Console.Write("Id:" + a.AddressId + "\nAddress:" + a.Street + " #" + a.Number + "\nCity:" + a.City + " State:" + a.State + " Zip Code:" + a.ZipCode + "\n");
            }
            String billingAddressId = Console.In.ReadLine();
            Console.WriteLine("Select a valid Client Type ID from the following:");
            foreach (ClientType ct in context.ClientTypes.ToList())
            {
                Console.Write("Id: " + ct.ClientTypeId + "\tName: " + ct.TypeName + "\t Description: " + ct.Description + "\n");
            }
            String clientTypeId = Console.In.ReadLine();
            Client client = new Client
            {   ClientId  = id,
                FirstName = firstName,
                LastName = lastName,
                RFC = rfc,
                AddressID = int.Parse(addressId),
                BillingAddressID = int.Parse(billingAddressId),
                ClientTypeId = int.Parse(clientTypeId)
            };

            UpdateRecord(client);
            Console.WriteLine("Your client has been succesfully updated");
        }

        static void printMenuUpdatingAddress()
        {
            TestContext context = new TestContext();

            Console.WriteLine("Enter the ID of the address to update");
            answer = Console.In.ReadLine();
            int id = int.Parse(answer);
            Address a = context.Addresses.FirstOrDefault(ad => ad.AddressId == id);
            Console.WriteLine("Id: " + a.AddressId + "\n Street: " + a.Street
                                 + "\nNumber:" + a.Number + "\nCity: " + a.City
                                 + "\nState :" + a.State + "\nZip Code:" + a.ZipCode
                                 + "\nAddress Type Id: " + a.AddressTypeId);
            Console.WriteLine("\nEnter the new data for this address");
            Console.WriteLine("Street:");
            String street = Console.In.ReadLine();
            Console.WriteLine("Number:");
            String number = Console.In.ReadLine();
            Console.WriteLine("City:");
            String city = Console.In.ReadLine();
            Console.WriteLine("State:");
            String state = Console.In.ReadLine();
            Console.WriteLine("Select a valid Address Type ID from the following:");
            foreach (AddressType at in context.AddressTypes.ToList())
            {
                Console.Write("Id: " + at.AddressTypeId + "\tName: " + at.TypeName + "\n Description: " + at.Description);
            }
            String addressTypeId = Console.In.ReadLine();
            Address address = new Address
            {
                AddressId = id,
                Street = street,
                Number = int.Parse(number),
                City = city,
                State = state,
                AddressTypeId = int.Parse(addressTypeId)
            };

            UpdateRecord(address);
            Console.WriteLine("Your address has been succesfully updated");

        }

        static void printMenuUpdatingItem()
        {
            TestContext context = new TestContext();

            Console.WriteLine("Enter the ID of the item to update");
            answer = Console.In.ReadLine();
            int id = int.Parse(answer);

            Item i = context.Items.FirstOrDefault(it => it.ItemId == id);
            Console.WriteLine("Id: " + i.ItemId + "\n Name: " + i.Name
                                  + "\nDescription:" + i.Description + "\nCost: " + i.Cost
                                  + "\nItem Type Id :" + i.ItemTypeId);

            Console.WriteLine("\nEnter the new data for this item");
            Console.WriteLine("Name:");
            String name = Console.In.ReadLine();
            Console.WriteLine("Description:");
            String description = Console.In.ReadLine();
            Console.WriteLine("Cost (No commas or dollar signs):");
            String cost = Console.In.ReadLine();
            Console.WriteLine("Select a valid Item Type ID from the following:");
            foreach (ItemType it in context.ItemTypes.ToList())
            {
                Console.Write("Id: " + it.ItemTypeId + "\tName: " + it.TypeName + "\n Description: " + it.Description);
            }
            String itemTypeId = Console.In.ReadLine();
            Item item = new Item
            {
                ItemId = id,
                Name = name,
                Description = description,
                Cost = Decimal.Parse(cost),
                ItemTypeId = int.Parse(itemTypeId)
            };

            UpdateRecord(item);
            Console.WriteLine("Your items has been succesfully updated");
        }

        static void printMenuDeletingClient()
        {
            Client c;
            using (TestContext context = new TestContext())
            {

                Console.WriteLine("Enter the ID of the client to delete");
                answer = Console.In.ReadLine();

                int id = int.Parse(answer);
                c = context.Clients.FirstOrDefault(cl => cl.ClientId == id);
                Console.WriteLine("Id: " + c.ClientId + "\n First Name: " + c.FirstName
                                        + "\nLast Name:" + c.LastName + "\nRFC: " + c.RFC
                                        + "\nAddress Id :" + c.AddressID + "\nBilling Address Id:" + c.BillingAddressID
                                        + "\nClient Type Id: " + c.ClientTypeId);

                Console.WriteLine("Are you sure you want to delete this client? (Y/N)");
            }
            
            if (Console.ReadLine().ToLower().Equals("y"))
            {
                DeleteRecord(c);
                Console.WriteLine("Client succesfully deleted");
            }
            else
            {
                Console.WriteLine("Deletion aborted");
            }
        }

        static void printMenuDeletingAddress()
        {
            Address a;
            using (TestContext context = new TestContext())
            {

                Console.WriteLine("Enter the ID of the address to delete");
                answer = Console.In.ReadLine();
                int id = int.Parse(answer);
                a = context.Addresses.FirstOrDefault(ad => ad.AddressId == id);
                Console.WriteLine("Id: " + a.AddressId + "\n Street: " + a.Street
                                     + "\nNumber:" + a.Number + "\nCity: " + a.City
                                     + "\nState :" + a.State + "\nZip Code:" + a.ZipCode
                                     + "\nAddress Type Id: " + a.AddressTypeId);

                Console.WriteLine("Are you sure you want to delete this client? (Y/N)");
            }

            if (Console.ReadLine().ToLower().Equals("y"))
            {
                DeleteRecord(a);
                Console.WriteLine("Address succesfully deleted");
            }
            else
            {
                Console.WriteLine("Deletion aborted");
            }
        }

        static void printMenuDeletingItem()
        {
            Item i;
            using (TestContext context = new TestContext())
            {

                Console.WriteLine("Enter the ID of the item to delete");
                answer = Console.In.ReadLine();
                int id = int.Parse(answer);

                i = context.Items.FirstOrDefault(it => it.ItemId == id);
                Console.WriteLine("Id: " + i.ItemId + "\n Name: " + i.Name
                                      + "\nDescription:" + i.Description + "\nCost: " + i.Cost
                                      + "\nItem Type Id :" + i.ItemTypeId);
                Console.WriteLine("Are you sure you want to delete this client? (Y/N)");
            }

            if (Console.ReadLine().ToLower().Equals("y"))
            {
                DeleteRecord(i);
                Console.WriteLine("Item succesfully deleted");
            }
            else
            {
                Console.WriteLine("Deletion aborted");
            }
        }

        
        static void AddRecord(Client client)
        {
            TestContext context = new TestContext();
            context.Clients.AddObject(client);
            context.SaveChanges();
        }

        
        static void AddRecord(Address address)
        {
            TestContext context = new TestContext();
            context.Addresses.AddObject(address);
            context.SaveChanges();
        }

        static void AddRecord(Item item)
        {
            TestContext context = new TestContext();
            context.Items.AddObject(item);
            context.SaveChanges();
        }

        static void UpdateRecord(Client client)
        {
            TestContext context = new TestContext();
            context.Clients.Attach(context.Clients.Single(c => c.ClientId == client.ClientId));
            context.Clients.ApplyCurrentValues(client);
            context.SaveChanges();
        }
        static void UpdateRecord(Address address)
        {
            TestContext context = new TestContext();
            context.Addresses.Attach(context.Addresses.Single(c => c.AddressId == address.AddressId));
            context.Addresses.ApplyCurrentValues(address);
            context.SaveChanges();
        }
        static void UpdateRecord(Item item)
        {
            TestContext context = new TestContext();
            context.Items.Attach(context.Items.Single(c => c.ItemId == item.ItemId));
            context.Items.ApplyCurrentValues(item);
            context.SaveChanges();
        }

        static void DeleteRecord(Client client)
        {
            TestContext context = new TestContext();
            context.Clients.Attach(client);
            context.Clients.DeleteObject(client);
            context.SaveChanges();
        }


        static void DeleteRecord(Address address)
        {
            TestContext context = new TestContext();
            context.Addresses.Attach(address);
            context.Addresses.DeleteObject(address);
            context.SaveChanges();
        }

        static void DeleteRecord(Item item)
        {
            TestContext context = new TestContext();
            context.Items.Attach(item);
            context.Items.DeleteObject(item);

            context.SaveChanges();
        }
    }
}
