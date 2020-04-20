using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MysqlConnect.Models;

namespace MysqlConnect.Controllers
{
    public class SSMSMoviesController : Controller
    {
        private SSMSMovieDBContext db = new SSMSMovieDBContext();

        // GET: SSMSMovies
        public ActionResult Index()
        {
            return View(db.Movies.ToList());
        }

        // GET: SSMSMovies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SSMSMovie sSMSMovie = db.Movies.Find(id);
            if (sSMSMovie == null)
            {
                return HttpNotFound();
            }
            return View(sSMSMovie);
        }

        // GET: SSMSMovies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SSMSMovies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,ReleaseDate,Genre,Price")] SSMSMovie sSMSMovie)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(sSMSMovie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sSMSMovie);
        }

        // GET: SSMSMovies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SSMSMovie sSMSMovie = db.Movies.Find(id);
            if (sSMSMovie == null)
            {
                return HttpNotFound();
            }
            return View(sSMSMovie);
        }

        // POST: SSMSMovies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,ReleaseDate,Genre,Price")] SSMSMovie sSMSMovie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sSMSMovie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sSMSMovie);
        }

        // GET: SSMSMovies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SSMSMovie sSMSMovie = db.Movies.Find(id);
            if (sSMSMovie == null)
            {
                return HttpNotFound();
            }
            return View(sSMSMovie);
        }

        // POST: SSMSMovies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SSMSMovie sSMSMovie = db.Movies.Find(id);
            db.Movies.Remove(sSMSMovie);
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
