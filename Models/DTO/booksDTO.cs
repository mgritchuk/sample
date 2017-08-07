using Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
	public class BooksDTO
	{
		public BooksDTO() { }

		public BooksDTO(string author, string name, int price)
		{
			this.author = author;
			this.name = name;
			this.price = price;
		}
		
		public int id { get; set; }

		public string author { get; set; }

		public string name { get; set; }

		public int price { get; set; }
	}
}
