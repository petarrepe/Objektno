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

namespace Objektno.Controllers.Admin
{
    public class AdminReceiptController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminReceipt
        public ActionResult Index()
        {
            var receiptModels = db.ReceiptModels.Include(r => r.PaymentMethod).Include(r => r.User).Include(r => r.Waiter);
            return View(receiptModels.ToList());
        }

        // GET: AdminReceipt/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReceiptModel receiptModel = db.ReceiptModels.Find(id);
            if (receiptModel == null)
            {
                return HttpNotFound();
            }
            return View(receiptModel);
        }

        // GET: AdminReceipt/Create
        public ActionResult Create()
        {
            ViewBag.IDPaymentMethod = new SelectList(db.PaymentMethodModels, "IDPaymentMethod", "TypePaymentMethod");
            ViewBag.IDUser = new SelectList(db.UserModels, "IDUser", "Name");
            ViewBag.IDWaiter = new SelectList(db.WaiterModels, "IDWaiter", "Name");
            return View();
        }

        // POST: AdminReceipt/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDReceipt,Date,IDWaiter,IDPaymentMethod,IDUser,TotalCost,Discount")] ReceiptModel receiptModel)
        {
            if (ModelState.IsValid)
            {
                db.ReceiptModels.Add(receiptModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDPaymentMethod = new SelectList(db.PaymentMethodModels, "IDPaymentMethod", "TypePaymentMethod", receiptModel.IDPaymentMethod);
            ViewBag.IDUser = new SelectList(db.UserModels, "IDUser", "Name", receiptModel.IDUser);
            ViewBag.IDWaiter = new SelectList(db.WaiterModels, "IDWaiter", "Name", receiptModel.IDWaiter);
            return View(receiptModel);
        }

        // GET: AdminReceipt/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReceiptModel receiptModel = db.ReceiptModels.Find(id);
            if (receiptModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDPaymentMethod = new SelectList(db.PaymentMethodModels, "IDPaymentMethod", "TypePaymentMethod", receiptModel.IDPaymentMethod);
            ViewBag.IDUser = new SelectList(db.UserModels, "IDUser", "Name", receiptModel.IDUser);
            ViewBag.IDWaiter = new SelectList(db.WaiterModels, "IDWaiter", "Name", receiptModel.IDWaiter);
            return View(receiptModel);
        }

        // POST: AdminReceipt/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDReceipt,Date,IDWaiter,IDPaymentMethod,IDUser,TotalCost,Discount")] ReceiptModel receiptModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(receiptModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDPaymentMethod = new SelectList(db.PaymentMethodModels, "IDPaymentMethod", "TypePaymentMethod", receiptModel.IDPaymentMethod);
            ViewBag.IDUser = new SelectList(db.UserModels, "IDUser", "Name", receiptModel.IDUser);
            ViewBag.IDWaiter = new SelectList(db.WaiterModels, "IDWaiter", "Name", receiptModel.IDWaiter);
            return View(receiptModel);
        }

        // GET: AdminReceipt/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReceiptModel receiptModel = db.ReceiptModels.Find(id);
            if (receiptModel == null)
            {
                return HttpNotFound();
            }
            return View(receiptModel);
        }

        // POST: AdminReceipt/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReceiptModel receiptModel = db.ReceiptModels.Find(id);
            db.ReceiptModels.Remove(receiptModel);
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
