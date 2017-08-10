using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Models.DB;
using Models.DTO;
using System.Threading.Tasks;
using BLL.Interfaces;
using DAL;

namespace BLL.Managers
{
	public class BooksManager : BaseManager, IBooksManager
	{
		public BooksManager(MainContext context) : base(context)
		{ }

		public async Task<PurchasesDTO> BuyBook(PurchasesDTO purchase)
		{

			return await Add<purchases, PurchasesDTO>(purchase, (db, dto) => dto.id = db.id); 
		
		}

		public IEnumerable<BooksDTO> GetAllBooks()
		{
			return Mapper.Map<List<books>, List<BooksDTO>>( context.books.ToList());
		}

		public async Task<IEnumerable<BooksDTO>> PostBooks(IEnumerable<BooksDTO> books)
		{
			List<BooksDTO> result = new List<BooksDTO>();
			foreach(var book in books)
			{
				result.Add(await Add<books, BooksDTO>(book, (db, dto) => dto.id = db.id));
			}
			return result;
		}

		public IEnumerable<DiscountDTO> GetAllDiscounts()
		{
			return Mapper.Map<List<discount>, List<DiscountDTO>>(context.discount.ToList());
		}


		public IEnumerable<PurchasesDTO> GetAllPurchases()
		{
			return Mapper.Map<List<purchases>, List<PurchasesDTO>>(context.purchases.ToList());
		}
	}
}
