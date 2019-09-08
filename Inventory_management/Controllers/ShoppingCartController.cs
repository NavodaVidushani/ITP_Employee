using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Inventory_management.Models;

namespace Inventory_management.Controllers
{
    public class ShoppingCartController : Controller
    {
        inventorymgtEntities db = new inventorymgtEntities();
        private string strCart = "Cart";

        // GET: ShoppingCart
        public ActionResult Index()
        {
            return View();
        }

        // GET: ShoppingCart/Details/5
        public ActionResult Details(int id)
        {
            return View(db.storeproducts.Where(x => x.product_ID == id).FirstOrDefault());

        }

        public ActionResult OrderNow(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            if (Session[strCart] == null)
            {
                List<Cart> lsCart = new List<Cart>
                {
                    new Cart(db.storeproducts.Find(id),1)
                };
             Session[strCart] = lsCart;
            }
            else
            {
                List<Cart> lsCart = (List<Cart>)Session[strCart];
                int check = isExitingCheck(id);
                if (check == -1)
                    lsCart.Add(new Cart(db.storeproducts.Find(id), 1));
                else  
                    lsCart[check].Quantity++;                 
                Session[strCart] = lsCart;
            }

            return View("Index");
        }  

        private int isExitingCheck(int? id)
        {
            List<Cart> lsCart = (List<Cart>)Session[strCart];
            for (int i = 0; i < lsCart.Count; i++)
            {
                if (lsCart[i].Storeproduct.product_ID == id) return i;
            }
            return -1;
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            int check = isExitingCheck(id);
            List<Cart> lsCart = (List<Cart>)Session[strCart];
            lsCart.RemoveAt(check);
            return View("Index");
        }

        public ActionResult UpdateCart(FormCollection frc)
        {
            string[] quantities = frc.GetValues("quantity");
            List<Cart> lsCart = (List<Cart>)Session[strCart];
            for (int i = 0; i < lsCart.Count; i++)
            {
                lsCart[i].Quantity = Convert.ToInt32(quantities[i]);
            }
            Session[strCart] = lsCart;
            return View("Index");
        }

        public ActionResult CheckOut()
        {            
            return View("CheckOut");
        }

        public ActionResult ProcessOrder(FormCollection frc)
        {
            List<Cart> lsCart = (List<Cart>)Session[strCart];

            order Order = new order()
            {
                customerName = frc["cusName"],
                customerPhone = frc["cusPhone"],
                customerEmail = frc["cusEmail"],
                customerAddress = frc["cusAddress"],
                orderDate = DateTime.Now,
                paymentType = "card",
                status = "processing"
            };
            db.orders.Add(Order);
            db.SaveChanges();

            foreach(Cart cart in lsCart)
            {
                orderdetail OrderDetail = new orderdetail()
                {
                    orderID = Order.orderID,
                    product_ID = cart.Storeproduct.product_ID,
                    quantity = cart.Storeproduct.quantity,
                    price = cart.Storeproduct.price
                };
                db.orderdetails.Add(OrderDetail);
                db.SaveChanges();
            }
            Session.Remove(strCart);
            return View("OrderSuccess");
        }  

    }
}