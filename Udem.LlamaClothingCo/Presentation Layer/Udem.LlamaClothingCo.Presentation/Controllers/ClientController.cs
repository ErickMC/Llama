using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Udem.LlamaClothingCo.Presentation.Models;
using Udem.LlamaClothingCo.Entities;
using Udem.LlamaClothingCo.Business;

namespace Udem.LlamaClothingCo.Presentation.Controllers
{ 
    public class ClientController : Controller
    {
        public ClientLogic clientLogic = new ClientLogic();
        //
        // GET: /Client/

        public ViewResult Index()
        {
            return View(clientLogic.GetAllActiveClients());
        }

        //
        // GET: /Client/Details/5

        public ViewResult Details(int id)
        {
            Client client = clientLogic.GetClientByID(id);
            return View(client);
        }

        //
        // GET: /Client/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Client/Create

        [HttpPost]
        public ActionResult Create(Client client)
        {
            if (ModelState.IsValid)
            {
                clientLogic.AddClient(client);
                return RedirectToAction("Index");  
            }

            return View(client);
        }
        
        //
        // GET: /Client/Edit/5
 
        public ActionResult Edit(int id)
        {
            Client client = clientLogic.GetClientByID(id);
            return View(client);
        }

        //
        // POST: /Client/Edit/5

        [HttpPost]
        public ActionResult Edit(Client client)
        {
            if (ModelState.IsValid)
            {
                clientLogic.UpdateClient(client);
            }
            return View(client);
        }

        //
        // GET: /Client/Delete/5
 
        public ActionResult Delete(int id)
        {
            Client client = clientLogic.GetClientByID(id);
            return View(client);
        }

        //
        // POST: /Client/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Client client = clientLogic.GetClientByID(id);
            clientLogic.DeleteClient(client);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            ;/*db.Dispose();
            base.Dispose(disposing);*/
        }
    }
}