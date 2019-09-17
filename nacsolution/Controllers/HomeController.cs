using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using nacsolution.Models;

namespace nacsolution.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        ////public ActionResult GetPR()

        ////{
        ////    using(nlbdataEntities dc = new nlbdataEntities ())
        ////    {
        ////        var pr = dc.NBA_Area.OrderBy(a => a.pr_name).ToList();
        ////        return Json(new { data = pr }, JsonRequestBehavior.AllowGet);


        ////    }
        ////}

        /// </summary>
        /// <returns></returns>
        ////public ActionResult GetPRSR()

        ////  {


        ////      using (nlbdataEntities dc = new nlbdataEntities())
        ////      {
        ////          var pr = dc.NBA_PR.OrderBy(a => a.ID).ToList();
        ////          return Json(new { data = pr }, JsonRequestBehavior.AllowGet);


        ////      }
        ////  
        [Authorize]
        public ActionResult ManageGirls()

        {

            return View();
        }
        [Authorize]
        public ActionResult GetGirls()

        {
            using (nlbdataEntities1 dc = new nlbdataEntities1())
            {
                var pr = dc.NBA_Agwy.OrderBy(a => a.name).ToList();
                return Json(new { data = pr }, JsonRequestBehavior.AllowGet);



            }
        }


                [HttpGet]
        public ActionResult Save(int id)
        {
            using (nlbdataEntities1 dc = new nlbdataEntities1())
            {
                var v = dc.NBA_Agwy.Where(a => a.AGWY_ID == id).FirstOrDefault();
                return View(v);
            }
        }


        [HttpPost]
        public ActionResult Save(NBA_Agwy emp)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                using (nlbdataEntities1 dc = new nlbdataEntities1())
                {
                    if (emp.AGWY_ID > 0)
                    {
                        //Edit 
                        var v = dc.NBA_Agwy.Where(a => a.AGWY_ID == emp.AGWY_ID).FirstOrDefault();
                        if (v != null)
                        {
                            v.name = emp.name;
                            v.surname = emp.surname;
                            v.known_as = emp.known_as;
                            v.gender = emp.gender;
                            v.age = emp.age;
                            v.type_of_identification = emp.type_of_identification;
                            v.idno = emp.idno;
                            v.dateOfbirth = emp.dateOfbirth;
                            v.town_village_address = emp.town_village_address;
                            v.maiden_name = emp.maiden_name;
                            v.street_name = emp.street_name;
                            v.town_village = emp.town_village;
                            v.uic = emp.uic;


                        }
                    }

                    else
                    {
                        //Save
                        dc.NBA_Agwy.Add(emp);
                    }
                    dc.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (nlbdataEntities1 dc = new nlbdataEntities1())
            {
                var v = dc.NBA_Agwy.Where(a => a.AGWY_ID == id).FirstOrDefault();
                if (v != null)
                {
                    return View(v);
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }


        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteEmployee(int id)
        {
            bool status = false;
            using (nlbdataEntities1 dc = new nlbdataEntities1())
            {
                var v = dc.NBA_Agwy.Where(a => a.AGWY_ID == id).FirstOrDefault();
                if (v != null)
                {
                    dc.NBA_Agwy.Remove(v);
                    dc.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }


    }
}