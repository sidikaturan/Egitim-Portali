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
    public class CommentController : Controller
    {

        // GET: Comment
        CommentManager cm = new CommentManager(new EfCommentDal());

        [AllowAnonymous]
        public PartialViewResult CommentList(int id)
        {
            var commentlist = cm.CommentByBlog(id).Where(x => x.CommentStatus == true);
            return PartialView(commentlist);
        }
        [AllowAnonymous]

        [HttpGet]
        public PartialViewResult LeaveComment(int id)
        {
            ViewBag.id = id;
            return PartialView();
        }

        [AllowAnonymous]
        [HttpPost]
        public PartialViewResult LeaveComment(Comment c)
        {
            cm.CommentAdd(c);
            return PartialView();
        }
        public ActionResult AdminCommentList(string p, int page = 1)
        {

            //p değeri eğer boş değilse burası
            if (!string.IsNullOrEmpty(p))
            {
                var commentfiltrele = cm.YorumFiltrele(p).ToPagedList(page, 10);
                return View(commentfiltrele);
            }
            //boşsa burası çalışacak
            else
            {
                var commentlist = cm.CommentList().ToPagedList(page, 10);
                return View(commentlist);
            }
        }
        public ActionResult DeleteComment(int id)
        {
            var deger = cm.GetByID(id);
            cm.ChangeCommentStatus(deger);
            return RedirectToAction("AdminCommentList");
        }

    }
}