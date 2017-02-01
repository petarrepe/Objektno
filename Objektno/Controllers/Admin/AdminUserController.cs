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
    public class AdminUserController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private AccountRepository _userRepository = AccountRepository.GetInstance();
        // GET: AdminUser
        public ActionResult Index()
        {
            _userRepository.LoadUsers();
            return View(_userRepository.Users.ToList());
        }

        // GET: AdminUser/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            UserModel userModel = _userRepository.FindUserByID(Convert.ToInt32(id));
            if (userModel == null)
            {
                return HttpNotFound();
            }
            return View(userModel);
        }

        // GET: AdminUser/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminUser/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDUser,Name,Surname,Email,Password,CardNumber,IsAdmin")] UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                _userRepository.AddUser(userModel.Name, userModel.Surname, userModel.Email, userModel.CardNumber, userModel.Password, userModel.DateOfBirth, userModel.IsAdmin);
                return RedirectToAction("Index");
            }

            return View(userModel);
        }

        // GET: AdminUser/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserModel userModel = _userRepository.FindUserByID(Convert.ToInt32(id));
            if (userModel == null)
            {
                return HttpNotFound();
            }
            return View(userModel);
        }

        // POST: AdminUser/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDUser,Name,Surname,Email,Password,CardNumber,IsAdmin")] UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                _userRepository.UpdateUser(userModel.IDUser, userModel.Name, userModel.Surname, userModel.Email, userModel.CardNumber, userModel.Password, userModel.DateOfBirth, userModel.IsAdmin);
                return RedirectToAction("Index");
            }
            return View(userModel);
        }

        // GET: AdminUser/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserModel userModel = _userRepository.FindUserByID(Convert.ToInt32(id));
            if (_userRepository.IsUserAdmin(userModel.Email, userModel.Password))
            {
                return RedirectToAction("NoNoAdmin");
            }

            if (userModel == null)
            {
                return HttpNotFound();
            }
            return View(userModel);
        }

        // POST: AdminUser/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _userRepository.DeleteUser(id);
            return RedirectToAction("Index");
        }

        public ActionResult NoNoAdmin()
        {
            return View();
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
