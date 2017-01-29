using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KonobApp.Model.Models;
using Objektno.Models;
using DAL.Repositories;
using KonobApp.Controller;
using KonobApp.Model.Repositories;
using KonobApp.Interfaces;


namespace Objektno.Controllers.Admin
{
    public class AdminWaiterController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private AccountRepository _waiterRepository = AccountRepository.GetInstance();
        private CaffeRepository _caffeRepository = CaffeRepository.GetInstance();

        // GET: AdminWaiter
        public ActionResult Index()
        {
            _caffeRepository.LoadWaiters();
            return View(_caffeRepository.Waiters.ToList());
        }

        // GET: AdminWaiter/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            _caffeRepository.LoadWaiters();
            WaiterModel waiterModel = _caffeRepository.FindWaiterByID(Convert.ToInt32(id));
            if (waiterModel == null)
            {
                return HttpNotFound();
            }
            return View(waiterModel);
        }

        // GET: AdminWaiter/Create
        public ActionResult Create()
        {
            ViewBag.IDCaffe = new SelectList(_caffeRepository.Caffes, "IDCaffe", "Name");
            return View();
        }

        // POST: AdminWaiter/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDWaiter,IDCaffe,Name,Surname,Username,Password")] WaiterModel waiterModel)
        {
            if (ModelState.IsValid)
            {
                _waiterRepository.AddWaiter(waiterModel.Name, waiterModel.Surname, waiterModel.Username, waiterModel.Password, waiterModel.IDCaffe);
                return RedirectToAction("Index");
            }

            ViewBag.IDCaffe = new SelectList(_caffeRepository.Caffes, "IDCaffe", "Name", waiterModel.IDCaffe);
            return View(waiterModel);
        }

        // GET: AdminWaiter/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WaiterModel waiterModel = _waiterRepository.FindWaiterByID(Convert.ToInt32(id));
            if (waiterModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDCaffe = new SelectList(_caffeRepository.Caffes, "IDCaffe", "Name", waiterModel.IDCaffe);
            return View(waiterModel);
        }

        // POST: AdminWaiter/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDWaiter,IDCaffe,Name,Surname,Username,Password")] WaiterModel waiterModel)
        {
            if (ModelState.IsValid)
            {
                _waiterRepository.UpdateWaiter(waiterModel.IDWaiter, waiterModel.Name, waiterModel.Surname, waiterModel.Username, waiterModel.Password, waiterModel.IDCaffe);
                return RedirectToAction("Index");
            }
            ViewBag.IDCaffe = new SelectList(_caffeRepository.Caffes, "IDCaffe", "Name", waiterModel.IDCaffe);
            return View(waiterModel);
        }

        // GET: AdminWaiter/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WaiterModel waiterModel = _waiterRepository.FindWaiterByID(Convert.ToInt32(id));
            if (waiterModel == null)
            {
                return HttpNotFound();
            }
            return View(waiterModel);
        }

        // POST: AdminWaiter/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _waiterRepository.DeleteWaiter(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
