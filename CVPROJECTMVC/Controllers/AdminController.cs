using CVPROJECTMVC.Repositories;
using CVPROJECTMVC.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CVPROJECTMVC.Controllers
{
    public class AdminController : Controller
    {
        GenericRepository<AdminTbl> admin = new GenericRepository<AdminTbl>();
       
        public ActionResult AdminListele()
        {
            var liste = admin.List();
            return View(liste);
        }
        [HttpGet]
        public ActionResult AdminEkle()
        {
            return RedirectToAction("AdminListele");
        }
        [HttpPost]
        public ActionResult AdminEkle(AdminTbl p)
        {
            admin.TAdd(p);
            return RedirectToAction("AdminListele");
        }
        public ActionResult AdminSil(int id)
        {
           
            admin.TDelete(admin.TGet(id));
            return RedirectToAction("AdminListele");
        }
        [HttpGet]
        public ActionResult AdminGetir(int id)
        {
            AdminTbl t = admin.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult AdminGetir(AdminTbl p)
        {
            AdminTbl deger = admin.Find(x => x.ID == p.ID);
            deger.ID = p.ID;                    
            deger.KullaniciAdi = p.KullaniciAdi;
            deger.KullaniciAdi = p.KullaniciAdi;
            admin.TUpdate(deger);
            return RedirectToAction("AdminListele");
        }
    }
}