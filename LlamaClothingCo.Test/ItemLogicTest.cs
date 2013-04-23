using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Udem.LlamaClothingCo.Business;
using Udem.LlamaClothingCo.Entities;

namespace LlamaClothingCo.Test
{
    [TestClass]
    public class ItemLogicTest
    {
        private static Item testItem = new Item();

        public static void CreateTestItem()
        {
            testItem.ItemId = 1;
            testItem.Name = "Itemppprueba";
            testItem.Description = "good";
            testItem.Cost = 120;
            testItem.ItemTypeId = 1;
            testItem.IsItemActive = true;
        }

        [TestMethod]
        public void Insert_Item_To_Database()
        {
            CreateTestItem();
            ItemLogic logic = new ItemLogic();
            logic.AddItem(testItem);
        }

        [TestMethod]
        public void Update_Item_From_Database()
        {
            CreateTestItem();
            ItemLogic logic = new ItemLogic();
            testItem.Description = "changed by update";
            logic.UpdateItem(testItem);
        }

        [TestMethod]
        public void Delete_Item_From_Database()
        {
            CreateTestItem();
            ItemLogic logic = new ItemLogic();
            logic.AddItem(testItem);
            logic.DeleteItem(testItem);
        }


        [TestMethod]
        public void Get_Item_From_Database_By_Id()
        {
            CreateTestItem();
            ItemLogic logic = new ItemLogic();
            logic.GetItemByID(2);
        }

        [TestMethod]
        public void Get_Active_Items()
        {
            CreateTestItem();
            ItemLogic logic = new ItemLogic();
            logic.GetActiveItems();
        }

        [TestMethod]
        public void Get_Item_From_Database_By_Name()
        {
            CreateTestItem();
            ItemLogic logic = new ItemLogic();
            logic.GetItemByName("ItemPrueba");
        }

        [TestMethod]
        public void Get_Items_From_Database_By_Type()
        {
            CreateTestItem();
            ItemLogic logic = new ItemLogic();
            logic.GetItemsByType(1);
        }

    }
}
