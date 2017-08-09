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
using System.Text;

namespace BookStoreSample.Controllers
{
	public class HomeController : Controller
	{
		private readonly Uri apiUri = new Uri("http://localhost:57707");
		
		public async Task<ActionResult> Index()
		{
			ViewBag.books = new List<BooksDTO>();
			using (var client = new HttpClient())
			{
				client.BaseAddress = apiUri;
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				var response = client.GetAsync("api/Books/GetAllBooks").Result;
				if (response.IsSuccessStatusCode)
				{
					ViewBag.books = JsonConvert.DeserializeObject<IEnumerable<BooksDTO>>(await response.Content.ReadAsStringAsync());
				}
				
				
			}
			return View();
		}

		[HttpGet]
		public async Task<ActionResult> Buy(int id)
		{
			ViewBag.BookId = id;
			List<DiscountDTO> discounts = new List<DiscountDTO>();
			using (var client = new HttpClient())
			{
				client.BaseAddress = apiUri;
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				var response = await client.GetAsync("api/Books/GetAllDiscounts");

				if (response.IsSuccessStatusCode)
				{
					discounts = JsonConvert.DeserializeObject<List<DiscountDTO>>(await response.Content.ReadAsStringAsync());
				}
			}
			ViewBag.Discounts = discounts;
			return View();
		}

		[HttpPost]
		public async Task<string> Buy(PurchasesDTO purchase)
		{
			purchase.dt_purchased = DateTime.Now;
			PurchasesDTO purchaseResult = null;
			using (var client = new HttpClient())
			{
				client.BaseAddress = apiUri;
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				StringContent content = new StringContent(JsonConvert.SerializeObject(purchase), Encoding.UTF8, "application/json");
				var response = await client.PostAsync("api/Books/PostPurchase", content);
				
				if (response.IsSuccessStatusCode)
				{
					purchaseResult  = JsonConvert.DeserializeObject<PurchasesDTO>(await response.Content.ReadAsStringAsync());
				}
			}
			return purchaseResult != null ? "Purchase succeed" : "Purchase failed";
		}
	}
}