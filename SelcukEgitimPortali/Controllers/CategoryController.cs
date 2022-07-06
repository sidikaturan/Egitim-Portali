using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SelcukEgitimPortali.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        public ActionResult Index()
        {
            var categoryvalues = cm.GetList();
            return View(categoryvalues);
        }
        [AllowAnonymous]
        public PartialViewResult BlogDetailsCategoryList()
        {
            var categoryvalues = cm.GetList();
            return PartialView(categoryvalues);
        }
        public ActionResult Kategoriler()
        {
            var deger = cm.GetList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(Category p)
        {
            cm.Add(p);
            return RedirectToAction("Kategoriler");
        }
        [HttpGet]
        public ActionResult KategoriGuncelleme(int id)
        {
            var deger = cm.GetByID(id);
            return View(deger);        
        }
        [HttpPost]
        public ActionResult KategoriGuncelleme(Category p)
        {
            cm.Update(p);
            return RedirectToAction("Kategoriler");
        }
        public ActionResult KategoriSil(int id)
        {
            var deger = cm.GetByID(id);
            cm.Delete(deger);
            return RedirectToAction("Kategoriler");
        }
    }
}