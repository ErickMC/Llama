using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Udem.LlamaClothingCo.Entities;
using Udem.LlamaClothingCo.Business;

namespace ClothingStoreWeb.Controllers
{
    public class ItemController : Controller
    {
        public ItemLogic itemLogic = new ItemLogic();
        //
        // GET: /Item/

        public ActionResult Index()
        {
            return View(itemLogic.GetActiveItems());
        }

        //
        // GET: /Item/Details/5

        public ActionResult Details(int id)
        {
            Item item = itemLogic.GetItemByID(id);
            return View(item);
        }

        //
        // GET: /Item/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Item/Create

        [HttpPost]
        public ActionResult Create(Item item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    itemLogic.AddItem(item);
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View(item);
            }
        }

        //
        // GET: /Item/Edit/5

        public ActionResult Edit(int id)
        {
            Item item = itemLogic.GetItemByID(id);
            return View(item);
        }

        //
        // POST: /Item/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Item item)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    itemLogic.UpdateItem(item);
                }
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View(item);
            }
        }

        //
        // GET: /Item/Delete/5

        public ActionResult Delete(int id)
        {
            Item item = itemLogic.GetItemByID(id);
            return View(item);
        }

        //
        // POST: /Item/Delete/5

        //[HttpPost]
        //public ActionResult Delete(int id)
        //{
        //    Item item = itemLogic.GetItemByID(id);
        //    try
        //    {
        //        // TODO: Add delete logic here
        //        itemLogic.DeleteItem(item);
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View(item);
        //    }
        //}
    }
}
