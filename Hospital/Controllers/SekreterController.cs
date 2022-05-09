using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital.Models.Entity;
using Hospital.Models;
using System.Web.Security;

namespace Hospital.Controllers
{
    public class SekreterController : Controller
    {
        // GET: Sekreter
       DBHospitalEntities7 db = new DBHospitalEntities7();

        [Authorize]
        public ActionResult Index()
        {
            var adres = Session["ADRES"].ToString();
            var adresBilgiGetir = db.Users.Where(x => x.ADRES == adres.ToString()).ToList();

            return View(adresBilgiGetir);
        }
        public ActionResult LogOut(string name)
        {
            FormsAuthentication.SignOut();
            ViewBag.Message = string.Format(" Sisteme Başarılı Bir Şekilde Cıkıs Yapıldı. {0}.\\n Eklenme Zamanı: {1}", name, DateTime.Now.ToString());
            return RedirectToAction("Index", "Login");
        }

    }
}