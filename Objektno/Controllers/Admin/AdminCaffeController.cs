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
    public class AdminCaffeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private CaffeRepository _caffeRepository = CaffeRepository.GetInstance();

        // GET: AdminCaffe
        public ActionResult Index()
        {
            _caffeRepository.LoadCaffe();
            return View(_caffeRepository.Caffes.ToList());
        }

        // GET: AdminCaffe/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaffeModel caffeModel = _caffeRepository.FindCaffeByID(Convert.ToInt32(id));
            if (caffeModel == null)
            {
                return HttpNotFound();
            }
            return View(caffeModel);
        }

        // GET: AdminCaffe/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminCaffe/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDCaffe,Name,Adress,IsOpen")] CaffeModel caffeModel)
        {
            if (ModelState.IsValid)
            {
                _caffeRepository.AddCaffe(caffeModel.Name, caffeModel.Adress, caffeModel.IsOpen);
                return RedirectToAction("Index");
            }

            return View(caffeModel);
        }

        // GET: AdminCaffe/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaffeModel caffeModel = _caffeRepository.FindCaffeByID(Convert.ToInt32(id));
            if (caffeModel == null)
            {
                return HttpNotFound();
            }
            return View(caffeModel);
        }

        // POST: AdminCaffe/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDCaffe,Name,Adress,IsOpen")] CaffeModel caffeModel)
        {
            if (ModelState.IsValid)
            {
                _caffeRepository.UpdateCaffe(caffeModel.IDCaffe, caffeModel.Name, caffeModel.Adress, caffeModel.IsOpen);
                return RedirectToAction("Index");
            }
            return View(caffeModel);
        }

        // GET: AdminCaffe/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaffeModel caffeModel = _caffeRepository.FindCaffeByID(Convert.ToInt32(id));
            if (caffeModel == null)
            {
                return HttpNotFound();
            }
            return View(caffeModel);
        }

        // POST: AdminCaffe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _caffeRepository.DeleteCaffe(id);
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
