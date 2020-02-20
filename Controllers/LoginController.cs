




using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YeldaSert.DAO;

namespace YeldaSert.Controllers
{
    public class LoginController : Controller
    {
        TabimEntities db = new TabimEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string email, string parola)
        {

            var user = (from p in db.User
                        where p.Email == email &&
                        p.Sifre == parola
                        select p).FirstOrDefault();
          

                if (user!=null)
                {
                Session["userId"] = user.Id;
                if (user.KullaniciTipi=="Kullanici")
                {
                    Session["kullanicitipi"] = user.KullaniciTipi;
                    return RedirectToAction("Index", "Kullanici");
                }
                if (user.KullaniciTipi=="Yönetici")
                {
                    return RedirectToAction("Index","Yönetici");
                }
                return View();
            }
            else
            {
                return View();
            }
        }
       

    }
}