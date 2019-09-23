using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inventory_management.Models;
using System.Net;
using System.Net.Mail;

namespace Inventory_management.Controllers
{
    public class EmailController : Controller
    {
        // GET: Email
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Inventory_management.Models.Email model)
        {
            MailMessage mesg = new MailMessage("akaamzayn@gmail.com", model.To);
            mesg.Subject = model.Subject;
            mesg.Body = model.Body;
            mesg.IsBodyHtml = false;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;

            NetworkCredential nwc = new NetworkCredential("akaamzayn@gmail.com", "akaam_123");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = nwc;
            smtp.Send(mesg);
            ViewBag.Message = "Mail has been sent Successfully! ";


            return View();
        }
    }
}