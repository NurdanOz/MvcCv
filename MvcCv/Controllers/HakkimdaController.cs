using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class HakkimdaController : Controller
    {
        // GET: Hakkimda
        DbCvEntities db = new DbCvEntities();
        GenericRepository<TBLHAKKIMDA> repo = new GenericRepository<TBLHAKKIMDA>();

        [HttpGet]
        public ActionResult Index()
        {
            var hakkimda = repo.list();
            return View(hakkimda);
        }

        [HttpPost]
        public ActionResult Index(TBLHAKKIMDA p)
        {
            if (Request.Files.Count>0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/image/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.Resim = "/image/" + dosyaadi + uzanti;
            }


            var t = repo.find(x => x.ID == 1);
            t.Ad = p.Ad;
            t.Soyad = p.Soyad;
            t.Adres = p.Adres;
            t.Mail = p.Mail;
            t.Telefon = p.Telefon;
            t.Aciklama = p.Aciklama;
            t.Resim = p.Resim;
            repo.TUpdate(t);

            return RedirectToAction("Index");
        }
    }
}