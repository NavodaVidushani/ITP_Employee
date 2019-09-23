using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inventory_management.Models;

namespace Inventory_management.Controllers
{
    public class UserScheduleController : Controller
    {
        inventorymgtEntities db = new inventorymgtEntities();

        // GET: UserSchedule
        public ActionResult Index()
        {
            return View(db.schedules.ToList());
        }

        // GET: UserSchedule/Details/5
        public ActionResult Details(int id)
        {
            schedule sc = new schedule();
            using (inventorymgtEntities db = new inventorymgtEntities())
            {
                sc = db.schedules.Where(m => m.ID == id).FirstOrDefault();
            }
            return View(sc);
        }

        // GET: UserSchedule/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserSchedule/Create
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

        public ActionResult Message(int id)
        {
            schedule sc = new schedule();
            using (inventorymgtEntities db = new inventorymgtEntities())
            {
                sc = db.schedules.Where(m => m.ID == id).FirstOrDefault();
            }
            return View(sc);
        }

        public ActionResult downloadFile(string filename)
        {
            if (Path.GetExtension(filename) == ".JPG")
            {
                string fileName = Path.GetFileNameWithoutExtension(filename);
                string extension = Path.GetExtension(filename);
                string NewFile = fileName + extension;
                string fullpath = Path.Combine(Server.MapPath("~/Content/Images/"), NewFile);
                return File(fullpath, "Images/JPG");
            }
            else
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.Forbidden);
            }
            
        }

        // GET: UserSchedule/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserSchedule/Edit/5
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

        // GET: UserSchedule/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserSchedule/Delete/5
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
    }
}
