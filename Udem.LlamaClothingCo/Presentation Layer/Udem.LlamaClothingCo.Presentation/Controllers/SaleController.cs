using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Udem.LlamaClothingCo.Entities;

namespace Udem.LlamaClothingCo.Presentation.Controllers
{ 
    public class SaleController : Controller
    {
        private TestContext db = new TestContext();

        //
        // GET: /Sale/

        public ViewResult Index()
        {
            var sales = db.Sales.Include("Client").Include("ShippingAddresses");
            return View(sales.ToList());
        }

        //
        // GET: /Sale/Details/5

        public ViewResult Details(int id)
        {
            Sale sale = db.Sales.Single(s => s.SaleId == id);
            return View(sale);
        }

        //
        // GET: /Sale/Create

        public ActionResult Create()
        {
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "FirstName");
            ViewBag.ShippingAddress = new SelectList(db.Addresses, "AddressId", "Street");
            return View();
        } 

        //
        // POST: /Sale/Create

        [HttpPost]
        public ActionResult Create(Sale sale)
        {
            if (ModelState.IsValid)
            {
                db.Sales.AddObject(sale);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "FirstName", sale.ClientId);
            ViewBag.ShippingAddress = new SelectList(db.Addresses, "AddressId", "Street", sale.ShippingAddress);
            return View(sale);
        }
        
        //
        // GET: /Sale/Edit/5
 
        public ActionResult Edit(int id)
        {
            Sale sale = db.Sales.Single(s => s.SaleId == id);
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "FirstName", sale.ClientId);
            ViewBag.ShippingAddress = new SelectList(db.Addresses, "AddressId", "Street", sale.ShippingAddress);
            return View(sale);
        }

        //
        // POST: /Sale/Edit/5

        [HttpPost]
        public ActionResult Edit(Sale sale)
        {
            if (ModelState.IsValid)
            {
                db.Sales.Attach(sale);
                db.ObjectStateManager.ChangeObjectState(sale, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "FirstName", sale.ClientId);
            ViewBag.ShippingAddress = new SelectList(db.Addresses, "AddressId", "Street", sale.ShippingAddress);
            return View(sale);
        }

        //
        // GET: /Sale/Delete/5
 
        public ActionResult Delete(int id)
        {
            Sale sale = db.Sales.Single(s => s.SaleId == id);
            return View(sale);
        }

        //
        // POST: /Sale/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Sale sale = db.Sales.Single(s => s.SaleId == id);
            db.Sales.DeleteObject(sale);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}