﻿using System;
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
    public class BeneficiaryController : Controller
    {
        private nlbdataEntities db = new nlbdataEntities();

        // GET: Beneficiary
        //public ActionResult Index()
        //{
        //    var nBA_Agwy = db.NBA_Agwy.Include(n => n.NBA_Core).Include(n => n.NBA_Documents).Include(n => n.NBA_RiskAssessment).Include(n => n.NBA_SemesterMaintenance).Include(n => n.NBA_PR);
        //    return View(nBA_Agwy.ToList());
        //}

        // GET: Beneficiary/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NBA_Agwy nBA_Agwy = db.NBA_Agwy.Find(id);
            if (nBA_Agwy == null)
            {
                return HttpNotFound();
            }
            return View(nBA_Agwy);
        }

        // GET: Beneficiary/Create
        public ActionResult Create()
        {
            ViewBag.Core_ID = new SelectList(db.NBA_Core, "CORE_ID", "description");
            ViewBag.DOCUMENT_ID = new SelectList(db.NBA_Documents, "DOCUMENT_ID", "doc_name");
            ViewBag.RISK_ID = new SelectList(db.NBA_RiskAssessment, "RISK_ID", "risk_description");
            ViewBag.SEMESTER_ID = new SelectList(db.NBA_SemesterMaintenance, "SEMESTER_ID", "semester_name");
            ViewBag.ID = new SelectList(db.NBA_PR, "ID", "PR_SR_ID");
            return View();
        }

        // POST: Beneficiary/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AGWY_ID,name,surname,known_as,gender,race,type_of_identification,idno,dateOfbirth,place_of_birth,maiden_name,address,town_village,uic,email,phone_number,alternative__number,alternative_number_relationship,attended_school,name_of_school,higest_grade_passed,currrent_occupation,safe_place,approval_flag,concent_flag,mimetype,imagedata,home_language,reg_date,last_updated,last_login,status,ID,SEMESTER_ID,SYS_USER_ID,DOCUMENT_ID,RISK_ID,Core_ID")] NBA_Agwy nBA_Agwy)
        {
            if (ModelState.IsValid)
            {
                db.NBA_Agwy.Add(nBA_Agwy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Core_ID = new SelectList(db.NBA_Core, "CORE_ID", "description", nBA_Agwy.Core_ID);
            ViewBag.DOCUMENT_ID = new SelectList(db.NBA_Documents, "DOCUMENT_ID", "doc_name", nBA_Agwy.DOCUMENT_ID);
            ViewBag.RISK_ID = new SelectList(db.NBA_RiskAssessment, "RISK_ID", "risk_description", nBA_Agwy.RISK_ID);
            ViewBag.SEMESTER_ID = new SelectList(db.NBA_SemesterMaintenance, "SEMESTER_ID", "semester_name", nBA_Agwy.SEMESTER_ID);
            ViewBag.ID = new SelectList(db.NBA_PR, "ID", "PR_SR_ID", nBA_Agwy.ID);
            return View(nBA_Agwy);
        }

        // GET: Beneficiary/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NBA_Agwy nBA_Agwy = db.NBA_Agwy.Find(id);
            if (nBA_Agwy == null)
            {
                return HttpNotFound();
            }
            ViewBag.Core_ID = new SelectList(db.NBA_Core, "CORE_ID", "description", nBA_Agwy.Core_ID);
            ViewBag.DOCUMENT_ID = new SelectList(db.NBA_Documents, "DOCUMENT_ID", "doc_name", nBA_Agwy.DOCUMENT_ID);
            ViewBag.RISK_ID = new SelectList(db.NBA_RiskAssessment, "RISK_ID", "risk_description", nBA_Agwy.RISK_ID);
            ViewBag.SEMESTER_ID = new SelectList(db.NBA_SemesterMaintenance, "SEMESTER_ID", "semester_name", nBA_Agwy.SEMESTER_ID);
            ViewBag.ID = new SelectList(db.NBA_PR, "ID", "PR_SR_ID", nBA_Agwy.ID);
            return View(nBA_Agwy);
        }

        // POST: Beneficiary/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AGWY_ID,name,surname,known_as,gender,race,type_of_identification,idno,dateOfbirth,place_of_birth,maiden_name,address,town_village,uic,email,phone_number,alternative__number,alternative_number_relationship,attended_school,name_of_school,higest_grade_passed,currrent_occupation,safe_place,approval_flag,concent_flag,mimetype,imagedata,home_language,reg_date,last_updated,last_login,status,ID,SEMESTER_ID,SYS_USER_ID,DOCUMENT_ID,RISK_ID,Core_ID")] NBA_Agwy nBA_Agwy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nBA_Agwy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Core_ID = new SelectList(db.NBA_Core, "CORE_ID", "description", nBA_Agwy.Core_ID);
            ViewBag.DOCUMENT_ID = new SelectList(db.NBA_Documents, "DOCUMENT_ID", "doc_name", nBA_Agwy.DOCUMENT_ID);
            ViewBag.RISK_ID = new SelectList(db.NBA_RiskAssessment, "RISK_ID", "risk_description", nBA_Agwy.RISK_ID);
            ViewBag.SEMESTER_ID = new SelectList(db.NBA_SemesterMaintenance, "SEMESTER_ID", "semester_name", nBA_Agwy.SEMESTER_ID);
            ViewBag.ID = new SelectList(db.NBA_PR, "ID", "PR_SR_ID", nBA_Agwy.ID);
            return View(nBA_Agwy);
        }

        // GET: Beneficiary/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NBA_Agwy nBA_Agwy = db.NBA_Agwy.Find(id);
            if (nBA_Agwy == null)
            {
                return HttpNotFound();
            }
            return View(nBA_Agwy);
        }

        // POST: Beneficiary/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NBA_Agwy nBA_Agwy = db.NBA_Agwy.Find(id);
            db.NBA_Agwy.Remove(nBA_Agwy);
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
