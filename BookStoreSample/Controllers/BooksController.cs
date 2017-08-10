using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.Interfaces;
using Models.DTO;
using System.Threading.Tasks;
using Models.DB;
using AutoMapper;

namespace BookStoreSample.Controllers
{
    public class BooksController : ApiController
    {
		private readonly IBooksManager booksManager;

		
		public BooksController(IBooksManager manager)
		{
			booksManager = manager;
		}
		/// <summary>
		/// Get all books table records
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public IHttpActionResult GetAllBooks()
		{
			return Json(booksManager.GetAllBooks());
		}

		/// <summary>
		/// Get book by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet]
		public async Task<IHttpActionResult> GetBook(int id)
		{
			return Json(await booksManager.Get<books, BooksDTO>(id));
		}

		/// <summary>
		/// Post single book
		/// </summary>
		/// <param name="book"></param>
		/// <returns></returns>
		[HttpPost]
		public async Task<IHttpActionResult> PostBook(BooksDTO book)
		{
			return Json(await booksManager.Add<books, BooksDTO>(book, (db, dto) => dto.id = db.id));
		}

		/// <summary>
		/// Post multiple books
		/// </summary>
		/// <param name="books"></param>
		/// <returns></returns>
		[HttpPost]
		public async Task<IHttpActionResult> PostBooks(IEnumerable<BooksDTO> books)
		{
			return Json(await booksManager.PostBooks(books));
		}

		/// <summary>
		/// Update a book
		/// </summary>
		/// <param name="book"></param>
		/// <returns></returns>
		[HttpPut]
		public async Task<IHttpActionResult> PutBook(BooksDTO book)
		{
			await booksManager.Update<books, BooksDTO>(book, b => b.id);
			return Ok();
		}

		/// <summary>
		/// Remove book by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpDelete]
		public async Task<IHttpActionResult> DeleteBook(int id)
		{
			await booksManager.Delete<books>(id);
			return Ok();
		}


		[HttpGet]
		public IHttpActionResult GetAllPurchases()
		{
			return Json(booksManager.GetAllPurchases());
		}

		[HttpGet]
		public async Task<IHttpActionResult> GetPurchase(int id)
		{
			return Json(await booksManager.Get<purchases, PurchasesDTO>(id));
		}

		[HttpDelete]
		public async Task<IHttpActionResult> DeletePurchase(int id)
		{
			await booksManager.Delete<purchases>(id);
			return Ok();
		}

		/// <summary>
		/// Post purchase
		/// </summary>
		/// <param name="purchase"></param>
		/// <returns></returns>
		[HttpPost]
		public async Task<IHttpActionResult> PostPurchase(PurchasesDTO purchase)
		{
			return Json(await booksManager.BuyBook(purchase));
		}

		/// <summary>
		/// Get all discount records
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public IHttpActionResult GetAllDiscounts()
		{
			return Json(booksManager.GetAllDiscounts());
		}

		[HttpGet]
		public async Task<IHttpActionResult> GetDiscount(int id)
		{
			return Json(await booksManager.Get<discount, DiscountDTO>(id));
		}

		[HttpPost]
		public async Task<IHttpActionResult> PostDiscount(DiscountDTO discountItem)
		{
			if (discountItem.percentage >= 0 && discountItem.percentage <= 100)
				return Json(await booksManager.Add<discount, DiscountDTO>(discountItem, (db, dto) => dto.id = db.id));
			
			return Json(false);
		}

		[HttpPut]
		public async Task<IHttpActionResult> PutDiscount(DiscountDTO discountItem)
		{
			if (discountItem.percentage >= 0 && discountItem.percentage <= 100)
			{
				await booksManager.Update<discount, DiscountDTO>(discountItem, d => d.id);
				return Ok();
			}
			return Json(false);
		}

		[HttpDelete]
		public async Task<IHttpActionResult> DeleteDiscount(int id)
		{
			await booksManager.Delete<discount>(id);
			return Ok();
		}

    }

	
}
