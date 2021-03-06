﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;
using Domain;

namespace Web.Views
{
    public class CalendersController : Controller
    {
        private SulgpallDbContext db = new SulgpallDbContext();

        // GET: Calenders
        public ActionResult Index()
        {
            var calenders = db.Calenders.Include(c => c.Competition).Include(c => c.Match);
            return View(calenders.ToList());
        }

        // GET: Calenders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calender calender = db.Calenders.Find(id);
            if (calender == null)
            {
                return HttpNotFound();
            }
            return View(calender);
        }

        // GET: Calenders/Create
        public ActionResult Create()
        {
            ViewBag.CompetitionId = new SelectList(db.Competitions, "CompetitionId", "Name");
            ViewBag.MatchId = new SelectList(db.Matches, "MatchId", "Name");
            return View();
        }

        // POST: Calenders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CalenderId,CompetitionId,MatchId")] Calender calender)
        {
            if (ModelState.IsValid)
            {
                db.Calenders.Add(calender);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompetitionId = new SelectList(db.Competitions, "CompetitionId", "Name", calender.CompetitionId);
            ViewBag.MatchId = new SelectList(db.Matches, "MatchId", "Name", calender.MatchId);
            return View(calender);
        }

        // GET: Calenders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calender calender = db.Calenders.Find(id);
            if (calender == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompetitionId = new SelectList(db.Competitions, "CompetitionId", "Name", calender.CompetitionId);
            ViewBag.MatchId = new SelectList(db.Matches, "MatchId", "Name", calender.MatchId);
            return View(calender);
        }

        // POST: Calenders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CalenderId,CompetitionId,MatchId")] Calender calender)
        {
            if (ModelState.IsValid)
            {
                db.Entry(calender).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompetitionId = new SelectList(db.Competitions, "CompetitionId", "Name", calender.CompetitionId);
            ViewBag.MatchId = new SelectList(db.Matches, "MatchId", "Name", calender.MatchId);
            return View(calender);
        }

        // GET: Calenders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calender calender = db.Calenders.Find(id);
            if (calender == null)
            {
                return HttpNotFound();
            }
            return View(calender);
        }

        // POST: Calenders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Calender calender = db.Calenders.Find(id);
            db.Calenders.Remove(calender);
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
