namespace DAL
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;
	using System.Collections.Generic;
	using Models.DB;

	public class MainContext : DbContext
	{
		public MainContext()
			: base("DefaultConnection")
		{
		}

		public virtual DbSet<books> books { get; set; }
		public virtual DbSet<purchases> purchases { get; set; }
		public virtual DbSet<discount> discount { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<books>()
				.HasMany(e => e.purchases)
				.WithRequired(e => e.books)
				.HasForeignKey(e => e.bookId)
				.WillCascadeOnDelete(false);

			//modelBuilder.Entity<discount>()
			//	.HasMany(d => d.purchases)
			//	.WithRequired(p => p.discount)
			//	.HasForeignKey(p => p.discountId)
			//	.WillCascadeOnDelete(false);

			modelBuilder.Entity<purchases>()
				.HasRequired(p => p.discount)
				.WithMany(d => d.purchases)
				.HasForeignKey(p => p.discountId);
		}
	}
}
