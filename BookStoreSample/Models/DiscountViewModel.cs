using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStoreSample.Models
{
	public class DiscountViewModel
	{
		public int id { get; set; }

		public int percentage { get; set; }

		public string description { get; set; }

		public SelectList DropDownList { get; set; }
	}
}