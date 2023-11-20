using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ZeroHunger.Database;

namespace Mid.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly ZeroHungerEntities4 db = new ZeroHungerEntities4();
        public ActionResult Index()
        {
            var db = new ZeroHungerEntities4();
            var emp = db.Restaurants.ToList();
            return View(emp);
        }

        public ActionResult Details(string id)
        {
            var db = new ZeroHungerEntities4();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Restaurant restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }

            return View(restaurant);
        }

        public ActionResult Create()
        {
            ViewBag.Food_typeid = new SelectList(db.Foods, "Id", "Type");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Id,storage_time,Food_typeId")] Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                db.Restaurants.Add(restaurant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Food_typeid = new SelectList(db.Foods, "Id", "Type", restaurant.Food_typeId);
            return View(restaurant);
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Restaurant restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            ViewBag.Food_typeid = new SelectList(db.Foods, "Id", "Type", restaurant.Food_typeId);
            return View(restaurant);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Name,Id,storage_time,Food_typeId")] Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restaurant).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Food_typeid = new SelectList(db.Foods, "Id", "Type", restaurant.Food_typeId);
            return View(restaurant);
        }

        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Restaurant restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        // POST: Restaurants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Restaurant restaurant = db.Restaurants.Find(id);
            db.Restaurants.Remove(restaurant);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult FoodStorage(Food f)
        {
            var db = new ZeroHungerEntities4();
            var foods = (from fd in db.Restaurants
                         where fd.Name == "Kfc"
                         select fd).ToList();

            return View(foods);
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