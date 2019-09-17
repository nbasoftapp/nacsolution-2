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
    public class NBA_SYS_UsersController : Controller
    {
        private nlbdataEntities db = new nlbdataEntities();

        // GET: NBA_SYS_Users
        public ActionResult Index()
        {
            var nBA_SYS_Users = db.NBA_SYS_Users.Include(n => n.NBA_Role).Include(n => n.NBA_PR);
            return View(nBA_SYS_Users.ToList());
        }

        // GET: NBA_SYS_Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NBA_SYS_Users nBA_SYS_Users = db.NBA_SYS_Users.Find(id);
            if (nBA_SYS_Users == null)
            {
                return HttpNotFound();
            }
            return View(nBA_SYS_Users);
        }

        // GET: NBA_SYS_Users/Create
        public ActionResult Create()
        {
            ViewBag.ROLE_ID = new SelectList(db.NBA_Role, "ROLE_ID", "role_name");
            ViewBag.ID = new SelectList(db.NBA_PR, "ID", "PR_SR_ID");
            return View();
        }

        // POST: NBA_SYS_Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SYS_USER_ID,name,surname,username,password,mobile,employee_id,organization,province,district,subdistrict,image,SR_name,Entry_ID,email,sys_IsEmailVerified,sys_VerificationCode,reg_date,last_updated,last_login,ROLE_ID,ID")] NBA_SYS_Users nBA_SYS_Users)
        {
            if (ModelState.IsValid)
            {
                db.NBA_SYS_Users.Add(nBA_SYS_Users);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ROLE_ID = new SelectList(db.NBA_Role, "ROLE_ID", "role_name", nBA_SYS_Users.ROLE_ID);
            ViewBag.ID = new SelectList(db.NBA_PR, "ID", "PR_SR_ID", nBA_SYS_Users.ID);
            return View(nBA_SYS_Users);
        }

     
       

        // GET: NBA_SYS_Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NBA_SYS_Users nBA_SYS_Users = db.NBA_SYS_Users.Find(id);
            if (nBA_SYS_Users == null)
            {
                return HttpNotFound();
            }
            ViewBag.ROLE_ID = new SelectList(db.NBA_Role, "ROLE_ID", "role_name", nBA_SYS_Users.ROLE_ID);
            ViewBag.ID = new SelectList(db.NBA_PR, "ID", "PR_SR_ID", nBA_SYS_Users.ID);
            return View(nBA_SYS_Users);
        }

        // POST: NBA_SYS_Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SYS_USER_ID,name,surname,username,password,mobile,employee_id,organization,province,district,subdistrict,image,SR_name,Entry_ID,email,sys_IsEmailVerified,sys_VerificationCode,reg_date,last_updated,last_login,ROLE_ID,ID")] NBA_SYS_Users nBA_SYS_Users)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nBA_SYS_Users).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ROLE_ID = new SelectList(db.NBA_Role, "ROLE_ID", "role_name", nBA_SYS_Users.ROLE_ID);
            ViewBag.ID = new SelectList(db.NBA_PR, "ID", "PR_SR_ID", nBA_SYS_Users.ID);
            return View(nBA_SYS_Users);
        }

        // GET: NBA_SYS_Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NBA_SYS_Users nBA_SYS_Users = db.NBA_SYS_Users.Find(id);
            if (nBA_SYS_Users == null)
            {
                return HttpNotFound();
            }
            return View(nBA_SYS_Users);
        }

        // POST: NBA_SYS_Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NBA_SYS_Users nBA_SYS_Users = db.NBA_SYS_Users.Find(id);
            db.NBA_SYS_Users.Remove(nBA_SYS_Users);
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
