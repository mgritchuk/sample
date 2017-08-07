using Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStoreSample.Controllers
{
	public class HomeController : Controller
	{
		MainContext db = new MainContext();


		public ActionResult Index()
		{
			IEnumerable<books> books = db.books.ToList();
			ViewBag.books = books;

			return View();
		}

	}
}