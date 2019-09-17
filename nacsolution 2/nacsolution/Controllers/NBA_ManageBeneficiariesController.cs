using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using nacsolution.Models;
using System.Web.Helpers;

namespace nacsolution.Controllers
{
    public class NBA_ManageBeneficiariesController : Controller
    {
       

     

        private nlbdataEntities db = new nlbdataEntities();

        // GET: NBA_ManageBeneficiaries

        [HttpGet]
        public ActionResult Index()
        {
            var nBA_Agwy = db.NBA_Agwy.Include(n => n.NBA_Core).Include(n => n.NBA_Documents).Include(n => n.NBA_Entry_Points).Include(n => n.NBA_Gender).Include(n => n.NBA_Grade).Include(n => n.NBA_HighSchoolQuizz).Include(n => n.NBA_Identification).Include(n => n.NBA_MessageID).Include(n => n.NBA_Occupation);
            return View(nBA_Agwy.ToList());
        }
        [HttpPost]
        public ActionResult Index(string EmpName, NBA_Agwy emp)
        {
            var nBA_Agwy = db.NBA_Agwy.ToList().Where(p => p.name.StartsWith(EmpName));
            return View(nBA_Agwy.ToList());
        }

        // GET: NBA_ManageBeneficiaries/Details/5
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
        // User Detail according to ID to enroll the Beneficiary
        public ActionResult DetailUser(int? id)
        {
            id = Convert.ToInt32(Session["UseriD"]);
            //using (nlbdataEntities dc = new nlbdataEntities())
            //{
            //    var v = dc.NBA_Agwy.Where(a => a.SYS_USER_ID == id).FirstOrDefault();

            //    //var v = (from myRow in dc.NBA_Agwy.
            //    //        Where(a => a.SYS_USER_ID == id)
            //    //         select myRow);
            //    //Console.WriteLine(v.email);
            //    return View(v);
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
        


        

          

        // GET: NBA_ManageBeneficiaries/Create
        public ActionResult Create()
        {
            ViewBag.Core_ID = new SelectList(db.NBA_Core, "CORE_ID", "description");
            ViewBag.DOCUMENT_ID = new SelectList(db.NBA_Documents, "DOCUMENT_ID", "doc_name");
            ViewBag.EntryPoint_ID = new SelectList(db.NBA_Entry_Points, "ENTRY_ID", "description");
            ViewBag.gender = new SelectList(db.NBA_Gender, "GenderID", "GenderType");
            ViewBag.higest_grade_passed = new SelectList(db.NBA_Grade, "Grade_ID", "Description");
            ViewBag.HighSchoolQuizz_ID = new SelectList(db.NBA_HighSchoolQuizz, "HighSchoolQuiz_ID", "Description");
            ViewBag.type_of_identification = new SelectList(db.NBA_Identification, "Identification_ID", "Description");
            ViewBag.messageInquiry = new SelectList(db.NBA_MessageID, "MessageID", "Description");
            ViewBag.currrent_occupation = new SelectList(db.NBA_Occupation, "Occupation_ID", "Description");
            ViewBag.RISK_ID = new SelectList(db.NBA_RiskAssessment, "RISK_ID", "risk_description");
            ViewBag.SEMESTER_ID = new SelectList(db.NBA_SemesterMaintenance, "SEMESTER_ID", "semester_name");
            ViewBag.ID = new SelectList(db.NBA_PR, "ID", "PR_SR_ID");
            return View();
        }

        // POST: NBA_ManageBeneficiaries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "AGWY_ID,name,surname,known_as,gender,race,type_of_identification,idno,dateOfbirth,place_of_birth,maiden_name,address,town_village,uic,email,phone_number,alternative_number,alternative_number_relationship,attended_school,name_of_school,higest_grade_passed,currrent_occupation,approval_flag,concent_flag,mimetype,imagedata,home_language,reg_date,last_updated,last_login,status,ID,SEMESTER_ID,SYS_USER_ID,DOCUMENT_ID,Core_ID,messageInquiry,EntryPoint_ID,HighSchoolQuizz_ID,RISK_ID")] NBA_Agwy nBA_Agwy)
        public ActionResult Create(NBA_Agwy nBA_Agwy)
        {
            if (ModelState.IsValid)
            {


                var db = new nlbdataEntities();

                string uuic = nBA_Agwy.name.Substring(0, 4) + nBA_Agwy.surname.Substring(0, 4) + nBA_Agwy.dateOfbirth.ToString().Substring(0, 8);

                //r dbuic = db.NBA_Agwy.Where(x => x.uic.Substring(0, 15) == uuic).Select( n1 => n1.uic).FirstOrDefault();
                //ar uic = db.NBA_Agwy.Where(x => x.uic.Substring(0, 15) == uuic).Select(n1 => n1.uic).FirstOrDefault();
                //r uic1=(from var in db.NBA_Agwy where var.uic == nBA_Agwy.uic).select var.uic;
                //uic1.FirstOrDefault();
                //tring dbui1 = dbuic.ToString();


                var uiccount = db.NBA_Agwy.Where(x => x.uic.Substring(0, 16) == uuic).Select(n3 => n3.uic).Count();

                int uiccounting = uiccount;


                NBA_Agwy n = new NBA_Agwy();
                {



                    n.name = nBA_Agwy.name;
                    n.surname = nBA_Agwy.surname;
                    n.known_as = nBA_Agwy.known_as;
                    n.gender = nBA_Agwy.gender;
                    n.age = nBA_Agwy.age;
                    n.type_of_identification = nBA_Agwy.type_of_identification;
                    n.idno = nBA_Agwy.idno;
                    n.reg_date = DateTime.Today;
                    int useridsession = Convert.ToInt32(Session["UseriD"]);
                    n.SYS_USER_ID = useridsession;
                    n.house_number = nBA_Agwy.house_number;
                    n.street_name = nBA_Agwy.street_name;
                    n.town_village_address = nBA_Agwy.town_village_address;
                    n.describe_living = nBA_Agwy.describe_living;
                    n.dateOfbirth = nBA_Agwy.dateOfbirth;
                    n.maiden_name = nBA_Agwy.maiden_name;
                    n.name_of_school = nBA_Agwy.name_of_school;
                    n.alternative_number = nBA_Agwy.alternative_number;
                    n.alternative_number_relationship = nBA_Agwy.alternative_number_relationship;
                    n.attended_school = nBA_Agwy.attended_school;
                    n.currrent_occupation = nBA_Agwy.currrent_occupation;
                    n.email = nBA_Agwy.email;
                    n.EntryPoint_ID = nBA_Agwy.EntryPoint_ID;
                    n.higest_grade_passed = nBA_Agwy.higest_grade_passed;
                    n.HighSchoolQuizz_ID = nBA_Agwy.HighSchoolQuizz_ID;
                    n.known_as = nBA_Agwy.known_as;
                    n.messageInquiry = nBA_Agwy.messageInquiry;
                    n.NBA_Grade = nBA_Agwy.NBA_Grade;
                    n.NBA_Identification = nBA_Agwy.NBA_Identification;
                    n.ID = nBA_Agwy.ID;
                    n.town_village = nBA_Agwy.town_village;
                    n.NBA_Occupation = nBA_Agwy.NBA_Occupation;








                    if (uiccounting > 1 || uiccounting == 1)
                    {
                        if (uiccounting < 9)
                        {
                            n.uic = nBA_Agwy.name.Substring(0, 4) + nBA_Agwy.surname.Substring(0, 4) + nBA_Agwy.dateOfbirth.ToString().Substring(0, 8) + "0" + (1 + uiccount).ToString();
                        }
                        else
                        {
                            n.uic = nBA_Agwy.name.Substring(0, 4) + nBA_Agwy.surname.Substring(0, 4) + nBA_Agwy.dateOfbirth.ToString().Substring(0, 8) + (1 + uiccount).ToString();

                        }

                    }
                    else
                    {
                        n.uic = nBA_Agwy.name.Substring(0, 4) + nBA_Agwy.surname.Substring(0, 4) + nBA_Agwy.dateOfbirth.ToString().Substring(0, 8) + "00";
                    }

                }


                

                db.NBA_Agwy.Add(n);
                db.SaveChanges();
                return RedirectToAction("Index");

                ////db.NBA_Agwy.Add(nBA_Agwy);
                ////db.SaveChanges();
                ////return RedirectToAction("Index");
            }

            ViewBag.Core_ID = new SelectList(db.NBA_Core, "CORE_ID", "description", nBA_Agwy.Core_ID);
            ViewBag.DOCUMENT_ID = new SelectList(db.NBA_Documents, "DOCUMENT_ID", "doc_name", nBA_Agwy.DOCUMENT_ID);
            ViewBag.EntryPoint_ID = new SelectList(db.NBA_Entry_Points, "ENTRY_ID", "description", nBA_Agwy.EntryPoint_ID);
            ViewBag.gender = new SelectList(db.NBA_Gender, "GenderID", "GenderType", nBA_Agwy.gender);
            ViewBag.higest_grade_passed = new SelectList(db.NBA_Grade, "Grade_ID", "Description", nBA_Agwy.higest_grade_passed);
            ViewBag.HighSchoolQuizz_ID = new SelectList(db.NBA_HighSchoolQuizz, "HighSchoolQuiz_ID", "Description", nBA_Agwy.HighSchoolQuizz_ID);
            ViewBag.type_of_identification = new SelectList(db.NBA_Identification, "Identification_ID", "Description", nBA_Agwy.type_of_identification);
            ViewBag.messageInquiry = new SelectList(db.NBA_MessageID, "MessageID", "Description", nBA_Agwy.messageInquiry);
            ViewBag.currrent_occupation = new SelectList(db.NBA_Occupation, "Occupation_ID", "Description", nBA_Agwy.currrent_occupation);
            ViewBag.RISK_ID = new SelectList(db.NBA_RiskAssessment, "RISK_ID", "risk_description", nBA_Agwy.RISK_ID);
            ViewBag.SEMESTER_ID = new SelectList(db.NBA_SemesterMaintenance, "SEMESTER_ID", "semester_name", nBA_Agwy.SEMESTER_ID);
            ViewBag.ID = new SelectList(db.NBA_PR, "ID", "PR_SR_ID", nBA_Agwy.ID);
            return View(nBA_Agwy);
        }



     
       



        // GET: NBA_ManageBeneficiaries/Edit/5
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
            ViewBag.higest_grade_passed = new SelectList(db.NBA_Grade, "Grade_ID", "Description", nBA_Agwy.higest_grade_passed);
            ViewBag.HighSchoolQuizz_ID = new SelectList(db.NBA_HighSchoolQuizz, "HighSchoolQuiz_ID", "Description", nBA_Agwy.HighSchoolQuizz_ID);
            ViewBag.type_of_identification = new SelectList(db.NBA_Identification, "Identification_ID", "Description", nBA_Agwy.type_of_identification);
            ViewBag.messageInquiry = new SelectList(db.NBA_MessageID, "MessageID", "Description", nBA_Agwy.messageInquiry);
            ViewBag.currrent_occupation = new SelectList(db.NBA_Occupation, "Occupation_ID", "Description", nBA_Agwy.currrent_occupation);
            ViewBag.RISK_ID = new SelectList(db.NBA_RiskAssessment, "RISK_ID", "risk_description", nBA_Agwy.RISK_ID);
            ViewBag.SEMESTER_ID = new SelectList(db.NBA_SemesterMaintenance, "SEMESTER_ID", "semester_name", nBA_Agwy.SEMESTER_ID);
            ViewBag.ID = new SelectList(db.NBA_PR, "ID", "PR_SR_ID", nBA_Agwy.ID);
            return View(nBA_Agwy);
        }

