using Registration.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Registration.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            var db = new ProCategoryEntities();
            var data = db.Categories.ToList();
            return View(data);
        }
        public ActionResult Details(int id)
        {
            var db = new ProCategoryEntities();
            var cate = db.Categories.Find(id);
            return View(cate);
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
            var ex = (from d in db.Categories
                      where d.Id == id
                      select d).ToList();
            return View(ex);
        }

        [HttpPost]
        public ActionResult Edit(Category cat)
        {
            var db = new ProCategoryEntities();
            var exdata = db.Categories.Find(cat.Id);
            exdata.Name = cat.Name;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var db = new ProCategoryEntities();
            var exdata = db.Categories.Find(id);
            db.Categories.Remove(exdata);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}