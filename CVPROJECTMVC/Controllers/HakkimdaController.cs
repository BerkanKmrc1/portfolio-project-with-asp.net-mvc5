using CVPROJECTMVC.Models.Entity;
using CVPROJECTMVC.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CVPROJECTMVC.Controllers
{
    public class HakkimdaController : Controller
    {
        HakkimdaRepository hk = new HakkimdaRepository();
        [HttpGet]
        public ActionResult HakkimdaListele()
        {
            var hakkimda = hk.List();
            return View(hakkimda);
        }
        [HttpPost]
        public ActionResult HakkimdaListele(HakkımdaTbl p)
        {
            var h = hk.Find(x => x.ID == 1);
            h.Name = p.Name;
            h.Surname = p.Surname;
            h.Görevi = p.Görevi;
            h.Mail = p.Mail;
            h.Phone = p.Phone;
            h.Photo = p.Photo;
            h.Adress = p.Adress;
            hk.TUpdate(h);
            return RedirectToAction("HakkimdaListele");
        }
    }
}