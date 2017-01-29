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
    public class AdminTableController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private CaffeRepository _caffeRepository = CaffeRepository.GetInstance();

        // GET: AdminTable
        public ActionResult Index()
        {
            _caffeRepository.LoadTables();
            return View(_caffeRepository.Tables.ToList());
        }

        // GET: AdminTable/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TableModel tableModel = _caffeRepository.FindTableByID(Convert.ToInt32(id));
            if (tableModel == null)
            {
                return HttpNotFound();
            }
            return View(tableModel);
        }

        // GET: AdminTable/Create
        public ActionResult Create()
        {
            ViewBag.IDCaffe = new SelectList(_caffeRepository.Caffes, "IDCaffe", "Name");
            return View();
        }

        // POST: AdminTable/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDTable,IDCaffe,IsOccupied")] TableModel tableModel)
        {
            if (ModelState.IsValid)
            {
                _caffeRepository.AddTable(tableModel.IDCaffe);
                return RedirectToAction("Index");
            }

            ViewBag.IDCaffe = new SelectList(_caffeRepository.Caffes, "IDCaffe", "Name", tableModel.IDCaffe);
            return View(tableModel);
        }

        // GET: AdminTable/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TableModel tableModel = _caffeRepository.FindTableByID(Convert.ToInt32(id));
            if (tableModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDCaffe = new SelectList(_caffeRepository.Caffes, "IDCaffe", "Name", tableModel.IDCaffe);
            return View(tableModel);
        }

        // POST: AdminTable/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDTable,IDCaffe,IsOccupied")] TableModel tableModel)
        {
            if (ModelState.IsValid)
            {
                _caffeRepository.UpdateTable(tableModel.IDTable, tableModel.IDCaffe, tableModel.IsOccupied);
                return RedirectToAction("Index");
            }
            ViewBag.IDCaffe = new SelectList(_caffeRepository.Caffes, "IDCaffe", "Name", tableModel.IDCaffe);
            return View(tableModel);
        }

        // GET: AdminTable/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TableModel tableModel = _caffeRepository.FindTableByID(Convert.ToInt32(id));
            if (tableModel == null)
            {
                return HttpNotFound();
            }
            return View(tableModel);
        }

        // POST: AdminTable/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _caffeRepository.DeleteTable(id);
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
