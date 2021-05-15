using CVPROJECTMVC.Models.Entity;
using CVPROJECTMVC.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CVPROJECTMVC.Controllers
{
    public class DeneyimController : Controller
    {
        // GET: Deneyim
        DeneyimRepository repo = new DeneyimRepository();

        public ActionResult DeneyimListele()
        {
            var degerler = repo.List();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult DeneyimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DeneyimEkle(DeneyimlerTbl p)
        {
            repo.TAdd(p);
            return RedirectToAction("DeneyimListele");
        }
        public ActionResult DeneyimSilme(int id)
        {
            DeneyimlerTbl t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("DeneyimListele");
        }
        [HttpGet]
        public ActionResult DeneyimGetir(int id)
        {
            DeneyimlerTbl t = repo.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult DeneyimGetir(DeneyimlerTbl p)
        {
            DeneyimlerTbl t = repo.Find(x => x.ID == p.ID);
            t.Title = p.Title;
            t.Subtitle = p.Subtitle;
            t.Date = p.Date;
            t.Description = p.Description;
            repo.TUpdate(t);
            return RedirectToAction("DeneyimListele");
        }

    }
}