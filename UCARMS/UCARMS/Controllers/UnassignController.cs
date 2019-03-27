using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UCARMS.Controllers
{
	public class UnassignController : Controller
	{
		//
		// GET: /UnassignCourses/
		public ActionResult UnassignCourses()
		{
			return View();
		}

		public ActionResult UnallocateClassRooms()
		{
			return View();
		}
	}
}