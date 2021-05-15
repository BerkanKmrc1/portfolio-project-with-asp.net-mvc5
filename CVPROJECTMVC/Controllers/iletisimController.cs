using CVPROJECTMVC.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CVPROJECTMVC.Controllers
{
    public class iletisimController : Controller
    {
        // GET: iletisim
        iletisimRepository iltsm = new iletisimRepository();
        public ActionResult MesajListele()
        {
            var mesajlar = iltsm.List();
            return View(mesajlar);
        }
    }
}