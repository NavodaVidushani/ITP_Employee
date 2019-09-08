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
    public class ProductController : Controller
    {
        inventorymgtEntities db = new inventorymgtEntities();
        // GET: Product
        public ActionResult Index()
        {
            return View(db.storeproducts.ToList());
        }

        public ActionResult Details(int id)
        {
            return View(db.storeproducts.Where(x => x.product_ID == id).FirstOrDefault());

        }

        public ActionResult Search()
        {
            return View(db.storeproducts.ToList());
        }

        //public PartialViewResult ProductListPartial(int? page)
        //{
        //    var pagenumber = page ?? 1;
        //    var pageSize = 5;
        //   // var productList = db.storeproducts.OrderByDescending(x => x.product_ID).ToPagedList(pagenumber, pageSize);
        //    return PartialView(productList);
        //}

    }
}