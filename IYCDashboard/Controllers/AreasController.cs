using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IYCDashboard.Models.DB;
using PagedList;

namespace IYCDashboard.Controllers
{
    public class AreasController : Controller
    {
        private IYCEntities db = new IYCEntities();

        // GET: Areas
        public ActionResult Index(int? pageNumber)
        {
            var areas = db.Areas.Include(a => a.City).Include(a => a.State);
            return View(areas.ToList().ToPagedList(pageNumber ?? 1, Constants.pageSize));
        }

        // GET: Areas/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Area area = db.Areas.Find(id);
            if (area == null)
            {
                return HttpNotFound();
            }
            return View(area);
        }

        // GET: Areas/Create
        public ActionResult Create()
        {
            ViewBag.CityId = new SelectList(db.Cities, "CityID", "CityName");
            ViewBag.StateId = new SelectList(db.States, "StateID", "StateName");
            return View();
        }

        // POST: Areas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AreaId,AreaName,StateId,CityId")] Area area)
        {
            if (ModelState.IsValid)
            {
                db.Areas.Add(area);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(db.Cities, "CityID", "CityName", area.CityId);
            ViewBag.StateId = new SelectList(db.States, "StateID", "StateName", area.StateId);
            return View(area);
        }

        // GET: Areas/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Area area = db.Areas.Find(id);
            if (area == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityId = new SelectList(db.Cities, "CityID", "CityName", area.CityId);
            ViewBag.StateId = new SelectList(db.States, "StateID", "StateName", area.StateId);
            return View(area);
        }

        // POST: Areas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AreaId,AreaName,StateId,CityId")] Area area)
        {
            if (ModelState.IsValid)
            {
                db.Entry(area).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(db.Cities, "CityID", "CityName", area.CityId);
            ViewBag.StateId = new SelectList(db.States, "StateID", "StateName", area.StateId);
            return View(area);
        }

        // GET: Areas/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Area area = db.Areas.Find(id);
            if (area == null)
            {
                return HttpNotFound();
            }
            return View(area);
        }

        // POST: Areas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Area area = db.Areas.Find(id);
            db.Areas.Remove(area);
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
