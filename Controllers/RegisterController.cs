using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YeldaSert.DAO;

namespace YeldaSert.Controllers
{
    public class RegisterController : Controller
    {
        TabimEntities db = new TabimEntities();
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        //Register veri Tabanına kayıt yapılıyor.
        public ActionResult Index(User user) {

            user.KullaniciTipi = "Kullanici";
            if (user.Ad!=null)
            {
                db.User.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index", "Login");
            }
            else
            {
                Console.WriteLine("Bu Alanı Doldurunuz");
                return View();
            }
            
        }
    }
}