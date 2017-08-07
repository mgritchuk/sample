using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.Interfaces;
using Models.DTO;

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
		public IHttpActionResult PostPurchase(PurchasesDTO purchase)
		{
			return Json(booksManager.BuyBook(purchase));
		}

    }
}
