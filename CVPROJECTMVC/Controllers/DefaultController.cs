using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CVPROJECTMVC.Models.Entity;

namespace CVPROJECTMVC.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        DbCvEntities db = new DbCvEntities();
        public ActionResult Index()
        {
            var degerler = db.HakkımdaTbl.ToList();
            return View(degerler);
        }
        public ActionResult Deneyim()
        {
            var deneyimler = db.DeneyimlerTbl.ToList();
            return PartialView(deneyimler);
        }
        public ActionResult Egitim()
        {
            var egitimler = db.EgitimlerTbl.ToList();
            return PartialView(egitimler);
        }
        public ActionResult Yetenek()
        {
            var yetenekler = db.YeteneklerTbl.ToList();
            return PartialView(yetenekler);
        }
        public ActionResult Hobi()
        {
            var hobiler = db.HobilerTbl.ToList();
            return PartialView(hobiler);
        }
        public ActionResult Sertifika()
        {
            var sertifikalar = db.SertifikalarTbl.ToList();
            return PartialView(sertifikalar);
        }
        [HttpGet]
        public ActionResult iletisim()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult iletisim(IletisimTbl t)
        {
            t.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.IletisimTbl.Add(t);
            db.SaveChanges();
            return PartialView();
        }
    }
}