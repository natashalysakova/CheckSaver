﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CheckSaver.Models.Repository;
using CheckSaver.Models;
using CheckSaver.Models.InputModels;

namespace CheckSaver.Controllers
{
    public class TransactionsController : Controller
    {
        CheckSaveDbRepository _repository = new CheckSaveDbRepository();
        private int pageSize = 10;
        // GET: Transactions
        public ActionResult Index(int pageNum = 0, int pageNum2 = 0)
        {
            ViewBag.Credits = _repository.GetCreditsHistory();
            int withCount, withoutCount;
            var transactions = _repository.GetTransactions(pageNum, pageNum2, pageSize, out withCount, out withoutCount);


            ViewData["PageNum"] = pageNum;
            ViewData["PageNum2"] = pageNum2;

            ViewData["PageWithCount"] = withCount;
            ViewData["PageWithoutCount"] = withoutCount;

            if(Request.IsAjaxRequest())
            {
                return PartialView("IndexPage", transactions);
            }

            return View(transactions.ToList());
        }

        // GET: Transactions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transactions transactions = _repository.FindTransactionById(id);
            if (transactions == null)
            {
                return HttpNotFound();
            }
            return View(transactions);
        }

        // GET: Transactions/Create
        public ActionResult Create()
        {
            var neighbours = _repository.GetNeighborsList();
            ViewBag.WhoPay = new SelectList(neighbours, "Id", "Name");
            ViewBag.ForWhom = new SelectList(neighbours, "Id", "Name");
            return View();
        }

        // POST: Transactions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TransactionsInputModel transactions)
        {
            if (ModelState.IsValid)
            {
                _repository.AddNewTransaction(transactions);
                return RedirectToAction("Index");
            }

            var neighbours = _repository.GetNeighborsList();

            ViewBag.WhoPay = new SelectList(neighbours, "Id", "Name", transactions.WhoPay);
            ViewBag.ForWhom = new SelectList(neighbours, "Id", "Name", transactions.ForWhom);
            return View(transactions);
        }

        // GET: Transactions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transactions transactions = _repository.FindTransactionById(id);
            if (transactions == null)
            {
                return HttpNotFound();
            }
            var neighbours = _repository.GetNeighborsList();

            ViewBag.WhoPay = new SelectList(neighbours, "Id", "Name", transactions.WhoPay);
            ViewBag.ForWhom = new SelectList(neighbours, "Id", "Name", transactions.ForWhom);
            return View(transactions);
        }

        // POST: Transactions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,WhoPay,ForWhom,Summa,Caption,Date,IsDebitOff")] Transactions transactions)
        {
            if (ModelState.IsValid)
            {
                _repository.EditTransaction(transactions);
                return RedirectToAction("Index");
            }

            var neighbours = _repository.GetNeighborsList();

            ViewBag.WhoPay = new SelectList(neighbours, "Id", "Name", transactions.WhoPay);
            ViewBag.ForWhom = new SelectList(neighbours, "Id", "Name", transactions.ForWhom);
            return View(transactions);
        }

        // GET: Transactions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transactions transactions = _repository.FindTransactionById(id);
            if (transactions == null)
            {
                return HttpNotFound();
            }
            return View(transactions);
        }

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _repository.RemoveTransaction(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
