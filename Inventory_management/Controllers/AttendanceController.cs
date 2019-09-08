using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inventory_management.Models;

namespace Inventory_management.Controllers
{
    public class AttendanceController : Controller
    {
        // GET: Attendance
        public ActionResult Index()
        {
            using (inventorymgtEntities inventorymgtEntities = new inventorymgtEntities())
            {
                return View(inventorymgtEntities.attendance_emp.ToList());
            }
        }

        // GET: Attendance/Details/5
        public ActionResult Details(int id)
        {
            using (inventorymgtEntities inventorymgtEntities = new inventorymgtEntities())
            {

                return View(inventorymgtEntities.attendance_emp.Where(x => x.empId == id).FirstOrDefault());
            }
        }

        // GET: Attendance/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Attendance/Create
        [HttpPost]
        public ActionResult Create(attendance_emp attendance)
        {
            try
            {

                using (inventorymgtEntities inventorymgtEntities = new inventorymgtEntities())
                {
                    inventorymgtEntities.attendance_emp.Add(attendance);
                    inventorymgtEntities.SaveChanges();
                }
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Attendance/Edit/5
        public ActionResult Edit(int id)
        {
            using (inventorymgtEntities inventorymgtEntities = new inventorymgtEntities())
            {

                return View(inventorymgtEntities.attendance_emp.Where(x => x.empId == id).FirstOrDefault());
            }
        }

        // POST: Attendance/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, attendance_emp attendance)
        {
            try
            {
                using (inventorymgtEntities inventorymgtEntities = new inventorymgtEntities())
                {
                    inventorymgtEntities.Entry(attendance).State = System.Data.Entity.EntityState.Modified;
                    inventorymgtEntities.SaveChanges();
                }
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Attendance/Delete/5
        public ActionResult Delete(int id)
        {
            using (inventorymgtEntities inventorymgtEntities = new inventorymgtEntities())
            {

                return View(inventorymgtEntities.attendance_emp.Where(x => x.empId == id).FirstOrDefault());
            }
        }

        // POST: Attendance/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (inventorymgtEntities inventorymgtEntities = new inventorymgtEntities())
                {
                    attendance_emp attendance1 = inventorymgtEntities.attendance_emp.Where(x => x.empId == id).FirstOrDefault();
                    inventorymgtEntities.attendance_emp.Remove(attendance1);
                    inventorymgtEntities.SaveChanges();
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
