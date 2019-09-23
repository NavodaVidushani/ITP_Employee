using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inventory_management.Models;

namespace Inventory_management.Controllers
{
    public class SupplierController : Controller
    {
        inventorymgtEntities invtModel = new inventorymgtEntities();
   
        // GET: Supplier
        public ActionResult Index()
        {

            return View(invtModel.suppliers.ToList());
        }

        // GET: Supplier/Details/5
        public ActionResult Details(int? id)
        {
            return View(invtModel.suppliers.Where(x=> x.supplierID == id).FirstOrDefault());
        }

        // GET: Supplier/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Supplier/Create
        [HttpPost]
        public ActionResult Create(supplier sup)
        {
            try
            {
                using (invtModel)
                {
                    
                    invtModel.suppliers.Add(sup);
                    invtModel.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Supplier/Edit/5
        public ActionResult Edit(int id)
        {
            return View(invtModel.suppliers.Where(x => x.supplierID == id).FirstOrDefault());
        }

        // POST: Supplier/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, supplier sup)
        {
            try
            {
                using (invtModel)
                {
                    invtModel.Entry(sup).State = EntityState.Modified;
                    invtModel.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Supplier/Delete/5
        public ActionResult Delete(int id)
        {
            using (invtModel)
            {
                return View(invtModel.suppliers.Where(x => x.supplierID == id).FirstOrDefault());

            }
            return View();
        }

        // POST: Supplier/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (invtModel)
                {

                    supplier sup = invtModel.suppliers.Where(x => x.supplierID == id).FirstOrDefault();
                    invtModel.suppliers.Remove(sup);
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
