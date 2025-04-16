using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;


namespace MvcCv.Controllers
{
    public class HobiController : Controller
    {
        // GET: Hobi
        GenericRepository<TBLHOBILERIM> repo = new GenericRepository<TBLHOBILERIM>();

        [HttpGet]
        public ActionResult Index()
        {
            var hobiler = repo.list();
            return View(hobiler);
        }

        [HttpPost]
        public ActionResult Index(TBLHOBILERIM p)
        {
            //TBLHOBILERIM t = new TBLHOBILERIM();
            var t = repo.find(x => x.ID == 1);
            t.Aciklama1 = p.Aciklama1;
            t.Aciklama2 = p.Aciklama2;
            repo.TUpdate(t);
            
            return RedirectToAction("Index");
        }
    }
}