        // POST: NBA_ManageBeneficiaries/Edit/5
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
            ViewBag.higest_grade_passed = new SelectList(db.NBA_Grade, "Grade_ID", "Description", nBA_Agwy.higest_grade_passed);
            ViewBag.HighSchoolQuizz_ID = new SelectList(db.NBA_HighSchoolQuizz, "HighSchoolQuiz_ID", "Description", nBA_Agwy.HighSchoolQuizz_ID);
            ViewBag.type_of_identification = new SelectList(db.NBA_Identification, "Identification_ID", "Description", nBA_Agwy.type_of_identification);
            ViewBag.messageInquiry = new SelectList(db.NBA_MessageID, "MessageID", "Description", nBA_Agwy.messageInquiry);
            ViewBag.currrent_occupation = new SelectList(db.NBA_Occupation, "Occupation_ID", "Description", nBA_Agwy.currrent_occupation);
            ViewBag.RISK_ID = new SelectList(db.NBA_RiskAssessment, "RISK_ID", "risk_description", nBA_Agwy.RISK_ID);
            ViewBag.SEMESTER_ID = new SelectList(db.NBA_SemesterMaintenance, "SEMESTER_ID", "semester_name", nBA_Agwy.SEMESTER_ID);
            ViewBag.ID = new SelectList(db.NBA_PR, "ID", "PR_SR_ID", nBA_Agwy.ID);
            return View(nBA_Agwy);
        }

        // GET: NBA_ManageBeneficiaries/Delete/5
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

        // POST: NBA_ManageBeneficiaries/Delete/5
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
