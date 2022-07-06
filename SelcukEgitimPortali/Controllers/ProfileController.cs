using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SelcukEgitimPortali.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        ZiyaretManager zm = new ZiyaretManager(new EfUserDal());
        [AllowAnonymous]
        public ActionResult Index(int id)
        {
            var userlist = zm.GetByID(id);
            return View(userlist);
        }
        [AllowAnonymous]
        public PartialViewResult MeetTheTeam(int id)
        {
            BlogManager bm = new BlogManager(new EfBlogDal());
            ZiyaretManager zm = new ZiyaretManager(new EfUserDal());
            var mail = zm.GetByID(id);
            var userblogs = bm.GetBlogByUser(mail.Mail);
            return PartialView(userblogs);
        }
    }
}