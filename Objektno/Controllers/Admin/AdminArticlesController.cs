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
    public class AdminArticlesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private CaffeRepository _caffeRepository = CaffeRepository.GetInstance();
        private ArticleRepository _articleRepository = ArticleRepository.GetInstance();


        // GET: AdminArticles
        public ActionResult Index()
        {
            _articleRepository.LoadAll();
            return View(_articleRepository.Articles.ToList());
        }

        // GET: AdminArticles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticleModel articleModel = _articleRepository.FindArticleByID(Convert.ToInt32(id));
            if (articleModel == null)
            {
                return HttpNotFound();
            }
            return View(articleModel);
        }

        // GET: AdminArticles/Create
        public ActionResult Create()
        {
            ViewBag.IDCategory = new SelectList(_articleRepository.Categories, "IDCategory", "Name");
            return View();
        }

        // POST: AdminArticles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDArticle,Name,Price,IDCategory")] ArticleModel articleModel)
        {
            if (ModelState.IsValid)
            {
                _articleRepository.AddArticle(articleModel.Name, articleModel.Price, articleModel.IDCategory);
                return RedirectToAction("Index");
            }

            ViewBag.IDCategory = new SelectList(_articleRepository.Categories, "IDCategory", "Name", articleModel.IDCategory);
            return View(articleModel);
        }

        // GET: AdminArticles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticleModel articleModel = _articleRepository.FindArticleByID(Convert.ToInt32(id));
            if (articleModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDCategory = new SelectList(_articleRepository.Categories, "IDCategory", "Name", articleModel.IDCategory);
            return View(articleModel);
        }

        // POST: AdminArticles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDArticle,Name,Price,IDCategory")] ArticleModel articleModel)
        {
            if (ModelState.IsValid)
            {
                _articleRepository.UpdateArticle(articleModel.IDArticle, articleModel.Name, articleModel.Price, articleModel.IDCategory);
                return RedirectToAction("Index");
            }
            ViewBag.IDCategory = new SelectList(_articleRepository.Categories, "IDCategory", "Name", articleModel.IDCategory);
            return View(articleModel);
        }

        // GET: AdminArticles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticleModel articleModel = _articleRepository.FindArticleByID(Convert.ToInt32(id));
            if (articleModel == null)
            {
                return HttpNotFound();
            }
            return View(articleModel);
        }

        // POST: AdminArticles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _articleRepository.DeleteArticle(id);
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
