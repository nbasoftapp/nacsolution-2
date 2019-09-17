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
    public class PRController : Controller
    {
        private nlbdataEntities1 db = new nlbdataEntities1();

        // GET: PR
        public ActionResult Index()
        {
            return View(db.NBA_PR.ToList());
        }

        // GET: PR/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NBA_PR nBA_PR = db.NBA_PR.Find(id);
            if (nBA_PR == null)
            {
                return HttpNotFound();
            }
            return View(nBA_PR);
        }

        // GET: PR/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PR/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PR_SR_ID,PR_name,SR_name,province,district,subdistrict,date_entered")] NBA_PR nBA_PR)
        {
            if (ModelState.IsValid)
            {
                db.NBA_PR.Add(nBA_PR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nBA_PR);
        }

        // GET: PR/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NBA_PR nBA_PR = db.NBA_PR.Find(id);
            if (nBA_PR == null)
            {
                return HttpNotFound();
            }
            return View(nBA_PR);
        }

        // POST: PR/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PR_SR_ID,PR_name,SR_name,province,district,subdistrict,date_entered")] NBA_PR nBA_PR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nBA_PR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nBA_PR);
        }

        // GET: PR/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NBA_PR nBA_PR = db.NBA_PR.Find(id);
            if (nBA_PR == null)
            {
                return HttpNotFound();
            }
            return View(nBA_PR);
        }

        // POST: PR/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NBA_PR nBA_PR = db.NBA_PR.Find(id);
            db.NBA_PR.Remove(nBA_PR);
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
