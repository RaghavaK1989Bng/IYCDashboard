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
    public class DirectoryCategoriesController : Controller
    {
        private IYCEntities db = new IYCEntities();

        // GET: DirectoryCategories
        public ActionResult Index(int? pageNumber)
        {
            return View(db.DirectoryCategories.ToList().ToPagedList(pageNumber ?? 1, Constants.pageSize));
        }

        // GET: DirectoryCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DirectoryCategory directoryCategory = db.DirectoryCategories.Find(id);
            if (directoryCategory == null)
            {
                return HttpNotFound();
            }
            return View(directoryCategory);
        }

        // GET: DirectoryCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DirectoryCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryID,CategoryName")] DirectoryCategory directoryCategory)
        {
            if (ModelState.IsValid)
            {
                db.DirectoryCategories.Add(directoryCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(directoryCategory);
        }

        // GET: DirectoryCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DirectoryCategory directoryCategory = db.DirectoryCategories.Find(id);
            if (directoryCategory == null)
            {
                return HttpNotFound();
            }
            return View(directoryCategory);
        }

        // POST: DirectoryCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryID,CategoryName")] DirectoryCategory directoryCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(directoryCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(directoryCategory);
        }

        // GET: DirectoryCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DirectoryCategory directoryCategory = db.DirectoryCategories.Find(id);
            if (directoryCategory == null)
            {
                return HttpNotFound();
            }
            return View(directoryCategory);
        }

        // POST: DirectoryCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DirectoryCategory directoryCategory = db.DirectoryCategories.Find(id);
            db.DirectoryCategories.Remove(directoryCategory);
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
