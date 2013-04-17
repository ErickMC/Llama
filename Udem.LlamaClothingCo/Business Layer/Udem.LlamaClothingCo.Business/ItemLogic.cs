using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Udem.LlamaClothingCo.Managers;
using Udem.LlamaClothingCo.Entities;

namespace Udem.LlamaClothingCo.Business
{
    public class ItemLogic
    {
        private ItemManager _itemManager;

        public ItemManager Item_Manager
        {
            get
            {
                return _itemManager ?? new ItemManager();
            }
            set
            {
                _itemManager = value;
            }
        }
        public ItemLogic()
        {
            Item_Manager = new ItemManager();            
        }

        public void AddItem(Item item)
        {
            Item_Manager.AddRecord(item);
        }

        public void DeleteItem(Item item)
        {
            Item_Manager.DeleteRecord(item);
        }

        public void UpdateItem(Item item)
        {
            Item_Manager.UpdateRecord(item);
        }



        public Item GetItemByID(int id)
        {
            return Item_Manager.GetByID(id);
        }

        public ICollection<Item> GetActiveItems()
        {
            return Item_Manager.GetActiveItems().ToList();
        }

        public Item GetItemByName(string name)
        {
            return Item_Manager.FindBy(i => i.Name == name).First();
        }

        public ICollection<Item> GetItemsByType(ItemType type)
        {
            return Item_Manager.FindBy(i => i.ItemType.Equals(type)).ToList();
        }

       
    }
}
