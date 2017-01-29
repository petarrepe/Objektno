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
    public class AdminArtRecController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private ReceiptRepository _receiptRepository = ReceiptRepository.GetInstance();

        // GET: AdminArtRec
        public ActionResult Index()
        {
            _receiptRepository.LoadArtRec();
            return View(_receiptRepository.ArticleReceipts.ToList());
        }

        // GET: AdminArtRec/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticleReceiptModel articleReceiptModel = _receiptRepository.FindArtRecByID(Convert.ToInt32(id));
            if (articleReceiptModel == null)
            {
                return HttpNotFound();
            }
            return View(articleReceiptModel);
        }

        // GET: AdminArtRec/Create
        public ActionResult Create()
        {
            ViewBag.IDArticle = new SelectList(_receiptRepository.Articles, "IDArticle", "Name");
            ViewBag.IDReceipt = new SelectList(_receiptRepository.Receipts, "IDReceipt", "IDReceipt");
            return View();
        }

        // POST: AdminArtRec/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,IDReceipt,IDArticle,Quantity,PriceOfOne")] ArticleReceiptModel articleReceiptModel)
        {
            if (ModelState.IsValid)
            {
                _receiptRepository.AddArtRec(articleReceiptModel.IDReceipt, articleReceiptModel.IDArticle, articleReceiptModel.Quantity, articleReceiptModel.PriceOfOne);
                return RedirectToAction("Index");
            }

            ViewBag.IDArticle = new SelectList(_receiptRepository.Articles, "IDArticle", "Name", articleReceiptModel.IDArticle);
            ViewBag.IDReceipt = new SelectList(_receiptRepository.Receipts, "IDReceipt", "IDReceipt", articleReceiptModel.IDReceipt);
            return View(articleReceiptModel);
        }

        // GET: AdminArtRec/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticleReceiptModel articleReceiptModel = _receiptRepository.FindArtRecByID(Convert.ToInt32(id));
            if (articleReceiptModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDArticle = new SelectList(_receiptRepository.Articles, "IDArticle", "Name", articleReceiptModel.IDArticle);
            ViewBag.IDReceipt = new SelectList(_receiptRepository.Receipts, "IDReceipt", "IDReceipt", articleReceiptModel.IDReceipt);
            return View(articleReceiptModel);
        }

        // POST: AdminArtRec/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IDReceipt,IDArticle,Quantity,PriceOfOne")] ArticleReceiptModel articleReceiptModel)
        {
            if (ModelState.IsValid)
            {
                _receiptRepository.UpdateArtRec(articleReceiptModel.ID, articleReceiptModel.IDReceipt, articleReceiptModel.IDArticle, articleReceiptModel.Quantity, articleReceiptModel.PriceOfOne);
                return RedirectToAction("Index");
            }
            ViewBag.IDArticle = new SelectList(_receiptRepository.Articles, "IDArticle", "Name", articleReceiptModel.IDArticle);
            ViewBag.IDReceipt = new SelectList(_receiptRepository.Receipts, "IDReceipt", "IDReceipt", articleReceiptModel.IDReceipt);
            return View(articleReceiptModel);
        }

        // GET: AdminArtRec/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticleReceiptModel articleReceiptModel = _receiptRepository.FindArtRecByID(Convert.ToInt32(id));
            if (articleReceiptModel == null)
            {
                return HttpNotFound();
            }
            return View(articleReceiptModel);
        }

        // POST: AdminArtRec/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _receiptRepository.DeleteArtRec(id);
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
