using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inventory_management.Models;

namespace Inventory_management.Controllers
{
    public class SalaryController : Controller
    {
        // GET: Salary
        public ActionResult Index()
        {
            salary sal = new salary();
            return View(sal);
        }

        [HttpPost]
        public ActionResult Index(salary s)
        {
            if (s.basic > 30000)
            {
                s.deduction = s.basic * (5.0 / 100);

            }
            else if (s.basic > 15000)
            {
                s.deduction = s.basic * (2.0 / 100);

            }
            else
            {
                s.deduction = 0;

            }
            s.otpay = s.othours * s.otrate;
            s.netsal = s.basic + s.bonus + s.otpay - s.deduction;
            //s.netsal = s.basic + s.bonus +( s.othours* s.otrate) - s.deduction;
            return View(s);
        }


        public ActionResult Details(int id)
        {
            using (inventorymgtEntities employeeModels = new inventorymgtEntities())
            {
                //return View(employeeModels.salaries.ToList());
                return View();
            }
        }

    }

}