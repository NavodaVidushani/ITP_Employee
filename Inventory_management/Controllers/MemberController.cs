using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inventory_management.Models;


namespace Inventory_management.Controllers
{

    public class MemberController : Controller
    {
        
        // GET: Member
        public ActionResult Index()
        {
            
            using (inventorymgtEntities dbModel = new inventorymgtEntities())
            {

              //  List<bill> lst = new List<bill>();
               // lst = dbModel.bills.ToList();
                return View(dbModel.members.ToList());
            }

           
        }

        // GET: Member/Details/5
        public ActionResult Details(int id)
        {
            using (inventorymgtEntities dbModel = new inventorymgtEntities())
            {

                return View(dbModel.members.Where(x => x.PaymentId == id).FirstOrDefault());
            }
        }

        // GET: Member/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Member/Create
        [HttpPost]
        public ActionResult Create(member Member)
        {
            try
            {
                // TODO: Add insert logic here
                using (inventorymgtEntities dbmodel = new inventorymgtEntities())
                {
                    dbmodel.members.Add(Member);
                    dbmodel.SaveChanges();

                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Member/Edit/5
        public ActionResult Edit(int id)
        {
            using (inventorymgtEntities dbModel = new inventorymgtEntities())
            {

                return View(dbModel.members.Where(x => x.PaymentId == id).FirstOrDefault());
            }
        }

        // POST: Member/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, member Member)
        {
            try
            {

                using (inventorymgtEntities dbModel = new inventorymgtEntities())
                {

                    dbModel.Entry(Member).State = EntityState.Modified;
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

        // GET: Member/Delete/5
        public ActionResult Delete(int id)
        {
            using (inventorymgtEntities dbModel = new inventorymgtEntities())
            {

                return View(dbModel.members.Where(x => x.PaymentId == id).FirstOrDefault());
            }
        }

        // POST: Member/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (inventorymgtEntities dbModel = new inventorymgtEntities())
                {
                    member Member = dbModel.members.Where(x => x.PaymentId == id).FirstOrDefault();
                    dbModel.members.Remove(Member);
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
