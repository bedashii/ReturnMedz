using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Mapper.Models;
using Mapper.Models.DBContexts;

namespace Mapper.Controllers
{
    public class DetailedViewController : Controller
    {
        private CanvasContext db = new CanvasContext();

        // GET: DetailedView
        public ActionResult Index()
        {
            return View();
        }

        // GET: DetailedView/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Canvas canvas = db.Canvas.Find(id);
            if (canvas == null)
            {
                return HttpNotFound();
            }
            return View(canvas);
        }

        // GET: DetailedView/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DetailedView/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Location,Map")] Canvas canvas)
        {
            if (ModelState.IsValid)
            {
                db.Canvas.Add(canvas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(canvas);
        }

        // GET: DetailedView/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Canvas canvas = db.Canvas.Find(id);
            if (canvas == null)
            {
                return HttpNotFound();
            }
            return View(canvas);
        }

        // POST: DetailedView/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Location,Map")] Canvas canvas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(canvas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(canvas);
        }

        // GET: DetailedView/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Canvas canvas = db.Canvas.Find(id);
            if (canvas == null)
            {
                return HttpNotFound();
            }
            return View(canvas);
        }

        // POST: DetailedView/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Canvas canvas = db.Canvas.Find(id);
            db.Canvas.Remove(canvas);
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
