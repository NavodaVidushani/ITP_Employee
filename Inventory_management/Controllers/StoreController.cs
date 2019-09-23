using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inventory_management.Models;
//using PagedList;
using System.Data.Entity;

namespace Inventory_management.Controllers
{
    public class StoreController : Controller
    {
        inventorymgtEntities db = new inventorymgtEntities();
        // GET: Store
        public ActionResult Index()
        {
            return View(db.storeproducts.ToList());
        }

        public ActionResult Search()
        {
            return View(db.storeproducts.ToList());
        }

        //public PartialViewResult ProductListPartial(int? page)
        //{
        //    var pagenumber = page ?? 1;
        //    var pageSize = 5;
        //   // var productList = db.storeproducts.OrderByDescending(x => x.productID).ToPagedList(pagenumber, pageSize);
        //    return PartialView(productList);
        //}

        // POST: Inventory/Create
        [HttpPost]
        public ActionResult Create(storeproduct st)
        {
            try
            {
                db.storeproducts.Add(st);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Default/Edit/5
        public ActionResult Edit(int id)
        {
            return View(db.storeproducts.Where(x => x.product_ID == id).FirstOrDefault());
        }

        // POST: Default/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, storeproduct storepro)
        {
            try
            {
                db.Entry(storepro).State = EntityState.Modified;
                db.SaveChanges();
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Default/Delete/5

        public ActionResult Delete(int id)
        {
            return View(db.storeproducts.Where(x => x.product_ID == id).FirstOrDefault());
        }

        // POST: Default/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                storeproduct storepro = db.storeproducts.Where(x => x.product_ID == id).FirstOrDefault();
                db.storeproducts.Remove(storepro);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }


}