using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.DTO;

namespace BLL.Interfaces
{
	public interface IBooksManager : IBaseManager
	{

		Task<PurchasesDTO> BuyBook(PurchasesDTO purchase);

		IEnumerable<BooksDTO> GetAllBooks();
		IEnumerable<DiscountDTO> GetAllDiscounts();

	}
}
