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
    public class MessageController : Controller
    {
        // GET: Message
        MessageManager ms = new MessageManager(new EfMessageDal());
        public ActionResult Inbox()
        {
            string userEmail = (string)Session["ZiyaretciMail"];
            var deger = ms.GetListInbox(userEmail).Where(x => x.MessageStatus == true).OrderByDescending(x=>x.MessageID);
            return View(deger);
        }
        public ActionResult SendBox()
        {
            string userEmail = (string)Session["ZiyaretciMail"];
            var deger = ms.GetSendInbox(userEmail).Where(x => x.MessageStatus == true).OrderByDescending(x => x.MessageID);
            return View(deger);
        }
        public ActionResult MessageDetails(int id)
        {
            var deger = ms.GetByID(id);
            ms.MessageOkundu(deger);
            return View(deger);
        }
        public ActionResult MessageDetailsGonderilenler(int id)
        {
            var deger = ms.GetByID(id);
            return View(deger);
        }

        public ActionResult DeleteMessage(int id)
        {
            var deger = ms.GetByID(id);
            ms.MessageDelete(deger);
            return RedirectToAction("TrashBox");
        }

        [HttpGet]
        public ActionResult NewMessage(int? id)
        {
            string userEmail = (string)Session["ZiyaretciMail"];
            if (userEmail != null)
            {
                if (id != null)
                {
                    ZiyaretManager zm = new ZiyaretManager(new EfUserDal());
                    var yazar = zm.GetByID((int)id);
                    ViewBag.mail = yazar.Mail;
                    return View();
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }
        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            string userEmail = (string)Session["ZiyaretciMail"];
            p.SenderMail = userEmail;
            p.MessageDate = DateTime.Now;
            p.MessageStatus = true;
            ms.MessageAdd(p);
            return RedirectToAction("SendBox");
        }
        public ActionResult TrashBox()
        {
            string userEmail = (string)Session["ZiyaretciMail"];
            var deger = ms.GetListAll(userEmail).Where(x => x.MessageStatus == false).OrderByDescending(x => x.MessageID);
            return View(deger);
        }
        public ActionResult CopeTasi(int id)
        {
            var deger = ms.GetByID(id);
            ms.MessageSilindi(deger);
            return RedirectToAction("Inbox");

        }
    }
}