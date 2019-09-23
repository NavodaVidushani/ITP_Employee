using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inventory_management.Models;
using System.Data.Entity;
using System.IO;

namespace Inventory_management.Controllers
{
    public class proifleController : Controller
    {
        // GET: proifle
        public ActionResult Index()
        {
            return View();
        }

        // GET: proifle/Details/5
        public ActionResult Details(int id)
        {

            using (inventorymgtEntities dbModel = new inventorymgtEntities())
            {
                var atndDetails = dbModel.attendances.Where(x => x.user_ == id).FirstOrDefault();

                if (atndDetails == null)
                {
                    attendance atdMdodel = new attendance();
                    atdMdodel.user_ = id;
                    atdMdodel.status_ = "false";
                    atdMdodel.no_of_days = 0;
                    atdMdodel.date_ =DateTime.Now.Date.ToString();

                    dbModel.attendances.Add(atdMdodel);
                    dbModel.SaveChanges();
                }

                return View(dbModel.users.Where(x => x.regId == id).FirstOrDefault());
            }
                
        }

        [HttpPost]
        public ActionResult Details(user user)
        {
            try
            {
                using (inventorymgtEntities dbModel = new inventorymgtEntities())
                {

                    string filename = user.fname.ToLower() + "_" + user.lname.ToLower();
                    string extension = Path.GetExtension(user.ImageFile.FileName);
                    filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                    user.img_path = "~/image/" + filename;
                    filename = Path.Combine(Server.MapPath("~/image/"), filename);
                    user.ImageFile.SaveAs(filename);

                    dbModel.Entry(user).State = EntityState.Modified;
                    dbModel.SaveChanges();
                }

                return RedirectToAction("Details", new { id = user.regId });
            }
            catch (Exception e)
            {
                Response.Write(e.StackTrace.ToString());
                return RedirectToAction("Details", new { id = user.regId });
            }

        }

        public ActionResult ChangePassword(user user)
        {
            using(inventorymgtEntities dbModel = new inventorymgtEntities())
            {
                try
                {
                    dbModel.Entry(user).State = EntityState.Modified;
                    dbModel.SaveChanges();
                    return RedirectToAction("../Login/Login");
                }
                catch(Exception e)
                {
                    Response.Write(e.StackTrace.ToString());
                    return RedirectToAction("Details", new { id = user.regId });
                }
            }
           
        }


        // GET: proifle/Edit/5
        public ActionResult Edit(int id)
        {
            using (inventorymgtEntities dbModel = new inventorymgtEntities())
            {
                return View(dbModel.users.Where(x => x.regId == id).FirstOrDefault());
            }
        }

        // POST: proifle/Edit/5
        [HttpPost]
        public ActionResult Edit(user user)
        {

            // TODO: Add update logic here
            try
            {
                using (inventorymgtEntities dbModel = new inventorymgtEntities())
                {

                    dbModel.Entry(user).State = EntityState.Modified;
                    dbModel.SaveChanges();
                }

                return RedirectToAction("Details", new {id = user.regId});
            }
            catch
            {
                return View();
            }

        }

        public ActionResult Attendance(int id) {

            using( inventorymgtEntities dbModel = new inventorymgtEntities())
            {
                var userDetails = dbModel.users.Where(x => x.regId == id).FirstOrDefault();
                var atndDetails = dbModel.attendances.Where(x => x.user_ == id).FirstOrDefault();

                //if (DateTime.Now.Date > atndDetails.date_)

                DateTime dt = DateTime.Parse(atndDetails.date_);
                    if (DateTime.Now.Date.CompareTo(dt)>0) {

                    atndDetails.status_ = "false";

                    dbModel.Entry(atndDetails).State = EntityState.Modified;
                    dbModel.SaveChanges();
                }

                int cdays = (int)atndDetails.no_of_days;

                Session["username"] = userDetails.fname+" "+userDetails.lname;
                Session["userId"] = userDetails.regId;
                Session["progress"] = (100 / 45) * cdays;
                Session["rDays"] = 45 - cdays;

                return View(dbModel.attendances.Where(x => x.user_ == id).FirstOrDefault());
            }
            

        }

        [HttpPost]
        public ActionResult Attendance(attendance atd)
        {
            try
            {
                int rdays = 45, cdays=0;


                using ( inventorymgtEntities dbModel = new inventorymgtEntities())
                {
                    cdays = (int)atd.no_of_days + 1;
                    if (cdays <= 45)
                    {
                        atd.status_ = "true";
                        atd.date_ = DateTime.Now.Date.ToString();
                        atd.no_of_days = cdays;
                    }else
                    {
                        atd.no_of_days = 1;
                        cdays = 1;
                    }
                    atd.user_ = (int)Session["userId"];
                    dbModel.Entry(atd).State = EntityState.Modified;
                    dbModel.SaveChanges();

                    rdays = rdays - cdays;
                }

                Session["progress"] = (100/45)*cdays;
                Session["rDays"] = rdays;

                return View(atd);
            }
            catch(Exception e)
            {
               Response.Write("Error, "+ e.StackTrace.ToString());

            }

            return View(atd);

        }




        // GET: proifle/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: proifle/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
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
