using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SelcukEgitimPortali.Controllers
{
    public class IstatistikController : Controller
    {
        // GET: Istatistik
        public ActionResult Index()
        {
            Context c = new Context();
            ViewBag.gonderisayisi = c.Blogs.Count();
            ViewBag.yorumsayisi = c.Comments.Count();
            ViewBag.kullanicisayisi = c.Users.Count();
            ViewBag.abonesayisi = c.SubscribeMails.Count();
            ViewBag.iletisimesajisayisi = c.Contacts.Count();
            ViewBag.kategorisayisi = c.Categories.Count();
            return View();
        }
    }
}