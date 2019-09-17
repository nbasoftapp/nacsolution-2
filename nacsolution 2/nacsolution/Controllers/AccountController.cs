using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace nacsolution.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()

        {

            if (Session["AdminIsLogedIn"] != null)

            {

                return RedirectToAction("index", "AdminProfile");

            }

            else

            {

                return View();

            }

        }


        [HttpPost]

        public ActionResult Login(string username, string password)

        {





            if (username == "admin" && password == "password123")

            {

                Session["AdminIsLogedIn"] = true;

                return RedirectToAction("index", "AdminProfile");

            }



            ViewBag.Error = "Wrong Username/Password";

            return View();

        }


        public ActionResult Logout()

        {

            Session["AdminIsLogedIn"] = null;

            return RedirectToAction("Login", "Account");

        }


    }
}