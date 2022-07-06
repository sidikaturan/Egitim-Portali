using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SelcukEgitimPortali.Controllers
{
    public class GuestController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogDal());
        public ActionResult Bloglarim(int page = 1)
        {
            string userEmail = (string)Session["ZiyaretciMail"];
            var deger = bm.GetBlogByUser(userEmail).ToPagedList(page, 6);
            return View(deger);
        }
        [HttpGet]
        public ActionResult GonderiOlustur()
        {
            Context c = new Context();
            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.values = values;

            return View();
        }
        [HttpPost]
        public ActionResult GonderiOlustur(Blog p)
        {
            Context c = new Context();
            string userEmail = (string)Session["ZiyaretciMail"];
            p.OlusturanKisi = userEmail;
            p.BlogDate = DateTime.Now;
            p.UserID = c.Users.Where(x=>x.Mail == userEmail).Select(y=>y.UserID).FirstOrDefault();
            bm.Add(p);
            return RedirectToAction("Bloglarim");
        }
        public ActionResult BlogIcerikleri(int id)
        {
            ContentManager cnm = new ContentManager(new EfContentDal());
            var deger = cnm.IcerikByBlog(id);
            ViewBag.v1 = cnm.IcerikByBlog(id).Select(x => x.Blogs.BlogTitle).FirstOrDefault();
            ViewBag.v2 = id;
            return View(deger);
        }
        [HttpGet]
        public ActionResult IcerikEkleme(int id)
        {
            Context c = new Context();
            List<SelectListItem> values = (from x in c.IcerikTipis.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Metin,
                                               Value = x.TipID.ToString()
                                           }).ToList();
            ViewBag.values = values;
            return View();
        }
        [HttpPost]
        public ActionResult IcerikEkleme(int id, Icerik p)
        {
            ContentManager cnm = new ContentManager(new EfContentDal());
            if (p.TipID == 1 || p.TipID == 3)
            {
                p.BlogID = id;
                cnm.ContentAdd(p);
            }
            else
            {
                if (p.IcerikAciklamasi != null)
                {
                    string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                    string yol = "/Gorseller/Gonderi/" + dosyaadi;
                    Request.Files[0].SaveAs(Server.MapPath(yol));
                    p.IcerikAciklamasi = "/Gorseller/Gonderi/" + dosyaadi;
                }
                p.BlogID = id;
                cnm.ContentAdd(p);
            }
            return RedirectToAction("BlogIcerikleri/" + id, "Guest");
        }
        public ActionResult DeleteBlog(int id)
        {
            var deger = bm.GetByID(id);
            bm.Delete(deger);
            return RedirectToAction("Bloglarim");
        }
        [HttpGet]
        public ActionResult UpdateBlog(int id)
        {

            Blog blog = bm.GetByID(id);
            Context c = new Context();
            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.values = values;
            return View(blog);
        }
        [HttpPost]
        public ActionResult UpdateBlog(Blog p)
        {
            Context c = new Context();
            string userEmail = (string)Session["ZiyaretciMail"];
            p.UserID = c.Users.Where(x => x.Mail == userEmail).Select(y => y.UserID).FirstOrDefault();
            bm.Update(p);
            return RedirectToAction("Bloglarim");
        }
        public ActionResult GetCommentByBlog(int id)
        {
            CommentManager cm = new CommentManager(new EfCommentDal());
            var commentlist = cm.CommentByBlog(id).Where(x => x.CommentStatus == true);
            ViewBag.sayi = cm.CommentByBlog(id).Where(x => x.CommentStatus == true).Count();
            return View(commentlist);

        }
        ZiyaretManager usermanager = new ZiyaretManager(new EfUserDal());

        [HttpGet]
        public ActionResult UserEdit()
        {
            string userEmail = (string)Session["ZiyaretciMail"];
            if (userEmail != null)
            {
                var user = usermanager.GetByMailID(userEmail);
                return View(user);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }
        [HttpPost]
        public ActionResult UserEdit(User p)
        {
            if (p.UserImage != null)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string yol = "/Gorseller/Kullanici/" + dosyaadi;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.UserImage = "/Gorseller/Kullanici/" + dosyaadi;
            }
            else
            {
                p.UserImage = null;
            }
            usermanager.ZiyaretciUpdate(p);
            return RedirectToAction("UserEdit");
        }
        public ActionResult GelenKutusu()
        {
            return View();
        }
        [HttpGet]
        public ActionResult IcerikGuncelleme(int id)
        {
            Context c = new Context();
            ContentManager cnm = new ContentManager(new EfContentDal());
            var deger = cnm.GetByID(id);
            List<SelectListItem> values = (from x in c.IcerikTipis.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Metin,
                                               Value = x.TipID.ToString()
                                           }).ToList();
            foreach (var y in values)
            {
                if (y.Value == deger.TipID.ToString())
                {
                    y.Selected = true;
                    break;
                }
            }
            ViewBag.deger = deger.TipID;
            ViewBag.values = values;
            return View(deger);
        }
        [HttpPost]
        public ActionResult IcerikGuncelleme(Icerik p)
        {
            ContentManager cnm = new ContentManager(new EfContentDal());
            if (p.TipID == 1 || p.TipID == 3)
            {
                cnm.ContentUpdate(p);
            }
            else
            {
                if (p.IcerikAciklamasi != null)
                {
                    string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                    string yol = "/Gorseller/Gonderi/" + dosyaadi;
                    Request.Files[0].SaveAs(Server.MapPath(yol));
                    p.IcerikAciklamasi = "/Gorseller/Gonderi/" + dosyaadi;
                }
                else
                {
                    p.IcerikAciklamasi = null;
                }
                cnm.ContentUpdate(p);
            }
            return RedirectToAction("BlogIcerikleri/" + p.BlogID, "Guest");
        }
    }
}