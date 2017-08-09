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

		public IEnumerable<DiscountDTO> GetAllDiscounts()
		{
			return Mapper.Map<List<discount>, List<DiscountDTO>>(context.discount.ToList());
		}
	}
}
