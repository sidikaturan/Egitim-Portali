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
    public class UserController : Controller
    {
        // GET: User
        BlogManager blogmanager = new BlogManager(new EfBlogDal());
        UserManager usermanager = new UserManager();

        [AllowAnonymous]
        public PartialViewResult UserAbout(int id)
        {
            var userdetail = blogmanager.GetBlogByBlog(id);
            return PartialView(userdetail);
        }
        [AllowAnonymous]
        public PartialViewResult UserPopularPost(int id)
        {
            var bloguserid = blogmanager.BlogListele().Where(x => x.BlogID == id).Select(y => y.OlusturanKisi).FirstOrDefault();

            var userblogs = blogmanager.GetBlogByUser(bloguserid);
            return PartialView(userblogs);
        }
        public ActionResult UserList()
        {
          var userlists =  usermanager.GetAll();
            return View(userlists);
        }
      
        [HttpGet]
        public ActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddUser(User p)
        {
            usermanager.AddUserBL(p);
            return RedirectToAction("UserList");
        }
        [HttpGet]
        public ActionResult UserEdit(int id)
        {
            User user = usermanager.FindUser(id);
            return View(user);
        }
        [HttpPost]
        public ActionResult UserEdit(User p)
        {
            usermanager.EditUser(p);
            return RedirectToAction("UserList");
        }
    }
}