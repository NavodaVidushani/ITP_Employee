using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inventory_management.Models;

namespace Inventory_management.Controllers
{
    public class Inventory_payController : Controller
    {
        // GET: Inventory
        public ActionResult Index()

        {
            using (inventorymgtEntities dbModel = new inventorymgtEntities())
            {
                return View(dbModel.inventory_pay.ToList());
            }

        }

        // GET: Inventory/Details/5
        public ActionResult Details(int id)
        {
            using (inventorymgtEntities dbmodel = new inventorymgtEntities())
            {



                return View(dbmodel.inventory_pay.Where(x => x.paymentId== id).FirstOrDefault());
            }
        }

        // GET: Inventory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inventory/Create
        [HttpPost]
        public ActionResult Create(inventory_pay Inventory)
        {
            try
            {
                using (inventorymgtEntities dbmodel = new inventorymgtEntities())
                {
                    dbmodel.inventory_pay.Add(Inventory);
                    dbmodel.SaveChanges();
                }
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Inventory/Edit/5
        public ActionResult Edit(int id)
        {
            using (inventorymgtEntities dbmodel = new inventorymgtEntities())
            {

                return View(dbmodel.inventory_pay.Where(x => x.paymentId == id).FirstOrDefault());
            }
        }

        // POST: Inventory/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, inventory_pay Inventory)
        {
            try
            {
                using (inventorymgtEntities dbmodel = new inventorymgtEntities())
                {
                    dbmodel.Entry(Inventory).State = EntityState.Modified;
                    dbmodel.SaveChanges();

                }
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Inventory/Delete/5
        public ActionResult Delete(int id)
        {
            using (inventorymgtEntities dbmodel = new inventorymgtEntities())
            {
                return View(dbmodel.inventory_pay.Where(x => x.paymentId == id).FirstOrDefault());
            }
        }

        // POST: Inventory/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (inventorymgtEntities dbModel = new inventorymgtEntities())
                {

                    inventory_pay Inventory = dbModel.inventory_pay.Where(x => x.paymentId == id).FirstOrDefault();
                    dbModel.inventory_pay.Remove(Inventory);
                    dbModel.SaveChanges();




                }
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
