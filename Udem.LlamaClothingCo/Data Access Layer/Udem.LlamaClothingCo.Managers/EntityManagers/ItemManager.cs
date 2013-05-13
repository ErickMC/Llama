using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Udem.LlamaClothingCo.Entities;

namespace Udem.LlamaClothingCo.Managers
{
    public class ItemManager : IManager<Item>
    {
        TestContext context; 
        public ItemManager(TestContext context)
        {
            this.context = context;
        }

        public Item GetByID(int id)
        {
            
            Item item = context.Items.Single(a => id == a.ItemId);
            return item;
        }

        public IQueryable<Item> FindBy(Expression<Func<Item, bool>> criteria)
        {
            
            return GetActiveItems().Where(criteria);
        }
        public void AddRecord(Item item)
        {
            
            context.Items.AddObject(item);
            context.SaveChanges();
        }

        public void UpdateRecord(Item item)
        {
            if (item.EntityState == System.Data.EntityState.Detached)
            {
                context.Items.Attach(context.Items.Single(i => i.ItemId == item.ItemId));
            }
            context.Items.ApplyCurrentValues(item);
            context.SaveChanges();
        }

        public void DeleteRecord(Item item)
        {
            
            item.IsItemActive = false;
            UpdateRecord(item);
        }

        public IQueryable<Item> GetActiveItems()
        {
            
            return context.Items.Where(i => i.IsItemActive);
        }
        /*

        public List<Item> getItemsByName(String name)
        {
            
            return context.Items.Where(i => name == i.Name).ToList();
        }

        public List<Item> getItemsByCost(decimal cost)
        {
            
            return context.Items.Where(i => cost == i.Cost).ToList();
        }

        public List<Item> getItemsByType(int typeId)
        {
            
            return context.Items.Where(i => typeId == i.ItemTypeId).ToList();
        }
        */       
    }
}
