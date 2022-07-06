using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SelcukEgitimPortali.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        AboutManager abm = new AboutManager(new EfAboutDal());
        [AllowAnonymous]

        public ActionResult Index()
        {
            var aboutcontent = abm.GetList();
            return View(aboutcontent);
        }
        [AllowAnonymous]

        public PartialViewResult Footer()
        {
            var aboutcontentlist = abm.GetList();
            return PartialView(aboutcontentlist);
        }
      
        [HttpGet]
        public ActionResult EditAbout()
        {
            var deger = abm.GetByID(1);
            return View(deger);
        }
        [HttpPost]
        public ActionResult EditAbout(About p)
        {
            abm.Update(p);
            return RedirectToAction("EditAbout");
        }
    }
}