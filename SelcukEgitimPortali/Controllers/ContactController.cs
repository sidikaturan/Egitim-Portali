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
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager cm = new ContactManager(new EfContactDal());
        [AllowAnonymous]

        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]

        [HttpGet]
        public ActionResult SendMessage()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]

        public ActionResult SendMessage(Contact p)
        {
            cm.ContactAdd(p);
            return View();
        }
        public ActionResult AdminContactList()
        {
            var contactlist= cm.IletisimMesajiListele();
            ViewBag.v1 = cm.IletisimMesajiListele().Count();
            return View(contactlist);
        }
    }
}