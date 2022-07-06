using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SelcukEgitimPortali.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        IZiyaretciService authService = new ZiyaretciManager(new ZiyaretManager(new EfUserDal()));
        public ActionResult Login()
        {   
                return View();          
        }
        [HttpPost]
        public ActionResult Login(ZiyaretciLoginDto writerLoginDto, string ReturnUrl)
        {
            if (writerLoginDto.ZiyaretciAdi != null && writerLoginDto.ZiyaretciPassword != null)
            {
                if (authService.ZiyaretciLogin(writerLoginDto))
                {
                    FormsAuthentication.SetAuthCookie(writerLoginDto.ZiyaretciAdi, false);
                    Session["ZiyaretciMail"] = writerLoginDto.ZiyaretciAdi;

                    if (!string.IsNullOrEmpty(ReturnUrl))
                        return Redirect(ReturnUrl);
                    else
                    {
                        string userEmail2 = (string)Session["ZiyaretciMail"];
                        if (userEmail2 == "sidika@gmail.com")
                            return RedirectToAction("AdminBlogList", "Blog");
                        else
                            return RedirectToAction("Bloglarim", "Guest");
                    }
                }
                else
                {
                    ViewData["ErrorMessage"] = "Kullanıcı adı veya Parola yanlış";
                    return RedirectToAction("Login", "Login");
                }
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login", "Login");
        }
        [HttpGet]
        public ActionResult Kayit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Kayit(ZiyaretciLoginDto writerLoginDto)
        {
            if (authService.ZiyaretciKayitKontrol(writerLoginDto))
            {
                ViewData["ErrorMessage"] = "Kullanıcı adı veya Parola yanlış";
                return RedirectToAction("AdminBlogList", "Blog");
            }
            else
            {
                authService.ZiyaretciKayit(writerLoginDto.ZiyaretciAdi, writerLoginDto.ZiyaretciPassword);
                return RedirectToAction("Login", "Login");
            }
        }
    }
}