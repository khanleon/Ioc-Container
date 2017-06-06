using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IocCotainerWeb.Interfaces
{
	public interface IIndex
	{
		 int ID { get; set; }
		 string Description { get; set; }
		 string Comments { get; set; }
				
	}
}