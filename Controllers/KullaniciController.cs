using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YeldaSert.DAO;
using YeldaSert.Models;

namespace YeldaSert.Controllers
{
    public class KullaniciController : Controller
    {
        TabimEntities db = new TabimEntities();
        // GET: Kullanici
        public ActionResult Index()
        {
            string kullanicitipi = (Session["kullanicitipi"]).ToString();
            int kullaniciId = Int32.Parse(Session["userId"].ToString());
            if (kullanicitipi == "Kullanici")
            {
                var evraklar = db.Evrak.Where(x => x.userId == kullaniciId).ToList();
                return View(evraklar);
            }
            else
            {
                return RedirectToAction("Index","Login");
            }
            
        }
        public ActionResult TalepOluştur()
        {
            string kullanicitipi = (Session["kullanicitipi"]).ToString();
            if (kullanicitipi == "Kullanici")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
         

        }
        [HttpPost]
        public ActionResult TalepOluştur(Evrak evrak, System.Web.HttpPostedFileBase dosya)
        {
            if (dosya != null)
            {
                int userId = Int32.Parse(Session["userId"].ToString());
                evrak.evrakTarih = DateTime.Now;
                evrak.userId = userId;
                evrak.evrakDurum = "Gönderildi";

                try
                {
                    string dosyaAd = Path.GetFileName(dosya.FileName);
                    var yuklenmeYeri = Path.Combine(Server.MapPath("~/Evraklar"), dosyaAd);
                    string evrakYol = "/Evraklar/" + dosyaAd;

                    dosya.SaveAs(yuklenmeYeri);
                    evrak.evrakYol = dosya.FileName;
                    db.Evrak.Add(evrak);
                    db.SaveChanges();

                }
                catch (Exception)
                {

                    return RedirectToAction("Index", "Kullanici");
                }
            }
            else
            {
                return View();
            }
            return View();
        }
        public ActionResult Takip()
        {
            string kullanicitipi = (Session["KullaniciTipi"]).ToString();
            int userId = Convert.ToInt32(Session["userId"]);
            if (kullanicitipi=="Kullanici")
            {
                var Evrak = (from d in db.Evrak
                                where d.userId == userId
                                select d).ToList();
                ViewBag.Evrak = Evrak;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult Details(int id) {
            var evrak = db.Evrak.FirstOrDefault(x => x.Id == id);
            return View(evrak);
        }
        [HttpPost]
        public  ActionResult Takip(int selectEvrak)
        { 
            
            var rapor = (from r in db.Evrak where r.Id == selectEvrak select r).ToList();
            TempData["rapor"] = rapor;
            return RedirectToAction("Listele", "Kullanici");

        }
        public ActionResult Listele()
        {
            List<Evrak> evraks = (List<Evrak>)TempData["rapor"];
            List<AyrintiliRapor> list = new List<AyrintiliRapor>();
            foreach (var item in evraks)
            {
                AyrintiliRapor ar = new AyrintiliRapor();
                ar.Id = item.Id;
                ar.evrakAd = item.evrakAd;
                ar.tarih = Convert.ToDateTime(item.evrakTarih);
                ar.userId = Convert.ToInt32(item.userId);
                ar.Durum = item.evrakDurum;
                ar.Dosya = item.evrakYol;
                list.Add(ar);
            }
            ViewBag.evraks = list;
            return View();

        }
        public ActionResult CıkısYap()
        {
            return RedirectToAction("Index", "Login");
        }


    }
}