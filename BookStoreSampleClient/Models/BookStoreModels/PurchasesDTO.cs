using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreSampleClient.Models.BookStoreModels
{
	public class PurchasesDTO
	{
		public PurchasesDTO() { }

		public PurchasesDTO(string customer, string customerAddress, int bookId)
		{
			this.customer = customer;
			this.customerAddress = customerAddress;
			this.bookId = bookId;
		}

		public int id { get; set; }

		public string customer { get; set; }

		public string customerAddress { get; set; }

		public int bookId { get; set; }

		public int discountId { get; set; }

		public DateTime dt_purchased { get; set; }

	}
}
