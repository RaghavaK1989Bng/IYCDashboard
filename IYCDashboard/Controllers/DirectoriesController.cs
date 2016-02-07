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
    public class DirectoriesController : Controller
    {
        private IYCEntities db = new IYCEntities();

        // GET: Directories
        public ActionResult Index(int? pageNumber)
        {
            var directories = db.Directories.Include(d => d.Area).Include(d => d.City).Include(d => d.DirectoryCategory).Include(d => d.State);
            return View(directories.ToList().ToPagedList(pageNumber ?? 1, Constants.pageSize));
        }

        // GET: Directories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Directory directory = db.Directories.Find(id);
            if (directory == null)
            {
                return HttpNotFound();
            }
            return View(directory);
        }

        // GET: Directories/Create
        public ActionResult Create()
        {
            ViewBag.AreaLocated = new SelectList(db.Areas, "AreaId", "AreaName");
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "CityName");
            ViewBag.DirectoryCategoryID = new SelectList(db.DirectoryCategories, "CategoryID", "CategoryName");
            ViewBag.StateID = new SelectList(db.States, "StateID", "StateName");
            return View();
        }

        // POST: Directories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DirectoryEntryID,DirectoryCategoryID,Name,ServiceProvided,StateID,CityID,AreaLocated,PinCode,MobileNo,Expertise")] Directory directory)
        {
            if (ModelState.IsValid)
            {
                db.Directories.Add(directory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AreaLocated = new SelectList(db.Areas, "AreaId", "AreaName", directory.AreaLocated);
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "CityName", directory.CityID);
            ViewBag.DirectoryCategoryID = new SelectList(db.DirectoryCategories, "CategoryID", "CategoryName", directory.DirectoryCategoryID);
            ViewBag.StateID = new SelectList(db.States, "StateID", "StateName", directory.StateID);
            return View(directory);
        }

        // GET: Directories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Directory directory = db.Directories.Find(id);
            if (directory == null)
            {
                return HttpNotFound();
            }
            ViewBag.AreaLocated = new SelectList(db.Areas, "AreaId", "AreaName", directory.AreaLocated);
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "CityName", directory.CityID);
            ViewBag.DirectoryCategoryID = new SelectList(db.DirectoryCategories, "CategoryID", "CategoryName", directory.DirectoryCategoryID);
            ViewBag.StateID = new SelectList(db.States, "StateID", "StateName", directory.StateID);
            return View(directory);
        }

        // POST: Directories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DirectoryEntryID,DirectoryCategoryID,Name,ServiceProvided,StateID,CityID,AreaLocated,PinCode,MobileNo,Expertise")] Directory directory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(directory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AreaLocated = new SelectList(db.Areas, "AreaId", "AreaName", directory.AreaLocated);
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "CityName", directory.CityID);
            ViewBag.DirectoryCategoryID = new SelectList(db.DirectoryCategories, "CategoryID", "CategoryName", directory.DirectoryCategoryID);
            ViewBag.StateID = new SelectList(db.States, "StateID", "StateName", directory.StateID);
            return View(directory);
        }

        // GET: Directories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Directory directory = db.Directories.Find(id);
            if (directory == null)
            {
                return HttpNotFound();
            }
            return View(directory);
        }

        // POST: Directories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Directory directory = db.Directories.Find(id);
            db.Directories.Remove(directory);
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
