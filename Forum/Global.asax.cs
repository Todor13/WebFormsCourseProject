﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Forum
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            // place the lower case on string, to avoid make it again later.
            string cTheLowerUrl = HttpContext.Current.Request.Path.ToLowerInvariant();
            if (cTheLowerUrl != HttpContext.Current.Request.Path)
            {
                HttpContext.Current.Response.Redirect(cTheLowerUrl + HttpContext.Current.Request.Url.Query);
            }
        }
    }
}