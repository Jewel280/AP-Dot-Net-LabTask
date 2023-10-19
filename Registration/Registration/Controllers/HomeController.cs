using Registration.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;

namespace Registration.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var db = new ProCategoryEntities();
            var data = db.Categories.ToList();
            return View(data);
        }
        [HttpGet]
        
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category cat)
        {
            var db = new ProCategoryEntities();
            db.Categories.Add(cat);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var db = new ProCategoryEntities();
            var ca = (from cat in db.Categories
                      where cat.Id == id
                      select cat).SingleOrDefault();

            return View(ca);
        }

        [HttpPost]
        public ActionResult Edit(Category cat)
        {
            var db = new ProCategoryEntities();
            var catt = db.Categories.Find(cat.Id);
                catt.Name = cat.Name;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var db = new ProCategoryEntities();
            var cat = db.Categories.Find(id);
            return View(cat);
        }

        [HttpGet]

        public ActionResult Delete(int id)
        {
            var db = new ProCategoryEntities();
            var cat = db.Categories.Find(id);
            db.Categories.Remove(cat);
            db.SaveChanges();
            return RedirectToAction("Index");
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
    }
}