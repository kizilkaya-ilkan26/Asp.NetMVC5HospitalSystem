using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital.Models.Entity;

namespace Hospital.Controllers
{
    public class SekreterAyarlarController : Controller
    {
        DBHospitalEntities7 db = new DBHospitalEntities7();

        // GET: SekreterAyarlar
        public ActionResult Index()
        {
            var adres = Session["ADRES"].ToString();
            var durum = db.Users.Where(x => x.ADRES == adres.ToString()).ToList();
            return View(durum);
        }
        public ActionResult AyarGetir(int id)
        {
            Users kayit = db.Users.Where(t => t.ID == id).SingleOrDefault();

            return View("AyarGetir", kayit);
        }
        public ActionResult AyarDüzenle(Users bilgi, string name)
        {
            Users kayit = db.Users.Where(t => t.ID == bilgi.ID).SingleOrDefault();

            kayit.ID = bilgi.ID;
            kayit.SOYAD = bilgi.SOYAD;
            kayit.ANAHTAR = bilgi.ANAHTAR;
            kayit.ADRES = bilgi.ADRES;
            kayit.TELNO = bilgi.TELNO;
            kayit.Cinsiyet = bilgi.Cinsiyet;
            kayit.Uyruk = bilgi.Uyruk;
            kayit.DiplomaNo = bilgi.DiplomaNo;
            kayit.DiplomaTarihi = bilgi.DiplomaTarihi;
            kayit.DiplomaTescilTarihi = bilgi.DiplomaTescilTarihi;
            kayit.SicilNo = bilgi.SicilNo;
            kayit.ResmiSicilNo = bilgi.ResmiSicilNo;

            db.SaveChanges();

            ViewBag.Message = string.Format("Ayarlar Basarılı bir sekilde kayıt edildi. {0}.\\n Eklenme Zamanı: {1}", name, DateTime.Now.ToString());

            return RedirectToAction("Index");
        }
    }
}
  