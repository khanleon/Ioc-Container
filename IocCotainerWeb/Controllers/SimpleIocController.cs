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
using System;

namespace IocCotainerWeb.Controllers
{
    public class SimpleIocController  : DefaultControllerFactory 
    {
		 private IContainer container;

		 public SimpleIocController(IContainer container)
        {
            this.container = container;
			 
        }

		


       
    }
}
