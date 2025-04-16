using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class YetenekController : Controller
    {
        // GET: Yetenek
        
        GenericRepository<TBLYETENEKLERIM> repo = new GenericRepository<TBLYETENEKLERIM>();
        public ActionResult Index()
        {
            var yetenekler = repo.list();
            return View(yetenekler);
        }
        [HttpGet]
        public ActionResult YeniYetenek()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniYetenek(TBLYETENEKLERIM p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult YetenekSil(int id)
        {
            var yetenek = repo.find(x => x.ID == id);
            repo.TDelete(yetenek);
            return RedirectToAction("Index");
        }
        [HttpGet]

       public ActionResult YetenekDüzenle(int id)
        {
            var yetenek = repo.find(x => x.ID == id);
            return View();
        }
        [HttpPost]
        public ActionResult YetenekDüzenle(TBLYETENEKLERIM t)
        {
            var y = repo.find(x => x.ID == t.ID);
            y.Yetenek = t.Yetenek;
            y.Oran = t.Oran;
            repo.TUpdate(y);
            return RedirectToAction("Index");
        }

    }
}