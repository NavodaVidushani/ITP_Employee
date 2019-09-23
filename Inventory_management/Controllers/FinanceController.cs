using Inventory_management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventory_management.Controllers
{
    public class FinanceController : Controller
    {

        DBModel db = new DBModel();

        // GET: Finance
        [HttpGet]
        public ActionResult income()
        {
            return View(db.incomeData());
        }

        [HttpGet]
        public ActionResult daily()
        {
            return View(db.dailyData());
        }

       [HttpPost]
        public ActionResult InsertData(String date, String category, String cash, String pos, String amount)
        {

            if (date != "" && category != "" && cash != "" && pos != "" && amount != "")
            {
                income income = new income();

                income.date = date;
                income.category = category;
                income.cash = Double.Parse(cash);
                income.pos = Double.Parse(pos);
                income.total = Double.Parse(amount);

                db.incomeInsert(income);

                return Json("success", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("error", JsonRequestBehavior.AllowGet);
            }

        }

       [HttpPost]
        public ActionResult editIncome(String id,String date, String category, String cash, String pos, String amount)
        {

            if (id != "" && date != "" && category != "" && cash != "" && pos != "" && amount != "")
            {
                income income = new income();

                income.id = int.Parse(id);
                income.date = date;
                income.category = category;
                income.cash = Double.Parse(cash);
                income.pos = Double.Parse(pos);
                income.total = Double.Parse(amount);

                db.incomeEdit(income);

                return Json("success", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("error", JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        public ActionResult incomeDelete(String id)
        {

            if (id != "")
            {
                income income = new income();

                income.id = int.Parse(id);

                db.deleteIncome(income);

                return Json("success", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("error", JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        public ActionResult InsertDailyData(String date, String savings, String category, String amount)
        {

            if (date != "" && category != "" && savings != "" && amount != "")
            {
                daily daily = new daily();

                daily.date = date;
                daily.category = category;
                daily.savings = Double.Parse(savings);
                daily.amount = Double.Parse(amount);

                db.dailyInsert(daily);

                Session["success"] = 1;

                return Json("success", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("error", JsonRequestBehavior.AllowGet);
            }

        }

       [HttpPost]
        public ActionResult editDaily(String id, String date, String category, String savings, String amount)
        {

            if (id != "" && date != "" && category != "" && savings != "" && amount != "")
            {
                daily daily = new daily();

                daily.id = int.Parse(id);
                daily.date = date;
                daily.category = category;
                daily.savings = Double.Parse(savings);
                daily.amount = Double.Parse(amount);

                db.editDaily(daily);

                Session["success"] = 2;

                return Json("success", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("error", JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        public ActionResult dailyDelete(String id)
        {

            if (id != "")
            {
                daily daily = new daily();

                daily.id = int.Parse(id);

                db.deleteDaily(daily);

                Session["success"] = 3;

                return Json("success", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("error", JsonRequestBehavior.AllowGet);
            }

        }

    }

}