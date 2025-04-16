using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;

namespace MvcCv.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        DbCvEntities db = new DbCvEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLHAKKIMDA.ToList();
            return View(degerler);
        }
        public PartialViewResult SosyalMedya()
        {
            var sosyalmedya = db.TBLSOSYALMEDYA.Where(x=>x.Durum==true).ToList();
            return PartialView(sosyalmedya);
        }
        public  PartialViewResult Deneyim()
        {
            var deneyimler = db.TBLDENEYIMLERIM.ToList();
            return PartialView(deneyimler);
        }

        public PartialViewResult Egitimlerim()
        {
            var egitimler = db.TBLEGITIMLERIM.ToList();
            return PartialView(egitimler);
        }


        public PartialViewResult Yeteneklerim()
        {
            var yetenekler = db.TBLYETENEKLERIM.ToList();
            return PartialView(yetenekler);
        }

        public PartialViewResult Hobilerim()
        {
            var hobiler = db.TBLHOBILERIM.ToList();
            return PartialView(hobiler);
        }

        public PartialViewResult Sertifikalarım()
        {
            var sertifikalar = db.TBLSERTIFIKALARIM.ToList();
            return PartialView(sertifikalar);
        }
        [HttpGet]
        public PartialViewResult iletisim()
        {
            
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult iletisim(TBLILETISIM t)
        {
            t.Tarih =DateTime.Parse( DateTime.Now.ToShortDateString());
            db.TBLILETISIM.Add(t);
            db.SaveChanges();
            return PartialView();
        }
    }
}