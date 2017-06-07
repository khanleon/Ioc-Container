using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IocContainer.Attributes;
using IocContainer.Core;

//using IocCotainerWeb.Models;
using IocCotainerWeb.Interfaces;

namespace IocCotainerWeb.Controllers
{
    public class IndexController : Controller
    {

		private IIndex _index;
		    

    public IndexController(IIndex _index)
    {
        this._index = _index;
    }


        // GET: Index
		public ActionResult Index()
        {

			
			
			List<IIndex> newList = new List<IIndex>();
			

			
			
            return View(newList);
        }
    }
}