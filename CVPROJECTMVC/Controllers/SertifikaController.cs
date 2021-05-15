using CVPROJECTMVC.Models.Entity;
using CVPROJECTMVC.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CVPROJECTMVC.Controllers
{
    public class SertifikaController : Controller
    {
        SertifikaRepository sf = new SertifikaRepository();
        // GET: Sertifika
        public ActionResult SertifikaListele()
        {
            var degerler = sf.List();
            return View(degerler);
        }
        public ActionResult SertifikaSil(int id)
        {
            SertifikalarTbl s = sf.TGet(id);
            sf.TDelete(s);
            return RedirectToAction("SertifikaListele");
        }
        [HttpGet]
        public ActionResult SertifikaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SertifikaEkle(SertifikalarTbl p)
        {
            sf.TAdd(p);
            return RedirectToAction("SertifikaListele");
        }
        [HttpGet]
        public ActionResult SertifikaGetir(int id)
        {
            var degerler = sf.TGet(id);
            return View(degerler);
        }
        [HttpPost]
        public ActionResult SertifikaGetir(SertifikalarTbl p)
        {
            SertifikalarTbl s = sf.Find(x => x.ID == p.ID);
            s.ID = p.ID;
            s.Description = p.Description;
            s.Tarih = p.Tarih;
            sf.TUpdate(p);
            return RedirectToAction("SertifikaListele");
        }

    }
}