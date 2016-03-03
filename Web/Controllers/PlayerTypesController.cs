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
    public class PlayerTypesController : Controller
    {
        private SulgpallDbContext db = new SulgpallDbContext();

        // GET: PlayerTypes
        public ActionResult Index()
        {
            return View(db.PlayerTypes.ToList());
        }

        // GET: PlayerTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerType playerType = db.PlayerTypes.Find(id);
            if (playerType == null)
            {
                return HttpNotFound();
            }
            return View(playerType);
        }

        // GET: PlayerTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlayerTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlayerTypeId,Name,Commentar")] PlayerType playerType)
        {
            if (ModelState.IsValid)
            {
                db.PlayerTypes.Add(playerType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(playerType);
        }

        // GET: PlayerTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerType playerType = db.PlayerTypes.Find(id);
            if (playerType == null)
            {
                return HttpNotFound();
            }
            return View(playerType);
        }

        // POST: PlayerTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlayerTypeId,Name,Commentar")] PlayerType playerType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(playerType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(playerType);
        }

        // GET: PlayerTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerType playerType = db.PlayerTypes.Find(id);
            if (playerType == null)
            {
                return HttpNotFound();
            }
            return View(playerType);
        }

        // POST: PlayerTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlayerType playerType = db.PlayerTypes.Find(id);
            db.PlayerTypes.Remove(playerType);
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
