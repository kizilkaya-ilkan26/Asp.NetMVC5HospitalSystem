﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Hospital.Models;
using Hospital.Models.Entity;


namespace Hospital.Controllers
{
    public class LabController : Controller
    {
        DBHospitalEntities7 db = new DBHospitalEntities7();

        // GET: Lab
        [Authorize]
       
        public ActionResult Index()
        {
            
            var adres = Session["ADRES"].ToString();
            var adresDateCek = db.Users.Where(x => x.ADRES == adres.ToString()).ToList();

            return View(adresDateCek);
        }
        public ActionResult LogOut(string name)
        {
            FormsAuthentication.SignOut();
            ViewBag.Message = string.Format("Sistemden Başarılı Bir Şekilde Cıkıs Saglandı. {0}.\\n Eklenme Zamanı: {1}", name, DateTime.Now.ToString());
            return RedirectToAction("Index", "Login");
        }


        public ActionResult TestAnasayfa()
        {
    
            
            var adresx = Session["ADRES"].ToString();
            var adresDateCekx = db.Mesaj.Where(x => x.ALICI == adresx.ToString()).ToList();


            return View(adresDateCekx);
        
        }


        public ActionResult TestGetir(int id)
        {
            Mesaj kayit = db.Mesaj.Where(x => x.ID == id).SingleOrDefault();

           

            return View("TestGetir",kayit);
        }



        public ActionResult TestSil(int id)
        {

            Mesaj Delete = db.Mesaj.Where(t => t.ID == id).SingleOrDefault();
            db.Mesaj.Remove(Delete);
            db.SaveChanges();
            return RedirectToAction("Index");
        }




        [HttpPost]
        public ActionResult TestDüzenle(Mesaj p,string name)
        {
            Mesaj kayit = db.Mesaj.Where(t => t.ID == p.ID).SingleOrDefault();

            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
               
                string yol = "~/Views/images/" + dosyaadi;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.Sonuc = "/Views/images/" + dosyaadi ;
            }

            kayit.Sonuc = p.Sonuc;
            p.ISLEM = "Rapor Hazırlandı.";
            kayit.ISLEM = p.ISLEM;
            DateTime tarihx = DateTime.Now;
            p.TARIH = tarihx;
            kayit.Sonuc = p.Sonuc;
            db.Mesaj.Add(p);
            db.SaveChanges();
            ViewBag.Message = string.Format("Sisteme Başarılı Bir Şekilde Düzenlenme Saglandı. {0}.\\n Eklenme Zamanı: {1}", name, DateTime.Now.ToString());

            return RedirectToAction("Index");
        }



        [HttpGet]
        public ActionResult Test()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Test(Mesaj t)
        {
            var adres = Session["ADRES"].ToString();
            t.GÖNDEREN = adres.ToString();
            t.TARIH = DateTime.Parse(DateTime.Now.ToShortDateString());
            t.ISLEM = "Rapor Hazırlandı";
            db.Mesaj.Add(t);
            db.SaveChanges();
            return View();
        }
    }
}