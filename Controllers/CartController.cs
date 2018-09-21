using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EcommersShop.Models;
using EcommersShop.Controllers;


namespace EcommersShop.Controllers
{
    public class CartController : Controller{
   
        private ShopDbEntities7 db = new ShopDbEntities7();

        //
        // GET: /Cart/
        public ActionResult Index()
        {
            if (Session["cart"] == null)
            {
                return View();
            }
            else
            {
                return View("Cart");
            }
        }
   /*     private int isExisting(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].Pr1.Id == id || cart[i].Lr1.Id == id || cart[i].Cr1.CatId == id)
                    return i;
            return -1;
        }*/
        public ActionResult Delete(int id)
        {
         //   int index = isExisting(id);
            List<Item> cart = (List<Item>)Session["cart"];
         //   cart.RemoveAt(index);
            Session["cart"] = cart;
            return View("Cart");

        }
        public ActionResult OrderNow(int id)
        {
            if (Session["cart"] == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item(db.TopProducts.Find(id), 1));
                Session["cart"] = cart;
            }
            else
            {
                List<Item> cart = (List<Item>)Session["cart"];
               // int index = isExisting(id);
             //   if (index == -1)
                   cart.Add(new Item(db.TopProducts.Find(id), 1));
           ///     else
               //     cart[index].Quantity1++;
                Session["cart"] = cart;
            }
            return View("Cart");


        }
        public ActionResult OrderNow1(int id)
        {
            if (Session["cart"] == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item(db.LatestProducts.Find(id), 1));
                Session["cart"] = cart;
            }
            else
            {
                List<Item> cart = (List<Item>)Session["cart"];
             //   int index = isExisting(id);
            //    if (index == -1)
                    cart.Add(new Item(db.LatestProducts.Find(id), 1));
            //    else
                 //    cart[index].Quantity1++;
                     Session["cart"] = cart;
            }
            return View("Cart");


        }
        public ActionResult OrderNow2(int id)
        {
            if (Session["cart"] == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item(db.Categories.Find(id), 1));
                Session["cart"] = cart;
            }
            else
            {
                List<Item> cart = (List<Item>)Session["cart"];
             //   int index = isExisting(id);
             //   if (index == -1)
                    cart.Add(new Item(db.Categories.Find(id), 1));
                //else
                  //  cart[index].Quantity1++;
                Session["cart"] = cart;
            }
            return View("Cart");


        }
	}
}