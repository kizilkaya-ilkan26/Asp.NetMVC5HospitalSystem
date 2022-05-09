using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital.Models.Entity;
using Hospital.Models;

namespace Hospital.Controllers
{
    public class HastaKayitController : Controller
    {
        DBHospitalEntities7 db = new DBHospitalEntities7();
        // GET: HastaKayit

        [HttpGet]
        public ActionResult Kayit()
        {
            Patient hastalar = new Patient();
            return View(hastalar);
        }

        [HttpPost]
        public ActionResult Kayit(Patient p,string name)
        {
            if (!ModelState.IsValid)
            {
                return View(p);
            }
            p.YETKİ = (0).ToString();
            p.KayitlanmaTarihi = DateTime.Now;
            db.Patient.Add(p);
            db.SaveChanges();
            ViewBag.Message = string.Format("Hasta Kayıt Sisteme Başarılı Bir Şekilde Eklendi. {0}.\\n Eklenme Zamanı: {1}", name, DateTime.Now.ToString());
            return View(p);
        }
    }
}