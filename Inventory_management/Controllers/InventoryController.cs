using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inventory_management.Models;
using System.Data.Entity;

namespace Inventory_management.Controllers
{
    public class InventoryController : Controller
    {
        // GET: InventoryC:\Users\Akaam Zain\Documents\SLIIT\ITP\Sky Gym\Inventory_management\Controllers\InventoryController.cs
        public ActionResult Index()
        {
            using (inventorymgtEntities invtModel = new inventorymgtEntities())
            {
                
                return View(invtModel.inventories.ToList());

            }

        }

        // GET: Inventory/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Inventory/Create
        public ActionResult Create()
        {

            return View();
        }


        // POST: Inventory/Create
        [HttpPost]
        public ActionResult Create(inventory invent)
        {
            try
            {
                using (inventorymgtEntities invtModel = new inventorymgtEntities())
                {
                   
                    invtModel.inventories.Add(invent);
                    invtModel.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Reorder()
        {

            using (inventorymgtEntities in1 = new inventorymgtEntities())
            {

                return View(in1.inventories.ToList().Where(x => x.quantity < 5 && x.catergory.Equals("Store")));

            }
        }


        public ActionResult ReorderDetails(int id)
        {
            using (inventorymgtEntities invtModel = new inventorymgtEntities())
            {
                return View(invtModel.inventories.Where(x => x.itemCode == id).FirstOrDefault());

            }
        }



        // GET: Inventory/Edit/5
        public ActionResult Edit(int id)
        {
            using (inventorymgtEntities invtModel = new inventorymgtEntities())
            {
                return View(invtModel.inventories.Where(x => x.itemCode == id).FirstOrDefault());

            }


        }

        // POST: Inventory/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, inventory invent)
        {
            try
            {
                using (inventorymgtEntities invtModel = new inventorymgtEntities())
                {
                    invtModel.Entry(invent).State = EntityState.Modified;
                    invtModel.SaveChanges();
                }

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
            using (inventorymgtEntities invtModel = new inventorymgtEntities())
            {
                return View(invtModel.inventories.Where(x => x.itemCode == id ).FirstOrDefault());

            }


        }





        // POST: Inventory/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (inventorymgtEntities invtModel = new inventorymgtEntities())
                {

                    inventory invent = invtModel.inventories.Where(x => x.itemCode == id).FirstOrDefault();
                    invtModel.inventories.Remove(invent);
                    invtModel.SaveChanges();

                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
