using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.Interfaces;
using Models.DTO;
using System.Threading.Tasks;

namespace BookStoreSample.Controllers
{
    public class BooksController : ApiController
    {
		private readonly IBooksManager booksManager;

		
		public BooksController(IBooksManager manager)
		{
			booksManager = manager;
		}

		[HttpGet]
		public IHttpActionResult GetAllBooks()
		{
			return Json(booksManager.GetAllBooks());
		}
	
		[HttpPost]
		public async Task<IHttpActionResult> PostPurchase(PurchasesDTO purchase)
		{
			return Json(await booksManager.BuyBook(purchase));
		}

    }
}
