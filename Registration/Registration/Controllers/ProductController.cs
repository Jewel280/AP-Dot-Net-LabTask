using Registration.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Registration.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            var db = new ProCategoryEntities();
            var data = db.Products.ToList();
            return View(data);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product p)
        {
            var db = new ProCategoryEntities();
            db.Products.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var db = new ProCategoryEntities();
            var ex = (from d in db.Products
                      where d.Id == id
                      select d).ToList();
            return View(ex);
        }

        [HttpPost]
        public ActionResult Edit(Category cat)
        {
            var db = new ProCategoryEntities();
            var data = db.Products.Find(cat.Id);
            data.Name = cat.Name;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var db = new ProCategoryEntities();
            var exdata = db.Products.Find(id);
            db.Products.Remove(exdata);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var db = new ProCategoryEntities();
            var pro = db.Products.Find(id);
            return View(pro);
        }
    }
}