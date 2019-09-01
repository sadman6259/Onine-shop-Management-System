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
    public class TopProductController : Controller
    {
        private ShopDbEntities db = new ShopDbEntities();

        // GET: /TopProduct/
        public ActionResult Index()
        {
            return View(db.TopProducts.ToList());
        }

        // GET: /TopProduct/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TopProduct topproduct = db.TopProducts.Find(id);
            if (topproduct == null)
            {
                return HttpNotFound();
            }
            return View(topproduct);
        }

        // GET: /TopProduct/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /TopProduct/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,ProductName,Price,ProductCode,AddedDate,AvailableQuantity,ProductReview,ImagePath")] TopProduct topproduct)
        {
            if (ModelState.IsValid)
            {
                db.TopProducts.Add(topproduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(topproduct);
        }

        // GET: /TopProduct/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TopProduct topproduct = db.TopProducts.Find(id);
            if (topproduct == null)
            {
                return HttpNotFound();
            }
            return View(topproduct);
        }

        // POST: /TopProduct/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,ProductName,Price,ProductCode,AddedDate,AvailableQuantity,ProductReview,ImagePath")] TopProduct topproduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(topproduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(topproduct);
        }

        // GET: /TopProduct/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TopProduct topproduct = db.TopProducts.Find(id);
            if (topproduct == null)
            {
                return HttpNotFound();
            }
            return View(topproduct);
        }

        // POST: /TopProduct/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TopProduct topproduct = db.TopProducts.Find(id);
            db.TopProducts.Remove(topproduct);
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
