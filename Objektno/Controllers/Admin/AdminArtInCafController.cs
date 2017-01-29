using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KonobApp.Model.Models;
using DAL.Repositories;
using KonobApp.Controller;
using KonobApp.Model.Repositories;
using KonobApp.Interfaces;
using Objektno.Models;

namespace Objektno.Controllers.Admin
{
    public class AdminArtInCafController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private CaffeRepository _caffeRepository = CaffeRepository.GetInstance();

        // GET: AdminArtInCaf
        public ActionResult Index()
        {
            _caffeRepository.LoadArticlesInCaffe();
            return View(_caffeRepository.Caffes.ToList());
        }

        // GET: AdminArtInCaf/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticleInCaffeModel articleInCaffeModel = db.ArticleInCaffeModels.Find(id);
            if (articleInCaffeModel == null)
            {
                return HttpNotFound();
            }
            return View(articleInCaffeModel);
        }

        // GET: AdminArtInCaf/Create
        public ActionResult Create()
        {
            ViewBag.IDArticle = new SelectList(db.ArticleModels, "IDArticle", "Name");
            ViewBag.IDCaffe = new SelectList(db.CaffeModels, "IDCaffe", "Name");
            return View();
        }

        // POST: AdminArtInCaf/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,IDCaffe,IDArticle,IsAvailable")] ArticleInCaffeModel articleInCaffeModel)
        {
            if (ModelState.IsValid)
            {
                db.ArticleInCaffeModels.Add(articleInCaffeModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDArticle = new SelectList(db.ArticleModels, "IDArticle", "Name", articleInCaffeModel.IDArticle);
            ViewBag.IDCaffe = new SelectList(db.CaffeModels, "IDCaffe", "Name", articleInCaffeModel.IDCaffe);
            return View(articleInCaffeModel);
        }

        // GET: AdminArtInCaf/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticleInCaffeModel articleInCaffeModel = db.ArticleInCaffeModels.Find(id);
            if (articleInCaffeModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDArticle = new SelectList(db.ArticleModels, "IDArticle", "Name", articleInCaffeModel.IDArticle);
            ViewBag.IDCaffe = new SelectList(db.CaffeModels, "IDCaffe", "Name", articleInCaffeModel.IDCaffe);
            return View(articleInCaffeModel);
        }

        // POST: AdminArtInCaf/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IDCaffe,IDArticle,IsAvailable")] ArticleInCaffeModel articleInCaffeModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(articleInCaffeModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDArticle = new SelectList(db.ArticleModels, "IDArticle", "Name", articleInCaffeModel.IDArticle);
            ViewBag.IDCaffe = new SelectList(db.CaffeModels, "IDCaffe", "Name", articleInCaffeModel.IDCaffe);
            return View(articleInCaffeModel);
        }

        // GET: AdminArtInCaf/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticleInCaffeModel articleInCaffeModel = db.ArticleInCaffeModels.Find(id);
            if (articleInCaffeModel == null)
            {
                return HttpNotFound();
            }
            return View(articleInCaffeModel);
        }

        // POST: AdminArtInCaf/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ArticleInCaffeModel articleInCaffeModel = db.ArticleInCaffeModels.Find(id);
            db.ArticleInCaffeModels.Remove(articleInCaffeModel);
            db.SaveChanges();
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
