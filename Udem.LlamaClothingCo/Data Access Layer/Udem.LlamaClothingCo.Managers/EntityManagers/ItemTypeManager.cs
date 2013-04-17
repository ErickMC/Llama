using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Udem.LlamaClothingCo.Entities;

namespace Udem.LlamaClothingCo.Managers
{
    public class ItemTypeManager : IManager<ItemType>
    {
        TestContext context;
         public ItemTypeManager()
        {
            context = new TestContext();
        }

         public ItemType GetByID(int id)
         {
             
             return context.ItemTypes.Single(ct => ct.ItemTypeId == id);
         }

         public IQueryable<ItemType> FindBy(Expression<Func<ItemType, bool>> criteria)
         {
             
             return GetActiveItemTypes().Where(criteria);
         }

         

         public void AddRecord(ItemType itemType)
         {
             
             context.ItemTypes.AddObject(itemType);
             context.SaveChanges();
         }

         public void UpdateRecord(ItemType itemType)
         {
             context.ItemTypes.Detach(itemType);
             context.ItemTypes.Attach(context.ItemTypes.Single(at => at.ItemTypeId == itemType.ItemTypeId));
             context.ItemTypes.ApplyCurrentValues(itemType);
             context.SaveChanges();
         }

         public void DeleteRecord(ItemType itemType)
         {
             
             itemType.IsItemTypeActive = false;
             UpdateRecord(itemType);
         }

         public IQueryable<ItemType> GetActiveItemTypes()
         {
             
             return context.ItemTypes.Where(it => it.IsItemTypeActive);
         }

        /*
        public ItemType getItemTypeByName(String name)
        {
            
            return context.ItemTypes.Single(ct => ct.TypeName.Equals(name));
        }
         */

        
    }
}
