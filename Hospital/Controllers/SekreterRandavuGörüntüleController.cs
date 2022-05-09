using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital.Models.Entity;
using Hospital.Models;

namespace Hospital.Controllers
{
    public class SekreterRandavuGörüntüleController : Controller
    {
        DBHospitalEntities7 db = new DBHospitalEntities7();

        // GET: SekreterRandavuGörüntüle
        public ActionResult Index()
        {
            var Gör = db.SekreterRandavu.ToList();
            return View(Gör);
        }
        public ActionResult RandavuSil(int id)
        {
            var deger = db.SekreterRandavu.Where(x => x.ID == id).SingleOrDefault();
            db.SekreterRandavu.Remove(deger);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}