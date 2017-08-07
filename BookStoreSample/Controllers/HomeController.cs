using System;
using Models.DB;
using Models.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interfaces;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace BookStoreSample.Controllers
{
	public class HomeController : Controller
	{

		public async Task<ActionResult> Index()
		{
			ViewBag.books = new List<BooksDTO>();
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri("http://localhost:57707");
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				var response = client.GetAsync("api/Books/GetAllBooks").Result;
				if (response.IsSuccessStatusCode)
				{
					ViewBag.books = JsonConvert.DeserializeObject<IEnumerable<BooksDTO>>(await response.Content.ReadAsStringAsync());
				}
			}

			//IEnumerable<BooksDTO> books = bookManager.GetAllBooks();
			//ViewBag.books = books;

			return View();
		}

	}
}