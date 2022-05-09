using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital.Models.Entity;
using Hospital.Models;

namespace Hospital.Controllers
{
    public class AdminSekreterRandavuController : Controller
    {
        // GET: AdminSekreterRandavu
        DBHospitalEntities7 db = new DBHospitalEntities7();

        public ActionResult Index()
        {
            var birim = Session["BÖLÜM"].ToString();
            var Kad = Session["AD"].ToString();
            var Ksoyad = Session["SOYAD"].ToString();       
            var Gör = db.SekreterRandavu.Where(x => x.BÖLÜM == birim.ToString() && x.DOKTOR == (birim+"->"+Kad+ " " +Ksoyad).ToString()).ToList();        
            
            return View(Gör);
        }
        public ActionResult RandavuSil(int id)
        {
            var deger = db.SekreterRandavu.Where(x => x.ID == id).SingleOrDefault();
            db.SekreterRandavu.Remove(deger);
            db.SaveChanges();
            return RedirectToAction("/Index/");
        }
    }
}