using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using nacsolution.Models;

namespace nacsolution.Controllers
{
    public class RoleController : Controller
    {
        private nlbdataEntities1 db = new nlbdataEntities1();

        // GET: Role
        public ActionResult Index()
        {
            return View(db.NBA_Role.ToList());
        }

        // GET: Role/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NBA_Role nBA_Role = db.NBA_Role.Find(id);
            if (nBA_Role == null)
            {
                return HttpNotFound();
            }
            return View(nBA_Role);
        }

        // GET: Role/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Role/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ROLE_ID,role_name,role_created_date")] NBA_Role nBA_Role)
        {
            if (ModelState.IsValid)
            {
                db.NBA_Role.Add(nBA_Role);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nBA_Role);
        }

        // GET: Role/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NBA_Role nBA_Role = db.NBA_Role.Find(id);
            if (nBA_Role == null)
            {
                return HttpNotFound();
            }
            return View(nBA_Role);
        }

        // POST: Role/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ROLE_ID,role_name,role_created_date")] NBA_Role nBA_Role)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nBA_Role).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nBA_Role);
        }

        // GET: Role/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NBA_Role nBA_Role = db.NBA_Role.Find(id);
            if (nBA_Role == null)
            {
                return HttpNotFound();
            }
            return View(nBA_Role);
        }

        // POST: Role/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NBA_Role nBA_Role = db.NBA_Role.Find(id);
            db.NBA_Role.Remove(nBA_Role);
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
