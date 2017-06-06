using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IocCotainerWeb.Interfaces;

namespace IocCotainerWeb.Models
{
	public class IndexModel:IIndex
	{
		
			public int ID { get; set; }
			public string Description { get; set; }
			public string Comments { get; set; }
		
	}
}