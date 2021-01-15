using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class OgrenciController : Controller
    {
        // GET: Ogrenci
        public ActionResult Listele()
        {
            return View(Models.OgrenciVeri.VeriListe);
        }

        public ActionResult Yeni()
        {
            return View();
        }

        public ActionResult Edit(int Id)
        {
            var ogrenci = Models.OgrenciVeri.VeriListe.Where(x => x.Id == Id).FirstOrDefault();
            return View(ogrenci);
        }

        [HttpPost]
        public ActionResult Edit(Models.OgrenciVeri ogrenciVeri)
        {
            var ogrenci = Models.OgrenciVeri.VeriListe.FirstOrDefault(x => x.Id == ogrenciVeri.Id);
            ogrenci.Ad = ogrenciVeri.Ad;
            ogrenci.Soyad = ogrenciVeri.Soyad;
            ogrenci.Bolum = ogrenciVeri.Bolum;
            return RedirectToAction("Listele");
        }

        public ActionResult Delete(int Id)
        {
            var ogrenci = Models.OgrenciVeri.VeriListe.Where(x => x.Id == Id).FirstOrDefault();
            return View(ogrenci);
        }

        [HttpPost]
        public ActionResult Delete(Models.OgrenciVeri ogrenciVeri)
        {
            var ogrenci = Models.OgrenciVeri.VeriListe.FirstOrDefault(x=> x.Id == ogrenciVeri.Id);
            Models.OgrenciVeri.VeriListe.Remove(ogrenci);
            return RedirectToAction("Listele");
        }


        [HttpPost]
        public ActionResult Yeni(Models.OgrenciVeri ogrenciVeri)
        {
            Models.OgrenciVeri.VeriListe.Add(ogrenciVeri);
            return RedirectToAction("Listele");
        }

        public ActionResult Listele2()
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                //var sube = session.Get<Models.Sube>(1);
                //var bnkF = session.Query<Models.Banka>().Where(x=> x.Id == 1).FirstOrDefault();
                var bnkYeni = new Models.Banka() { Ad = "Yeni Banka", Sehir = "Bursa", Telefon = "0422212123" };
                
                var Sube = new Models.Sube() { Ad = "Sube Yeni", Telefon="02125334444" };
                Sube.Banka = bnkYeni;

                //var sube = new Models.Sube();
                //sube.Ad = "Nilufer";
                //sube.Telefon = "02122121218";
                //sube.Banka = bnkYeni;

                //bnkYeni.Subeler.Add(sube);

                session.SaveOrUpdate(Sube);
                session.Flush();

                //var banka = session.Query<Models.Banka>().Where(x => x.Ad == "A Bankası").FirstOrDefault();
                //sube.Banka = banka;


                //var t = banka.Subeler;
                //linq query

                //bnk.Ad = "E bankası";
                //bnk.Sube = "Kadıköy";
                //var bnkQ = session.Query<Models.Banka>().Where(x => x.Sehir == "Istanbul").ToList();
                //rollback 
                //commit

                //var bnk = new Models.Banka()
                //{
                //    Ad = "H Bankası",
                //    Telefon = "312 2121211",
                //    Sehir = "Ankara"
                //};

                //var bnk = session.Query<Models.Banka>().FirstOrDefault(x => x.Id == 7);

                //session.SaveOrUpdate(bnk);

                //session.Delete(bnk);

            }


            return View(Models.OgrenciVeri.VeriListe);
        }

        public ActionResult Listele3()
        {
            return View(Models.OgrenciVeri.VeriListe);
        }

        public ActionResult Duzenle(int Id)
        {
            var ogrenci = Models.OgrenciVeri.VeriListe.Where(x => x.Id == Id).FirstOrDefault();
            return View(ogrenci);
        }

        [HttpPost]
        public ActionResult Duzenle(Models.OgrenciVeri ogrenci)
        {
            var ogrenciEdit = Models.OgrenciVeri.VeriListe.Where(x => x.Id == ogrenci.Id).FirstOrDefault();
            ogrenciEdit.Ad = ogrenci.Ad;
            return RedirectToAction("Listele");            
        }
    }
}