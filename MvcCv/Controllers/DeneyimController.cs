using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class DeneyimController : Controller
    {
        // GET: Deneyim
        DeneyimRepository deneyimrepository = new DeneyimRepository();

        public ActionResult Index()
        {
            var degerler = deneyimrepository.List();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult DeneyimEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeneyimEkle(TblDeneyimlerim p)
        {
            deneyimrepository.TAdd(p);
            return RedirectToAction("Index");   
        }

        public ActionResult DeneyimSil(int id)
        {
            TblDeneyimlerim t = deneyimrepository.Find(x=>x.ID  == id);
            deneyimrepository.TDelete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeneyimGetir(int id )
        {
            TblDeneyimlerim t = deneyimrepository.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult DeneyimGetir(TblDeneyimlerim p)
        {
            TblDeneyimlerim t = deneyimrepository.Find(x => x.ID == p.ID);
            t.Baslik = p.Baslik;
            t.AltBaslik = p.AltBaslik;  
            t.Tarih = p.Tarih;
            t.Aciklama = p.Aciklama;    
            deneyimrepository.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}