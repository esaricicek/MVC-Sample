using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class BankaController : Controller
    {
        // GET: Banka
        public ActionResult Index()
        {            
            using (var session = NhibernateHelper.OpenSession())
            {
                var banks = session.Query<Models.Banka>().Fetch(x=> x.Subeler).ToList();
                return View(banks);
            }            
        }

        public ActionResult Listele()
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var banks = session.Query<Models.Banka>().ToList();
                return View(banks);
            }
        }

        public ActionResult Yeni()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var bank = session.Query<Models.Banka>().FirstOrDefault(x => x.Id == id);
                return View(bank);
            }
        }


        [HttpPost]
        public ActionResult Edit(Models.Banka banka)
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var bnk = session.Query<Models.Banka>().FirstOrDefault(x => x.Id == banka.Id);
                bnk.Ad = banka.Ad;
                bnk.Sehir = banka.Sehir;
                session.SaveOrUpdate(bnk);
                session.Flush();
                return RedirectToAction("/Index");
            }
        }
    }
}