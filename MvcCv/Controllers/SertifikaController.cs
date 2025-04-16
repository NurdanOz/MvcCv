using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class SertifikaController : Controller
    {
        // GET: Sertifika
        GenericRepository<TBLSERTIFIKALARIM> repo = new GenericRepository<TBLSERTIFIKALARIM>();
        public ActionResult Index()
        {
            var sertifika = repo.list();

            return View(sertifika);
        }

        [HttpGet]
        public ActionResult SertifikaGetir(int id)
        {
            var sertifika = repo.find(x => x.ID == id);
            ViewBag.d = id;
            return View(sertifika);
        }

        [HttpPost]
        public ActionResult SertifikaGetir(TBLSERTIFIKALARIM t)
        {
            var sertifika = repo.find(x => x.ID == t.ID);

            sertifika.Aciklama = t.Aciklama;
            sertifika.Tarih = t.Tarih;
            repo.TUpdate(sertifika);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult yenisertifika()
        {
            return View();
        }

        [HttpPost]
        public ActionResult yenisertifika(TBLSERTIFIKALARIM p)
        {
            repo.TAdd(p);

            return RedirectToAction("Index");
        }

        public ActionResult SertifikaSil(int id)
        {
            var sertifika = repo.find(x => x.ID == id);
            repo.TDelete(sertifika);
            return RedirectToAction("Index");
        }
        

    }
}