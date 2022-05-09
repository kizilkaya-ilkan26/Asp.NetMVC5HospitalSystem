using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital.Models.Entity;
using System.Web.Security;

namespace Hospital.Controllers
{
    public class SekreterRandavuController : Controller
    {
        // GET: SekreterRandavu
        DBHospitalEntities7 db = new DBHospitalEntities7();

        public ActionResult Index()
        {
           return View();
        }
        public ActionResult SekreterRandavuAl(string p)
        {

            var birimlerList = from k in db.SekreterRandavu select k;
            if (!string.IsNullOrEmpty(p))
            {
                birimlerList = birimlerList.Where(m => m.AD.Contains(p));
            }
            return View(birimlerList.ToList());
        }
        public ActionResult RandavuSil(int id)
        {

            SekreterRandavu Delete = db.SekreterRandavu.Where(t => t.ID == id).SingleOrDefault();
            db.SekreterRandavu.Remove(Delete);
            db.SaveChanges();
            return RedirectToAction("/SekreterRandavuAl/");
        }
        public ActionResult RandavuGetir(int id)
        {
            SekreterRandavu kayit = db.SekreterRandavu.Where(t => t.ID == id).SingleOrDefault();

            return View("RandavuGetir", kayit);
        }
        [HttpGet]
        public ActionResult RandavuAl()
        {
            
                List<SelectListItem> deger3 = (from r in db.Users.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = r.BÖLÜM + "->" + r.AD + " " + r.SOYAD,
                                                   Value = (r.BÖLÜM + "->" + r.AD + " " + r.SOYAD).ToString()

                                               }).ToList();
                ViewBag.dgr3 = deger3;
            
            return View();
        }
        [HttpPost]
        public ActionResult RandavuAl(SekreterRandavu t, string name)
        {
      
            db.SekreterRandavu.Add(t);

            db.SaveChanges();
            ViewBag.Message = string.Format("Istem Sisteme Başarılı Bir Şekilde Eklendi. {0}.\\n Eklenme Zamanı: {1}", name, DateTime.Now.ToString());
            return RedirectToAction("/RandavuGetir/");
        }
        [HttpPost]
        public ActionResult RandavuDüzenle(SekreterRandavu p)
        {
            SekreterRandavu kayit = db.SekreterRandavu.Where(t => t.ID == p.ID).SingleOrDefault();
            db.SaveChanges();
            return RedirectToAction("/RandavuAl/");
        }
    }
}