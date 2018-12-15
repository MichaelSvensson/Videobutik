using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using videobutik;

namespace videobutik.Controllers
{
    public class MoviegenresController : Controller
    {
        private VideoStoreEntities db = new VideoStoreEntities();

        // GET: Moviegenres
        public ActionResult Index()
        {
            return View(db.Moviegenre.ToList());
        }

        // GET: Moviegenres/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Moviegenre moviegenre = db.Moviegenre.Find(id);
            if (moviegenre == null)
            {
                return HttpNotFound();
            }
            return View(moviegenre);
        }

        // GET: Moviegenres/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Moviegenres/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GenreId,GenreCategory")] Moviegenre moviegenre)
        {
            if (ModelState.IsValid)
            {
                db.Moviegenre.Add(moviegenre);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(moviegenre);
        }

        // GET: Moviegenres/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Moviegenre moviegenre = db.Moviegenre.Find(id);
            if (moviegenre == null)
            {
                return HttpNotFound();
            }
            return View(moviegenre);
        }

        // POST: Moviegenres/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GenreId,GenreCategory")] Moviegenre moviegenre)
        {
            if (ModelState.IsValid)
            {
                db.Entry(moviegenre).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(moviegenre);
        }

        // GET: Moviegenres/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Moviegenre moviegenre = db.Moviegenre.Find(id);
            if (moviegenre == null)
            {
                return HttpNotFound();
            }
            return View(moviegenre);
        }

        // POST: Moviegenres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Moviegenre moviegenre = db.Moviegenre.Find(id);
            db.Moviegenre.Remove(moviegenre);
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
