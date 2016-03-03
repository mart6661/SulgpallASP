using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;
using Domain;

namespace Web.Controllers
{
    public class MessageboardsController : Controller
    {
        private SulgpallDbContext db = new SulgpallDbContext();

        // GET: Messageboards
        public ActionResult Index()
        {
            var messageboards = db.Messageboards.Include(m => m.Match).Include(m => m.Player);
            return View(messageboards.ToList());
        }

        // GET: Messageboards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Messageboard messageboard = db.Messageboards.Find(id);
            if (messageboard == null)
            {
                return HttpNotFound();
            }
            return View(messageboard);
        }

        // GET: Messageboards/Create
        public ActionResult Create()
        {
            ViewBag.MatchId = new SelectList(db.Matches, "MatchId", "Name");
            ViewBag.PlayerId = new SelectList(db.Players, "PlayerId", "Firstname");
            return View();
        }

        // POST: Messageboards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MessageboardId,Title,Description,PlayerId,MatchId,CompetetionId")] Messageboard messageboard)
        {
            if (ModelState.IsValid)
            {
                db.Messageboards.Add(messageboard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MatchId = new SelectList(db.Matches, "MatchId", "Name", messageboard.MatchId);
            ViewBag.PlayerId = new SelectList(db.Players, "PlayerId", "Firstname", messageboard.PlayerId);
            return View(messageboard);
        }

        // GET: Messageboards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Messageboard messageboard = db.Messageboards.Find(id);
            if (messageboard == null)
            {
                return HttpNotFound();
            }
            ViewBag.MatchId = new SelectList(db.Matches, "MatchId", "Name", messageboard.MatchId);
            ViewBag.PlayerId = new SelectList(db.Players, "PlayerId", "Firstname", messageboard.PlayerId);
            return View(messageboard);
        }

        // POST: Messageboards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MessageboardId,Title,Description,PlayerId,MatchId,CompetetionId")] Messageboard messageboard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(messageboard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MatchId = new SelectList(db.Matches, "MatchId", "Name", messageboard.MatchId);
            ViewBag.PlayerId = new SelectList(db.Players, "PlayerId", "Firstname", messageboard.PlayerId);
            return View(messageboard);
        }

        // GET: Messageboards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Messageboard messageboard = db.Messageboards.Find(id);
            if (messageboard == null)
            {
                return HttpNotFound();
            }
            return View(messageboard);
        }

        // POST: Messageboards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Messageboard messageboard = db.Messageboards.Find(id);
            db.Messageboards.Remove(messageboard);
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
