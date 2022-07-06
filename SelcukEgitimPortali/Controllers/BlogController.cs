using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SelcukEgitimPortali.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog

        BlogManager bm = new BlogManager(new EfBlogDal());
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]

        public PartialViewResult BlogList(int page = 1)
        {
            var bloglist = bm.BlogListele().OrderByDescending(x=>x.BlogID).ToPagedList(page, 6);
            return PartialView(bloglist);
        }
        [AllowAnonymous]

        public PartialViewResult FeaturedPosts()
        {
            //1.Post
            var posttitle1 = bm.BlogListele().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 1).Select(y => y.BlogTitle).FirstOrDefault();
            var postimage1 = bm.BlogListele().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 1).Select(y => y.BlogImage).FirstOrDefault();
            var blogdate1 = bm.BlogListele().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 1).Select(y => y.BlogDate).FirstOrDefault();
            var id1 = bm.BlogListele().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 1).Select(y => y.BlogID).FirstOrDefault();

            ViewBag.posttitle1 = posttitle1;
            ViewBag.postimage1 = postimage1;
            ViewBag.blogdate1 = blogdate1;
            ViewBag.id1 = id1;

            //2.Post
            var posttitle2 = bm.BlogListele().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 2).Select(y => y.BlogTitle).FirstOrDefault();
            var postimage2 = bm.BlogListele().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 2).Select(y => y.BlogImage).FirstOrDefault();
            var blogdate2 = bm.BlogListele().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 2).Select(y => y.BlogDate).FirstOrDefault();
            var id2 = bm.BlogListele().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 2).Select(y => y.BlogID).FirstOrDefault();


            ViewBag.posttitle2 = posttitle2;
            ViewBag.postimage2 = postimage2;
            ViewBag.blogdate2 = blogdate2;
            ViewBag.id2 = id2;
            //3.Post
            var posttitle3 = bm.BlogListele().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 3).Select(y => y.BlogTitle).FirstOrDefault();
            var postimage3 = bm.BlogListele().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 3).Select(y => y.BlogImage).FirstOrDefault();
            var blogdate3 = bm.BlogListele().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 3).Select(y => y.BlogDate).FirstOrDefault();
            var id3 = bm.BlogListele().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 3).Select(y => y.BlogID).FirstOrDefault();


            ViewBag.posttitle3 = posttitle3;
            ViewBag.postimage3 = postimage3;
            ViewBag.blogdate3 = blogdate3;
            ViewBag.id3 = id3;
            //4.Post
            var posttitle4 = bm.BlogListele().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 4).Select(y => y.BlogTitle).FirstOrDefault();
            var postimage4 = bm.BlogListele().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 4).Select(y => y.BlogImage).FirstOrDefault();
            var blogdate4 = bm.BlogListele().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 4).Select(y => y.BlogDate).FirstOrDefault();
            var id4 = bm.BlogListele().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 4).Select(y => y.BlogID).FirstOrDefault();


            ViewBag.posttitle4 = posttitle4;
            ViewBag.postimage4 = postimage4;
            ViewBag.blogdate4 = blogdate4;
            ViewBag.id4 = id4;
            //5.Post
            var posttitle5 = bm.BlogListele().Where(x => x.CategoryID == 1).Select(y => y.BlogTitle).FirstOrDefault();
            var postimage5 = bm.BlogListele().Where(x => x.CategoryID == 1).Select(y => y.BlogImage).FirstOrDefault();
            var blogdate5 = bm.BlogListele().Where(x => x.CategoryID == 1).Select(y => y.BlogDate).FirstOrDefault();
            var id5 = bm.BlogListele().Where(x => x.CategoryID == 1).Select(y => y.BlogID).FirstOrDefault();


            ViewBag.posttitle5 = posttitle5;
            ViewBag.postimage5 = postimage5;
            ViewBag.blogdate5 = blogdate5;
            ViewBag.id5 = id5;
            return PartialView();
        }
        public PartialViewResult OtherFeaturedPost()
        {
            return PartialView();
        }
        [AllowAnonymous]

        public ActionResult BlogDetails()
        {

            return View();
        }
        [AllowAnonymous]
        public PartialViewResult BlogCover(int id)
        {
            var BlogDetailsList = bm.GetBlogByBlog(id);
            return PartialView(BlogDetailsList);
        }
        [AllowAnonymous]
        public PartialViewResult BlogReadAll(int id)
        {
            Class1 cs = new Class1();
            Context c = new Context();
            cs.blog = bm.GetBlogByBlog(id);
            cs.deger2 = c.Iceriks.Where(x => x.BlogID == id).ToList();
            return PartialView(cs);

        }
        [AllowAnonymous]
        public ActionResult BlogByCategory(int id)

        {
            var BlogListByCategory = bm.GetBlogByCategory(id);
            var CategoryName = bm.GetBlogByCategory(id).Select(y => y.Category.CategoryName).FirstOrDefault();
            ViewBag.CategoryName = CategoryName;
            var CategoryDesc = bm.GetBlogByCategory(id).Select(y => y.Category.CategoryDescription).FirstOrDefault();
            ViewBag.CategoryDesc = CategoryDesc;
            return View(BlogListByCategory);
        }
        public ActionResult AdminBlogList(string p,int page = 1)
        {
            //p değeri eğer boş değilse burası
            if (!string.IsNullOrEmpty(p))
            {
                var blogfiltre = bm.BlogFiltrele(p).ToPagedList(page, 10);
                return View(blogfiltre);
            }
            //boşsa burası çalışacak
            else
            {
                var bloglist = bm.BlogListele().ToPagedList(page, 10);
                return View(bloglist);
            }
        }
        [HttpGet]
        public ActionResult AddNewBlog()
        {
            Context c = new Context();
            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.values = values;

            List<SelectListItem> values2 = (from x in c.Users.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.UserName,
                                               Value = x.UserID.ToString()
                                           }).ToList();
            ViewBag.values2 = values2;
            return View();
        }
        [HttpPost]
        public ActionResult AddNewBlog(Blog b)
        {
            bm.Add(b);
            return RedirectToAction("AdminBlogList");
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
        public ActionResult IcerikEkleme(int id,Icerik p)
        {
            ContentManager cnm = new ContentManager(new EfContentDal());
            if(p.TipID == 1 || p.TipID == 3)
            {
                p.BlogID = id;
                cnm.ContentAdd(p);
            }
            else 
            {
                if(p.IcerikAciklamasi != null)
                {
                    string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                    string yol = "/Gorseller/Gonderi/" + dosyaadi;
                    Request.Files[0].SaveAs(Server.MapPath(yol));
                    p.IcerikAciklamasi = "/Gorseller/Gonderi/" + dosyaadi;
                }
                p.BlogID = id;
                cnm.ContentAdd(p);
            }
            return RedirectToAction("BlogIcerikleri/"+id,"Blog");
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
            return RedirectToAction("BlogIcerikleri/" + p.BlogID, "Blog");
        }
        public ActionResult DeleteBlog(int id)
        {
            var deger = bm.GetByID(id);
            bm.Delete(deger);
            return RedirectToAction("AdminBlogList");
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
            bm.Update(p);
            return RedirectToAction("AdminBlogList");
        }
        public ActionResult GetCommentByBlog(int id)
        {
            CommentManager cm = new CommentManager(new EfCommentDal());
            var commentlist =cm.CommentByBlog(id).Where(x=>x.CommentStatus==true);
            ViewBag.sayi= cm.CommentByBlog(id).Where(x => x.CommentStatus == true).Count();
            return View(commentlist);
        }
        public ActionResult YorumSil(int id)
        {
            CommentManager cm = new CommentManager(new EfCommentDal());
            var deger = cm.GetByID(id);
            var blogid = deger.BlogID;
            cm.ChangeCommentStatus(deger);
            return RedirectToAction("GetCommentByBlog/"+blogid);
        }
    }
}