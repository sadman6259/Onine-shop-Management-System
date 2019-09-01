using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EcommersShopAdmin;

namespace EcommersShopAdmin.Controllers
{
    public class DetailsProductController : Controller
    {
        private ShopDbEntities db = new ShopDbEntities();

        // GET: /DetailsProduct/
        public ActionResult Index()
        {
            var detailsproducts = db.DetailsProducts.Include(d => d.Category).Include(d => d.LatestProduct).Include(d => d.TopProduct);
            return View(detailsproducts.ToList());
        }

        // GET: /DetailsProduct/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetailsProduct detailsproduct = db.DetailsProducts.Find(id);
            if (detailsproduct == null)
            {
                return HttpNotFound();
            }
            return View(detailsproduct);
        }

        // GET: /DetailsProduct/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "CatId", "CategoryName");
            ViewBag.LatestID = new SelectList(db.LatestProducts, "Id", "ProductName");
            ViewBag.ProductID = new SelectList(db.TopProducts, "Id", "ProductName");
            return View();
        }

        // POST: /DetailsProduct/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="DetailsID,AvailableQuantity,AddedDate,ProductReview,ProductID,CategoryID,LatestID,ImagePath")] DetailsProduct detailsproduct)
        {
            if (ModelState.IsValid)
            {
                db.DetailsProducts.Add(detailsproduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "CatId", "CategoryName", detailsproduct.CategoryID);
            ViewBag.LatestID = new SelectList(db.LatestProducts, "Id", "ProductName", detailsproduct.LatestID);
            ViewBag.ProductID = new SelectList(db.TopProducts, "Id", "ProductName", detailsproduct.ProductID);
            return View(detailsproduct);
        }

        // GET: /DetailsProduct/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetailsProduct detailsproduct = db.DetailsProducts.Find(id);
            if (detailsproduct == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CatId", "CategoryName", detailsproduct.CategoryID);
            ViewBag.LatestID = new SelectList(db.LatestProducts, "Id", "ProductName", detailsproduct.LatestID);
            ViewBag.ProductID = new SelectList(db.TopProducts, "Id", "ProductName", detailsproduct.ProductID);
            return View(detailsproduct);
        }

        // POST: /DetailsProduct/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="DetailsID,AvailableQuantity,AddedDate,ProductReview,ProductID,CategoryID,LatestID,ImagePath")] DetailsProduct detailsproduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detailsproduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CatId", "CategoryName", detailsproduct.CategoryID);
            ViewBag.LatestID = new SelectList(db.LatestProducts, "Id", "ProductName", detailsproduct.LatestID);
            ViewBag.ProductID = new SelectList(db.TopProducts, "Id", "ProductName", detailsproduct.ProductID);
            return View(detailsproduct);
        }

        // GET: /DetailsProduct/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetailsProduct detailsproduct = db.DetailsProducts.Find(id);
            if (detailsproduct == null)
            {
                return HttpNotFound();
            }
            return View(detailsproduct);
        }

        // POST: /DetailsProduct/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetailsProduct detailsproduct = db.DetailsProducts.Find(id);
            db.DetailsProducts.Remove(detailsproduct);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
