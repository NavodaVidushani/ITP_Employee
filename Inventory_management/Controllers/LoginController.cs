using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inventory_management.Models;
using Inventory_management.Controllers;

namespace Login.Controllers
{
    public class LoginController : Controller
    {


        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Verify(Inventory_management.Models.login userModel)
        {

            using (inventorymgtEntities dbModel = new inventorymgtEntities())
            {
                var pass = userModel.password_;
                var userDetails = dbModel.users.Where(x => x.email == userModel.username).FirstOrDefault();
                if (userDetails == null)
                {
                    userModel.status_ = "Invalid User Credentials.";

                    return View("Login", userModel);

                }

                else
                if (userDetails.email.Equals("akaamzain@hotmail.com") && userDetails.password_.Equals("1202"))
                {

                    return View("~/Views/Search/Index.cshtml");
                }

                else
                {
                    Session["userID"] = userDetails.regId;
                    Session["user"] = userDetails.fname;
                    return View("Welcome");
                }

            }


        }

        public ActionResult LogOut()
        {

            int userId = (int)Session["userID"];
            Session.Abandon();
            return View("Login");


        }


    }
}