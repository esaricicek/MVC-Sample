using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class SubeController : Controller
    {
        // GET: Sube
        public ActionResult Index()
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var subeler = session.Query<Models.Sube>().ToList();
                return View(subeler);
            }
        }
    }
}