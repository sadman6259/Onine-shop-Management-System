using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EcommersShop.Models;

namespace EcommersShop.Controllers
{
    public class LatestProductController : Controller
    {
        private ShopDbEntities7 db = new ShopDbEntities7();

        // GET: /LatestProduct/
        public ActionResult Index(string sortOrder)
        {
            ViewBag.DateSortParm = sortOrder == "Date" ? "Date_desc" : "Date";
            var students = from s in db.LatestProducts
                           select s;
            switch (sortOrder)
            {
                
                case "Date":
                    students = students.OrderBy(s => s.AddedDate);
                    break;
                case "Date_desc":
                    students = students.OrderByDescending(s => s.AddedDate);
                    break;
                default:
                    students = students.OrderByDescending(s => s.AddedDate);
                    break;
            }
            return View(students.ToList());
        }

        // GET: /LatestProduct/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LatestProduct latestproduct = db.LatestProducts.Find(id);
            if (latestproduct == null)
            {
                return HttpNotFound();
            }
            return View(latestproduct);
        }

        // GET: /LatestProduct/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /LatestProduct/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,ProductName,Price,ProductCode,AddedDate")] LatestProduct latestproduct)
        {
            if (ModelState.IsValid)
            {
                db.LatestProducts.Add(latestproduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(latestproduct);
        }

        // GET: /LatestProduct/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LatestProduct latestproduct = db.LatestProducts.Find(id);
            if (latestproduct == null)
            {
                return HttpNotFound();
            }
            return View(latestproduct);
        }

        // POST: /LatestProduct/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,ProductName,Price,ProductCode,AddedDate")] LatestProduct latestproduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(latestproduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(latestproduct);
        }

        // GET: /LatestProduct/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LatestProduct latestproduct = db.LatestProducts.Find(id);
            if (latestproduct == null)
            {
                return HttpNotFound();
            }
            return View(latestproduct);
        }

        // POST: /LatestProduct/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LatestProduct latestproduct = db.LatestProducts.Find(id);
            db.LatestProducts.Remove(latestproduct);
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
