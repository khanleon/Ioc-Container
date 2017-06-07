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
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
			
			var container = new IocContainer.Container();
			
			container.RegisterInstanceType<IndexController, IndexController>();

			container.RegisterInstanceType<IIndex, IndexModel>();
			ControllerBuilder.Current.SetControllerFactory(new SimpleIocController(container));
			

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Index", action = "Index", id = UrlParameter.Optional }//
            );

			
        }
    }
}
