using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inventory_management.Models;

namespace Inventory_management.Controllers
{
    public class EmployeeController : Controller
    {
     
  

        // GET: Employee
        public ActionResult Index()
        {
            using (inventorymgtEntities employeeModels = new inventorymgtEntities())
            {
                return View(employeeModels.employees.ToList());
            }
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            using (inventorymgtEntities employeeModels = new inventorymgtEntities())
            {

                return View(employeeModels.employees.Where(x => x.empId == id).FirstOrDefault());
            }
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(employee employee)
        {
            try
            {

                using (inventorymgtEntities empModel = new inventorymgtEntities())
                {
                    empModel.employees.Add(employee);
                    empModel.SaveChanges();
                }
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            using (inventorymgtEntities empModel = new inventorymgtEntities())
            {

                return View(empModel.employees.Where(x => x.empId == id).FirstOrDefault());
            }
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, employee employee)
        {
            try
            {
                using (inventorymgtEntities empModel = new inventorymgtEntities())
                {
                    empModel.Entry(employee).State = System.Data.Entity.EntityState.Modified;
                    empModel.SaveChanges();
                }
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            using (inventorymgtEntities empModel = new inventorymgtEntities())
            {

                return View(empModel.employees.Where(x => x.empId == id).FirstOrDefault());
            }
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (inventorymgtEntities empModel = new inventorymgtEntities())
                {
                    employee employee1 = empModel.employees.Where(x => x.empId == id).FirstOrDefault();
                    empModel.employees.Remove(employee1);
                    empModel.SaveChanges();
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
