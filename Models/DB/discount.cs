using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DB
{
	public class discount
	{

		public int id { get; set; }

		public int percentage { get; set; }

		public string description { get; set; }

		public virtual purchases purchase { get; set; }
	}
}
