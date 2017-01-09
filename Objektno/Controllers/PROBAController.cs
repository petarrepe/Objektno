using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate.Linq;
using NHibernate;
using Objektno.Models;

namespace Objektno.Controllers
{
    public class PROBAController : Controller
    {
        // GET: PROBA
        public ActionResult Index()
        {
            using (ISession session = OpenNHibertnateSession.OpenSession())
            {
                var employees = session.Query<CaffeModel>().ToList();
                return View(employees);
            }

        }
    }
}