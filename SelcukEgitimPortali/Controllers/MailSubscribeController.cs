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
    public class MailSubscribeController : Controller
    {           
        SubscribeMailManager sm = new SubscribeMailManager(new EfSubscribeDal());
        [AllowAnonymous]

        [HttpGet]
        public ActionResult AddMail()
        {
            return PartialView();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult AddMail(SubscribeMail p)
        {
            sm.Add(p);
            return PartialView();
        }
        public ActionResult AdminSubscribeList()
        {
            var subslist = sm.GetList();
            ViewBag.v2 = sm.GetList().Count();
            return View(subslist);
        }
        public ActionResult DeleteSub(int id)
        {
            var deger = sm.GetByID(id);
            sm.Delete(deger);
            return RedirectToAction("AdminSubscribeList");

        }
    }
}