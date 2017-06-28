using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BankingAppMVCWithUnitTestingV2.DataAccess;
using BankingAppMVCWithUnitTestingV2.Models;
using BankingAppMVCWithUnitTestingV2.Repositories;

namespace BankingAppMVCWithUnitTestingV2.Controllers
{
    public class AccountsController : Controller
    {
        private AccountRepository db = new AccountRepository();
        private PersonRepository pr = new PersonRepository();

        // GET: Accounts
        public ActionResult Index()
        {
            var accounts = db.Include();
            return View(accounts.ToList());
        }

        // GET: Accounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // GET: Accounts/Create
        public ActionResult Create()
        {
            ViewBag.PersonID = new SelectList(pr.Persons(), "ID", "Fname");
            return View();
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Type,PersonID")] Account account)
        {
            if (ModelState.IsValid)
            {
                db.Add(account);
                return RedirectToAction("Index");
            }

            ViewBag.PersonID = new SelectList(pr.Persons(), "ID", "Fname", account.PersonID);
            return View(account);
        }

        //GET: Accounts/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Account account = db.Find(id);
        //    if (account == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.PersonID = new SelectList(pr.Persons(), "ID", "Fname", account.PersonID);
        //    return View(account);
        //}

        //POST: Accounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ID,Type,PersonID")] Account account)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Edit(account);
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.PersonID = new SelectList(db.Persons, "ID", "Fname", account.PersonID);
        //    return View(account);
        //}

        // GET: Accounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Account account = db.Find(id);
            db.Remove(account);
            return RedirectToAction("Index");
        }

        public ActionResult Deposit()
        {
            return View();
        }

        [HttpPost, ActionName("Deposit")]
        [ValidateAntiForgeryToken]
        public ActionResult Deposit(int? id, double? amount)
        {
            Account account = db.Find(id);
            if (amount == null)
            {
                return View(account);
            }
            
            db.Deposit(account, amount);
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
