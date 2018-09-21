using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using EcommersShop.Models;

namespace EcommersShop.Controllers
{    
    public class HomeController : Controller
    {
        private ShopDbEntities7 db = new ShopDbEntities7();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult Order()
        {

            if (Session["cart"] == null)
            {
                return View("BlankOrder");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Order(Order order)
        {

            using (ShopDbEntities7 entities = new ShopDbEntities7())
            {
                entities.Orders.Add(order);
                entities.SaveChanges();
                int id = order.Id;
            }
            return View("Succss");
        }
    }
}