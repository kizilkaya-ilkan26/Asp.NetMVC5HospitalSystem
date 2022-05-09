using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital.Models.Entity;

namespace Hospital.Controllers
{
    public class KayitOlController : Controller
    {
        // GET: KayitOl

        DBHospitalEntities7 HastaKayitEt = new DBHospitalEntities7();

        [HttpGet]
        public ActionResult Kayit()
        {
            Users users = new Users();
            return View(users);
        }
        [HttpPost]
        public ActionResult Kayit(Users p,string name)
        {
            if (!ModelState.IsValid)
            {
                return View(p);
            }
           
            HastaKayitEt.Users.Add(p);
            HastaKayitEt.SaveChanges();

            ViewBag.Message = string.Format("Personel Sisteme Başarılı Bir Şekilde Eklendi. {0}.\\n Eklenme Zamanı: {1}", name, DateTime.Now.ToString());


            return View();
        }
    }
}