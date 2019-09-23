using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq;
using System.Web.UI;
using System.Web.Mvc;
using Inventory_management.Models;
using System.Data.Entity;

namespace Inventory_management.Controllers
{
    public class TrainerController : Controller
    {
        inventorymgtEntities dbModel = new inventorymgtEntities();

        public ActionResult Search()
        {

            return View(dbModel.trainers.ToList());
        }


        // GET: Trainer
        public ActionResult Index()
        {
             return View(dbModel.trainers.ToList());
            
        }

        // GET: Trainer/Details/5
        public ActionResult Details(int id)
        {
            using(inventorymgtEntities dbModel = new inventorymgtEntities())
            {

                return View(dbModel.trainers.Where(x => x.PaymentID== id).FirstOrDefault());
            }

            
        }

        // GET: Trainer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Trainer/Create
        [HttpPost]
        public ActionResult Create(trainer Trainer)
        {
            try
            {                
                    dbModel.trainers.Add(Trainer);
                    dbModel.SaveChanges();
                
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Create2(trainer Trainer)
        {
            try
            {
                using (inventorymgtEntities dbModel = new inventorymgtEntities())
                {
                    dbModel.trainers.Add(Trainer);
                    dbModel.SaveChanges();
                }
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Trainer/Edit/5
        public ActionResult Edit(int id)
        {
            using (inventorymgtEntities dbModel = new inventorymgtEntities())
            {

                return View(dbModel.trainers.Where(x => x.PaymentID == id).FirstOrDefault());
            }
        }

        // POST: Trainer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, trainer Trainer)
        {
            try
            {

                using (inventorymgtEntities dbModel = new inventorymgtEntities()) {

                    dbModel.Entry(Trainer).State = EntityState.Modified;
                    dbModel.SaveChanges();
                }
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Trainer/Delete/5
        public ActionResult Delete(int id)
        {
            using (inventorymgtEntities dbModel = new inventorymgtEntities())
            {

                return View(dbModel.trainers.Where(x => x.PaymentID == id).FirstOrDefault());
            }
        }

        // POST: Trainer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                
                using (inventorymgtEntities dbModel = new inventorymgtEntities())
                {
                    trainer Trainer = dbModel.trainers.Where(x => x.PaymentID == id).FirstOrDefault();
                    dbModel.trainers.Remove(Trainer);
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
