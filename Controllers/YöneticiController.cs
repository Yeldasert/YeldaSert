using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YeldaSert.DAO;
using YeldaSert.Models;

namespace YeldaSert.Controllers
{
    public class YöneticiController : Controller
    {
        TabimEntities db = new TabimEntities();
        // GET: Yönetici
        public ActionResult Index()
        {
            var talepler = db.Evrak.ToList().OrderBy(x => x.evrakTarih);
            return View(talepler);
        }
        public ActionResult SendMail() {
            var user = db.User.FirstOrDefault(x => x.Id == 5);
            var evrak = db.Evrak.FirstOrDefault(x => x.Id == 5);
            Email.Email.SendEposta("Merhaba", user.Ad+ evrak.evrakAd + "Bu olan  Talebiniz Olumlu Cevaplanmıştır", user.Email);
            return RedirectToAction("Index");
        }
        
        public ActionResult Olumlu(int id)
        {
          
                var evrak = db.Evrak.Where(x => x.Id == id).FirstOrDefault();
            var user = db.User.FirstOrDefault(x => x.Id == evrak.userId);
            Email.Email.SendEposta("Merhaba", evrak.evrakAd+"Bu olan  Talebiniz Olumlu Cevaplanmıştır", user.Email);
            evrak.evrakDurum = "Olumlu";
                db.SaveChanges();
                return RedirectToAction("Index","Yönetici");
          
        }
        public ActionResult Olumsuz(int id)
        {
            var evrak = db.Evrak.Where(x => x.Id == id).FirstOrDefault();
            var user = db.User.Where(x => x.Id == evrak.userId).FirstOrDefault();
            Email.Email.SendEposta("Merhaba "+user.Ad, evrak.evrakAd+ "Bu talebiniz Olumsuz sonuçlanmıştır",user.Email);
            evrak.evrakDurum = "Olumsuz";
            db.SaveChanges();
            return RedirectToAction("Index", "Yönetici");

        }
        public ActionResult Details(int id)
        {
            var evrak = db.Evrak.FirstOrDefault(x => x.Id == id);
            return View(evrak);
        }
        public ActionResult CıkısYap()
        {
            return RedirectToAction("Index", "Login");
        }
    }
}