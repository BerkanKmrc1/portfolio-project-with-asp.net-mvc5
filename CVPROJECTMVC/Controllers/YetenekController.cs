using CVPROJECTMVC.Models.Entity;
using CVPROJECTMVC.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CVPROJECTMVC.Controllers
{
    public class YetenekController : Controller
    {
        // GET: Yetenek
        YetenekRepository repo = new YetenekRepository();
        public ActionResult YetenekListele()
        {
            var degerler=repo.List();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YetenekEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YetenekEkle(YeteneklerTbl p)
        {
            repo.TAdd(p);
            return RedirectToAction("YetenekListele");
        }
        public ActionResult YetenekSil(int id)
        {
            YeteneklerTbl y = repo.Find(x => x.ID == id);
            repo.TDelete(y);
            return RedirectToAction("YetenekListele");
        }
        [HttpGet]
        public ActionResult YetenekGetir(int id)
        {
            return View(repo.TGet(id));            
        }
        [HttpPost]
        public ActionResult YetenekGetir(YeteneklerTbl p)
        {

           YeteneklerTbl y = repo.Find(x => x.ID == p.ID);
           y.Workflow = p.Workflow;
           y.Oran = p.Oran;
           repo.TUpdate(y);
           return RedirectToAction("YetenekListele");
       }
    }
}