using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using IocCotainerWeb.Models;
using IocCotainerWeb.Interfaces;
using IocContainer.Attributes;
using IocContainer.Core;
using IocCotainerWeb.Controllers;


namespace IocCotainerWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
					

        }
    }
}
