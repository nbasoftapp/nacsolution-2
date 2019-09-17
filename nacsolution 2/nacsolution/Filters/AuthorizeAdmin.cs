﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nacsolution.Filters

{

    public class AutorizeAdmin : System.Web.Mvc.ActionFilterAttribute, System.Web.Mvc.IActionFilter

    {

        public override void OnActionExecuting(System.Web.Mvc.ActionExecutingContext filterContext)

        {

            if (HttpContext.Current.Session["AdminIsLogedIn"] == null)

            {

                filterContext.Result = new System.Web.Mvc.RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary

                {

                    {"Controller", "Account"},

                    {"Action", "Login"}

                });

            }

            base.OnActionExecuting(filterContext);

        }

    }
}