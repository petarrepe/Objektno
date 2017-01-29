using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Objektno.Controllers.Admin
{
    public class StartingPageController : Controller
    {
        // GET: StartingPage
        public ActionResult Index()
        {
            return View();
        }

        // GET: StartingPage/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StartingPage/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StartingPage/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: StartingPage/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StartingPage/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: StartingPage/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StartingPage/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
