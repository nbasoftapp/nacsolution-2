﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace nacsolution.Controllers
{
  
    public class SAdminProfileController : Controller
    {
        [Filters.AutorizeAdmin]

        // GET: AdminProfile
        public ActionResult Index()

        {


            return View();

        }

        public ActionResult Index2()

        {

            return View();

        }


        public ActionResult Index3()

        {

            return View();

        }
    }
}