using CVPROJECTMVC.Models.Entity;
using CVPROJECTMVC.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CVPROJECTMVC.Controllers
{
    public class HobiController : Controller
    {
        // GET: Hobi
        HobiRepository hobi = new HobiRepository();
        [HttpGet]
        public ActionResult HobiListele()
        {
            var hobiler = hobi.List();
            return View(hobiler);
        }
        [HttpPost]
        public ActionResult HobiListele(HobilerTbl p)
        {
            var hb = hobi.Find(x => x.ID == 3);
            hb.Description1 = p.Description1;
            hobi.TUpdate(hb);
            return RedirectToAction("HobiListele");
        }

        public ActionResult HobiSil(HobilerTbl p)
        {
            HobilerTbl h = hobi.Find(x => x.ID == p.ID);
            hobi.TDelete(h);
            return RedirectToAction("HobiListele");
        }
    }
}