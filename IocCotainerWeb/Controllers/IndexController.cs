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
		private IIndex _index2;


        // GET: Index
		public ActionResult Index(IIndex index, IIndex index2)
        {

			this._index = index;
			index.ID = 1;
			index.Description = "First Item";
			index.Comments = "This is the first instance of the model";
			
			List<IIndex> newList = new List<IIndex>();
			

			newList.Add(index);
			this._index2 = index2;		
			index2.ID = 2;
			index2.Description = "Second Item";
			index2.Comments = "This is the Second instance of the model";
			newList.Add(index2);
            return View(newList);
        }
    }
}