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
			
			IContainer container = new IocContainer.Container();
			container.RegisterInstanceType<IIndex, IndexModel>();
			IIndex indexModel = container.Resolve<IIndex>();
			container.RegisterInstanceType<IIndex, IndexModel>();
			IIndex indexModel2 = container.Resolve<IIndex>();

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
				url: "{controller}/{action}/{index}/{index2}",
				defaults: new { controller = "Index", action = "Index", index = indexModel, index2 = indexModel2 }//id = UrlParameter.Optional
            );

			
        }
    }
}
