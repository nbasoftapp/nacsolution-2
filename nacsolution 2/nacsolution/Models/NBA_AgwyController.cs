﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace nacsolution.Models
{
    public class NBA_AgwyController : Controller
    {
        private nlbdataEntities db = new nlbdataEntities();

        //// GET: NBA_Agwy
        //public ActionResult Index()
        //{
        //    //var nBA_Agwy = db.NBA_Agwy.Include(n => n.NBA_Core).Include(n => n.NBA_Documents).Include(n => n.NBA_Entry_Points).Include(n => n.NBA_Gender).Include(n => n.NBA_HighSchoolQuizz).Include(n => n.NBA_Identification).Include(n => n.NBA_MessageID).Include(n => n.NBA_Occupation).Include(n => n.NBA_SemesterMaintenance).Include(n => n.NBA_PR).Include(n => n.NBA_RiskAssessment);
        //    return View(nBA_Agwy.ToList());
        //}

        // GET: NBA_Agwy/Details/5
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

        // GET: NBA_Agwy/Create
        public ActionResult Create()
        {
            ViewBag.Core_ID = new SelectList(db.NBA_Core, "CORE_ID", "description");
            ViewBag.DOCUMENT_ID = new SelectList(db.NBA_Documents, "DOCUMENT_ID", "doc_name");
            ViewBag.EntryPoint_ID = new SelectList(db.NBA_Entry_Points, "ENTRY_ID", "description");
            ViewBag.gender = new SelectList(db.NBA_Gender, "GenderID", "GenderType");
            ViewBag.HighSchoolQuizz_ID = new SelectList(db.NBA_HighSchoolQuizz, "HighSchoolQuiz_ID", "Description");
            ViewBag.type_of_identification = new SelectList(db.NBA_Identification, "Identification_ID", "Description");
            ViewBag.messageInquiry = new SelectList(db.NBA_MessageID, "MessageID", "Description");
            ViewBag.currrent_occupation = new SelectList(db.NBA_Occupation, "Occupation_ID", "Description");
            ViewBag.SEMESTER_ID = new SelectList(db.NBA_SemesterMaintenance, "SEMESTER_ID", "semester_name");
            ViewBag.ID = new SelectList(db.NBA_PR, "ID", "PR_SR_ID");
            ViewBag.RISK_ID = new SelectList(db.NBA_RiskAssessment, "RISK_ID", "risk_description");
            return View();
        }

        // POST: NBA_Agwy/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AGWY_ID,name,surname,known_as,gender,race,type_of_identification,idno,dateOfbirth,place_of_birth,maiden_name,address,town_village,uic,email,phone_number,alternative_number,alternative_number_relationship,attended_school,name_of_school,higest_grade_passed,currrent_occupation,approval_flag,concent_flag,mimetype,imagedata,home_language,reg_date,last_updated,last_login,status,ID,SEMESTER_ID,SYS_USER_ID,DOCUMENT_ID,Core_ID,messageInquiry,EntryPoint_ID,HighSchoolQuizz_ID,RISK_ID")] NBA_Agwy nBA_Agwy)
        {
            if (ModelState.IsValid)
            {
                db.NBA_Agwy.Add(nBA_Agwy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Core_ID = new SelectList(db.NBA_Core, "CORE_ID", "description", nBA_Agwy.Core_ID);
            ViewBag.DOCUMENT_ID = new SelectList(db.NBA_Documents, "DOCUMENT_ID", "doc_name", nBA_Agwy.DOCUMENT_ID);
            ViewBag.EntryPoint_ID = new SelectList(db.NBA_Entry_Points, "ENTRY_ID", "description", nBA_Agwy.EntryPoint_ID);
            ViewBag.gender = new SelectList(db.NBA_Gender, "GenderID", "GenderType", nBA_Agwy.gender);
            ViewBag.HighSchoolQuizz_ID = new SelectList(db.NBA_HighSchoolQuizz, "HighSchoolQuiz_ID", "Description", nBA_Agwy.HighSchoolQuizz_ID);
            ViewBag.type_of_identification = new SelectList(db.NBA_Identification, "Identification_ID", "Description", nBA_Agwy.type_of_identification);
            ViewBag.messageInquiry = new SelectList(db.NBA_MessageID, "MessageID", "Description", nBA_Agwy.messageInquiry);
            ViewBag.currrent_occupation = new SelectList(db.NBA_Occupation, "Occupation_ID", "Description", nBA_Agwy.currrent_occupation);
            ViewBag.SEMESTER_ID = new SelectList(db.NBA_SemesterMaintenance, "SEMESTER_ID", "semester_name", nBA_Agwy.SEMESTER_ID);
            ViewBag.ID = new SelectList(db.NBA_PR, "ID", "PR_SR_ID", nBA_Agwy.ID);
            ViewBag.RISK_ID = new SelectList(db.NBA_RiskAssessment, "RISK_ID", "risk_description", nBA_Agwy.RISK_ID);
            return View(nBA_Agwy);
        }

        // GET: NBA_Agwy/Edit/5
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
            ViewBag.EntryPoint_ID = new SelectList(db.NBA_Entry_Points, "ENTRY_ID", "description", nBA_Agwy.EntryPoint_ID);
            ViewBag.gender = new SelectList(db.NBA_Gender, "GenderID", "GenderType", nBA_Agwy.gender);
            ViewBag.HighSchoolQuizz_ID = new SelectList(db.NBA_HighSchoolQuizz, "HighSchoolQuiz_ID", "Description", nBA_Agwy.HighSchoolQuizz_ID);
            ViewBag.type_of_identification = new SelectList(db.NBA_Identification, "Identification_ID", "Description", nBA_Agwy.type_of_identification);
            ViewBag.messageInquiry = new SelectList(db.NBA_MessageID, "MessageID", "Description", nBA_Agwy.messageInquiry);
            ViewBag.currrent_occupation = new SelectList(db.NBA_Occupation, "Occupation_ID", "Description", nBA_Agwy.currrent_occupation);
            ViewBag.SEMESTER_ID = new SelectList(db.NBA_SemesterMaintenance, "SEMESTER_ID", "semester_name", nBA_Agwy.SEMESTER_ID);
            ViewBag.ID = new SelectList(db.NBA_PR, "ID", "PR_SR_ID", nBA_Agwy.ID);
            ViewBag.RISK_ID = new SelectList(db.NBA_RiskAssessment, "RISK_ID", "risk_description", nBA_Agwy.RISK_ID);
            return View(nBA_Agwy);
        }

        // POST: NBA_Agwy/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AGWY_ID,name,surname,known_as,gender,race,type_of_identification,idno,dateOfbirth,place_of_birth,maiden_name,address,town_village,uic,email,phone_number,alternative_number,alternative_number_relationship,attended_school,name_of_school,higest_grade_passed,currrent_occupation,approval_flag,concent_flag,mimetype,imagedata,home_language,reg_date,last_updated,last_login,status,ID,SEMESTER_ID,SYS_USER_ID,DOCUMENT_ID,Core_ID,messageInquiry,EntryPoint_ID,HighSchoolQuizz_ID,RISK_ID")] NBA_Agwy nBA_Agwy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nBA_Agwy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Core_ID = new SelectList(db.NBA_Core, "CORE_ID", "description", nBA_Agwy.Core_ID);
            ViewBag.DOCUMENT_ID = new SelectList(db.NBA_Documents, "DOCUMENT_ID", "doc_name", nBA_Agwy.DOCUMENT_ID);
            ViewBag.EntryPoint_ID = new SelectList(db.NBA_Entry_Points, "ENTRY_ID", "description", nBA_Agwy.EntryPoint_ID);
            ViewBag.gender = new SelectList(db.NBA_Gender, "GenderID", "GenderType", nBA_Agwy.gender);
            ViewBag.HighSchoolQuizz_ID = new SelectList(db.NBA_HighSchoolQuizz, "HighSchoolQuiz_ID", "Description", nBA_Agwy.HighSchoolQuizz_ID);
            ViewBag.type_of_identification = new SelectList(db.NBA_Identification, "Identification_ID", "Description", nBA_Agwy.type_of_identification);
            ViewBag.messageInquiry = new SelectList(db.NBA_MessageID, "MessageID", "Description", nBA_Agwy.messageInquiry);
            ViewBag.currrent_occupation = new SelectList(db.NBA_Occupation, "Occupation_ID", "Description", nBA_Agwy.currrent_occupation);
            ViewBag.SEMESTER_ID = new SelectList(db.NBA_SemesterMaintenance, "SEMESTER_ID", "semester_name", nBA_Agwy.SEMESTER_ID);
            ViewBag.ID = new SelectList(db.NBA_PR, "ID", "PR_SR_ID", nBA_Agwy.ID);
            ViewBag.RISK_ID = new SelectList(db.NBA_RiskAssessment, "RISK_ID", "risk_description", nBA_Agwy.RISK_ID);
            return View(nBA_Agwy);
        }

        // GET: NBA_Agwy/Delete/5
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

        // POST: NBA_Agwy/Delete/5
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
