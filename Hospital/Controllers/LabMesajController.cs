using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital.Models;
using Hospital.Models.Entity;

namespace Hospital.Controllers
{
    public class LabMesajController : Controller
    {
        // GET: LabMesaj
        DBHospitalEntities7 db = new DBHospitalEntities7();

        // GET: DoktorMesajYolla
        public ActionResult Index()
        {
            var adres = Session["ADRES"].ToString();
            var mesajlar = db.Mesaj.Where(x => x.ALICI == adres.ToString()).ToList();

            return View(mesajlar);
        }
        public ActionResult LabMesaj()
        {
            var adres = Session["ADRES"].ToString();
            var mesajlar = db.Mesaj.Where(x => x.ALICI == adres.ToString()).ToList();

            return View(mesajlar);
        }
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMesaj(Mesaj t, string name)
        {

            var adres = Session["ADRES"].ToString();
            t.GÖNDEREN = adres.ToString();
            t.TARIH = DateTime.Parse(DateTime.Now.ToShortDateString());
            t.ISLEM = "İşlem Beklemede";
            t.Sonuc = "Lab Mesaj Yolladı";
            db.Mesaj.Add(t);
            db.SaveChanges();
            ViewBag.Message = string.Format("Istem Sisteme Başarılı Bir Şekilde Eklendi. {0}.\\n Eklenme Zamanı: {1}", name, DateTime.Now.ToString());

            return View();
        }

        public ActionResult MesajSil(int id)
        {

            Mesaj Delete = db.Mesaj.Where(t => t.ID == id).SingleOrDefault();
            db.Mesaj.Remove(Delete);
            db.SaveChanges();
            return RedirectToAction("/labMesaj/");
        }
        public ActionResult MesajGetir(int id)
        {
            Mesaj kayit = db.Mesaj.Where(t => t.ID == id).SingleOrDefault();

            return View("MesajGetir", kayit);
        }

        [HttpPost]
        public ActionResult MesajDüzenle(Mesaj p)
        {
            Mesaj kayit = db.Mesaj.Where(t => t.ID == p.ID).SingleOrDefault();
            kayit.ISLEM = "Lab Mesaj Yolladı";
            kayit.MESAJ1 = p.MESAJ1;
            db.SaveChanges();
            return RedirectToAction("/LabMesaj/");
        }
    }
}