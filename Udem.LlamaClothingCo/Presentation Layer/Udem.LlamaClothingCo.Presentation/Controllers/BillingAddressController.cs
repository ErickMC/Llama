using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Udem.LlamaClothingCo.Presentation.Models;
using Udem.LlamaClothingCo.Business;
using Udem.LlamaClothingCo.Entities;

namespace Udem.LlamaClothingCo.Presentation.Controllers
{ 
    public class BillingAddressController : Controller
    {
        public AddressLogic addressLogic = new AddressLogic();

        //
        // GET: /BillingAddress/

        public ViewResult Index()
        {
            return View(addressLogic.GetActiveAddresses());
        }

        //
        // GET: /BillingAddress/Details/5

        public ViewResult Details(int id)
        {
            Address billingaddress = addressLogic.GetAddressByID(id) as Address;
            return View(billingaddress);
        }

        //
        // GET: /BillingAddress/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /BillingAddress/Create

        [HttpPost]
        public ActionResult Create(Address billingaddress)
        {
            if (ModelState.IsValid)
            {
                addressLogic.AddAddress(billingaddress);
                return RedirectToAction("Index");  
            }

            return View(billingaddress);
        }
        
        //
        // GET: /BillingAddress/Edit/5
 
        public ActionResult Edit(int id)
        {
            Address billingaddress = addressLogic.GetAddressByID(id) as Address;
            return View(billingaddress);
        }

        //
        // POST: /BillingAddress/Edit/5


        [HttpPost]
        public ActionResult Edit(Address billingaddress)
        {
            if (ModelState.IsValid)
            {
                addressLogic.UpdateAddress(billingaddress);
                return RedirectToAction("Index");
            }
            return View(billingaddress);
        }

        //
        // GET: /BillingAddress/Delete/5
 
        public ActionResult Delete(int id)
        {
            Address billingaddress = addressLogic.GetAddressByID(id) as Address;
            return View(billingaddress);
        }

        //
        // POST: /BillingAddress/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Address billingaddress = addressLogic.GetAddressByID(id) as Address;
            addressLogic.DeleteAddress(billingaddress);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            ;/*db.Dispose();
            base.Dispose(disposing);*/
        }
    }
}