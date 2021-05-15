using CVPROJECTMVC.Models.Entity;
using CVPROJECTMVC.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CVPROJECTMVC.Controllers
{
    public class EgitimController : Controller
    {
        // GET: Egitim
        EgitimRepository eg = new EgitimRepository();
        [Authorize]
        public ActionResult EgitimListele()
        {
            var degerler = eg.List();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult EgitimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EgitimEkle(EgitimlerTbl p)
        {
            if(!ModelState.IsValid)
            {
                return View("EgitimEkle");
            }
            else 
            { 
            eg.TAdd(p);
            return RedirectToAction("EgitimListele");
            }
        }
        public ActionResult EgitimSil(int id)
        {
            EgitimlerTbl e = eg.TGet(id);
            eg.TDelete(e);
            return RedirectToAction("EgitimListele");
        }
        [HttpGet]
        public ActionResult EgitimGetir(int id)
        {
            EgitimlerTbl e = eg.TGet(id);
            return View(e);
        }
        [HttpPost]
        public ActionResult EgitimGetir(EgitimlerTbl p)
        {
            EgitimlerTbl e = eg.Find(x => x.ID == p.ID);
            e.ID = p.ID;
            e.Title = p.Title;
            e.Subtitle1 = p.Subtitle1;
            e.Subtitle2 = p.Subtitle2;
            e.AGNO = p.AGNO;
            e.Date = p.Date;
            eg.TUpdate(p);
            return RedirectToAction("EgitimListele");
        }

    }
}