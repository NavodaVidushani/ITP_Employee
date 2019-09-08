using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inventory_management.Models;
using System.IO;

namespace Inventory_management.Controllers
{
    public class OrderController : Controller
    {
        inventorymgtEntities db = new inventorymgtEntities();
        // GET: Order
        public ActionResult Index()
        {
            return View(db.orders.ToList());
        }

        // GET: Order/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var order1 = db.orders.Find(id);
            if(order1 == null)
            {
                return HttpNotFound();
            }
            return View(order1);
        }

        public ActionResult ExportOrderListing()
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Report/Order/OrderReport.rpt")));
            rd.SetDataSource(db.orders.ToList());          

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();

            Stream str = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            str.Seek(0, SeekOrigin.Begin);

            string savedFileName = string.Format("OrderReport_{0}", DateTime.Now);
            return File(str,"application/pdf", savedFileName);
        }
    }
}
