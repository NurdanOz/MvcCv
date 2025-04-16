using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class iletisimController : Controller
    {
        // GET: iletisim
        GenericRepository<TBLILETISIM> repo = new GenericRepository<TBLILETISIM>();
        public ActionResult Index()
        {
            var mesajlar = repo.list();
            return View(mesajlar);
        }
    }
}