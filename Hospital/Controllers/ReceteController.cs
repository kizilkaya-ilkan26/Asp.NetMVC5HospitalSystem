using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital.Models.Entity;
using System.Web.Security;

namespace Hospital.Controllers
{
    public class ReceteController : Controller
    {
        DBHospitalEntities7 db = new DBHospitalEntities7();

        // GET: Recete

        
        public ActionResult Index(string p)
        {
            var ReceteleriGörüntüle = from k in db.RECETE select k;
            if (!string.IsNullOrEmpty(p))
            {
                ReceteleriGörüntüle = ReceteleriGörüntüle.Where(m => m.HASTATC.Contains(p));
            }
            return View(ReceteleriGörüntüle.ToList());
        }


        public ActionResult ReceteleriGetir(int id)
        {
            RECETE kayit = db.RECETE.Where(t => t.ID == id).SingleOrDefault();




            return View("ReceteleriGetir",kayit);
        }

        public ActionResult ReceteDüzenle(RECETE p,string name)
        {
            RECETE kayit = db.RECETE.Where(t => t.ID == p.ID).SingleOrDefault();

            kayit.MAİLADRES = p.MAİLADRES;
            // kayit.DOKTOR = p.DOKTOR;
             kayit.ILAC = p.ILAC;
            // kayit.RECETENO = p.RECETENO;
            kayit.HASTA = p.HASTA;
            kayit.HASTATC = p.HASTATC;
            kayit.TARIH = p.TARIH;

            kayit.tür = p.tür;
            kayit.bankod = p.bankod;
            kayit.etken = p.etken;
            kayit.ödeme = p.ödeme;

            db.SaveChanges();
            ViewBag.Message = string.Format("Recete Düzenleme Basarılı Bir Şekilde Eklendi. {0}.\\n Eklenme Zamanı: {1}", name, DateTime.Now.ToString());

            return RedirectToAction("Index");

        }



        [HttpGet]
        public ActionResult ReceteYaz()
        {
           

            List <SelectListItem> deger3 = (from r in db.Patient.ToList()
                                           select new SelectListItem
                                           {
                                               Text = r.AD +" "+ r.SOYAD,
                                               Value = r.AD.ToString() + r.SOYAD.ToString()

                                           }).ToList();
            ViewBag.dgr3 = deger3;


            List<SelectListItem> deger4 = (from r in db.DEPO.ToList()
                                           select new SelectListItem
                                           {
                                               Text = r.URUNADI,
                                               Value = r.URUNADI.ToString()

                                           }).ToList();
            ViewBag.dgr4 = deger4;



            return View();

        }
        [HttpPost]
        public ActionResult ReceteYaz(RECETE p,string name)
        {

            List<SelectListItem> deger3 = (from r in db.Patient.ToList()
                                           select new SelectListItem
                                           {
                                               Text = r.AD,
                                               Value = r.AD.ToString()

                                           }).ToList();
            ViewBag.dgr3 = deger3;

            List<SelectListItem> deger4 = (from r in db.DEPO.ToList()
                                           select new SelectListItem
                                           {
                                               Text = r.URUNADI,
                                               Value = r.URUNADI.ToString()

                                           }).ToList();
            ViewBag.dgr4 = deger4;



            var adres = Session["ADRES"].ToString();

            Random rnd = new Random();
            var sayi = rnd.Next(1,int.MaxValue);

            p.DOKTOR = adres.ToString();
            

      

            DateTime tarihx = DateTime.Now;

            var tarih = tarihx;

            p.TARIH = Convert.ToDateTime(tarih);

            p.RECETENO = Convert.ToInt32(sayi);

            db.RECETE.Add(p);
            db.SaveChanges();

            ViewBag.Message = string.Format("Recete sisteme Basarılı Bir Şekilde Eklendi. {0}.\\n Eklenme Zamanı: {1}", name, DateTime.Now.ToString());

            return View();

        }
    }
}