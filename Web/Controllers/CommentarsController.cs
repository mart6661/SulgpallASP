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
    public class CommentarsController : Controller
    {
        private SulgpallDbContext db = new SulgpallDbContext();

        // GET: Commentars
        public ActionResult Index()
        {
            var commentars = db.Commentars.Include(c => c.Messageboard).Include(c => c.Player);
            return View(commentars.ToList());
        }

        // GET: Commentars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commentar commentar = db.Commentars.Find(id);
            if (commentar == null)
            {
                return HttpNotFound();
            }
            return View(commentar);
        }

        // GET: Commentars/Create
        public ActionResult Create()
        {
            ViewBag.MessageboardId = new SelectList(db.Messageboards, "MessageboardId", "Title");
            ViewBag.PlayerId = new SelectList(db.Players, "PlayerId", "Firstname");
            return View();
        }

        // POST: Commentars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CommentarId,BoardCommentar,PlayerId,MessageboardId")] Commentar commentar)
        {
            if (ModelState.IsValid)
            {
                db.Commentars.Add(commentar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MessageboardId = new SelectList(db.Messageboards, "MessageboardId", "Title", commentar.MessageboardId);
            ViewBag.PlayerId = new SelectList(db.Players, "PlayerId", "Firstname", commentar.PlayerId);
            return View(commentar);
        }

        // GET: Commentars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commentar commentar = db.Commentars.Find(id);
            if (commentar == null)
            {
                return HttpNotFound();
            }
            ViewBag.MessageboardId = new SelectList(db.Messageboards, "MessageboardId", "Title", commentar.MessageboardId);
            ViewBag.PlayerId = new SelectList(db.Players, "PlayerId", "Firstname", commentar.PlayerId);
            return View(commentar);
        }

        // POST: Commentars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CommentarId,BoardCommentar,PlayerId,MessageboardId")] Commentar commentar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(commentar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MessageboardId = new SelectList(db.Messageboards, "MessageboardId", "Title", commentar.MessageboardId);
            ViewBag.PlayerId = new SelectList(db.Players, "PlayerId", "Firstname", commentar.PlayerId);
            return View(commentar);
        }

        // GET: Commentars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commentar commentar = db.Commentars.Find(id);
            if (commentar == null)
            {
                return HttpNotFound();
            }
            return View(commentar);
        }

        // POST: Commentars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Commentar commentar = db.Commentars.Find(id);
            db.Commentars.Remove(commentar);
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
