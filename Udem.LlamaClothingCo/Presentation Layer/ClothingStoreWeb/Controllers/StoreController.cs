using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Udem.LlamaClothingCo.Business;

namespace ClothingStoreWeb.Controllers
{
    public class StoreController : Controller
    {
        public StoreController() : base()
        {

        }
        
        //
        // GET: /Store/
        protected ItemLogic itemLogic = new ItemLogic();

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Store/Details/5

        public ActionResult Details(int id)
        {
            var item = itemLogic.GetItemByID(id);
            return View(item);
        }

        //
        // GET: /Store/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Store/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Store/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Store/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Store/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Store/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: /Store/Browse?catego=1

        public ActionResult Browse(int id)
        {
            // Retrieve Genre and its Associated items from database
            var items = itemLogic.GetItemsByType(id);
            return View(items);
        }


        [ChildActionOnly]
        public ActionResult CategoMenu()
        {
            var catego = itemLogic.GetActiveItemTypes();

            return PartialView(catego);
        }

        [ChildActionOnly]
        public ActionResult ItemsMenu()
        {
            var items = itemLogic.GetActiveItems();

            return PartialView(items);
        }
    }
}
