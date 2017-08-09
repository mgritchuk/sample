namespace Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class purchases
    {
        public int id { get; set; }

        [Required]
        public string customer { get; set; }

        public string customerAddress { get; set; }

        public int bookId { get; set; }

		public int discountId { get; set; }

		public DateTime dt_purchased { get; set; }

		[ForeignKey("bookId")]
		public virtual books books { get; set; }

		[ForeignKey("discountId")]
		public virtual discount discount { get; set; }
	}
}
