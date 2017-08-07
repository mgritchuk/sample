namespace DAL
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;
	using System.Collections.Generic;
	using Models.DB;

	public partial class MainContext : DbContext
	{
		public MainContext()
			: base("DefaultConnection")
		{
		}

		public virtual DbSet<books> books { get; set; }
		public virtual DbSet<purchases> purchases { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<books>()
				.HasMany(e => e.purchases)
				.WithRequired(e => e.books)
				.HasForeignKey(e => e.bookId)
				.WillCascadeOnDelete(false);
		}
	}
}
