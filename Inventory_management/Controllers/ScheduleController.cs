using Inventory_management.Models;
using Inventory_management.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;



namespace Inventory_management.Controllers
{
    public class ScheduleController : Controller
    {

        //DBMod dbs = new DBMod();
        //public ActionResult New()
        //{
            
        //        var employeelist = dbs.employees.ToList();

            
            
        //        var viewModel = new NewScheduleViewModel
        //        {
        //            employeeType = employeelist
        //        };

        //    return View(viewModel);
            

            
            
        //}

        



        //private static List<SelectListItem> Getemployee()
        //{


        //    DBMod db = new DBMod();
        //    List<SelectListItem> employeelist = (from e in db.employees.AsEnumerable()
        //                                         where e.Shift == "Morning"
        //                                         select new SelectListItem
        //                                         {
        //                                             Text = e.Name,
        //                                             Value = e.EmpID.ToString()
        //                                         }).ToList();

        //    employeelist.Insert(0, new SelectListItem { Text = "Select Trainer", Value = "" });
        //    return employeelist;
        //}


        // GET: Schedule
        public ActionResult Index()
        {
            using (inventorymgtEntities mv = new inventorymgtEntities())
            {
                return View(mv.schedules.ToList());
            }
        }

        // GET: Schedule/Details/5
        public ActionResult Details(int id)
        {
            schedule sc = new schedule();
            using (inventorymgtEntities db = new inventorymgtEntities())
            {
                sc = db.schedules.Where(m => m.ID == id).FirstOrDefault();
            }
            return View(sc);
        }

        // GET: Schedule/Create
        public ActionResult Create()
        {
            //List<SelectListItem> employeeList = Getemployee();
            return View();
        }

        // POST: Schedule/Create
        [HttpPost]
        public ActionResult Create(schedule sc)
        {
            try
            {
                string fileName = Path.GetFileNameWithoutExtension(sc.ImageFile.FileName);
                string extension = Path.GetExtension(sc.ImageFile.FileName);
                string imageName = fileName + DateTime.Now.ToString("yymmssfff")+extension;
                sc.Image = "~/Content/Images/" + imageName;
                imageName = Path.Combine(Server.MapPath("~/Content/Images/"), imageName);
                sc.ImageFile.SaveAs(imageName);
                using (inventorymgtEntities mv = new inventorymgtEntities())
                {

                    mv.schedules.Add(sc);
                    mv.SaveChanges();

                }
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    

        // GET: Schedule/Edit/5
        public ActionResult Edit(int id)
        {
            using (inventorymgtEntities db = new inventorymgtEntities())
            {
                return View(db.schedules.Where(x=>x.ID==id).FirstOrDefault());
            }
                
        }

        // POST: Schedule/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, schedule sc)
        { 
            try
            {
                using (inventorymgtEntities db = new inventorymgtEntities())
                {
                    
                   db.Entry(sc).State = EntityState.Modified;
                    if (sc.Image == null)
                    {
                        var scheduleContext = db.Entry(sc);
                        scheduleContext.State = EntityState.Modified;

                        var clientValues = scheduleContext.CurrentValues.Clone().ToObject();
                        scheduleContext.Reload();
                        scheduleContext.CurrentValues.SetValues(clientValues);

                        var currentValues = scheduleContext.Entity;
                        var databaseValues = (schedule)scheduleContext.OriginalValues.ToObject();

                        scheduleContext.Entity.Image = databaseValues.Image;
                    }
                   db.SaveChanges();
                }
                    // TODO: Add update logic here

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Schedule/Delete/5
        public ActionResult Delete(int id = 0)
        {

            using (inventorymgtEntities mv = new inventorymgtEntities())
            {
                return View(mv.schedules.Where(x => x.ID == id).FirstOrDefault());

            }

        }

        // POST: Schedule/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (inventorymgtEntities mv = new inventorymgtEntities())
                {
                    schedule sc = mv.schedules.Where(x => x.ID == id).FirstOrDefault();
                    mv.schedules.Remove(sc);
                    mv.SaveChanges();


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
