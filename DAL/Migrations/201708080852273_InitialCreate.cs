namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.books",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        author = c.String(),
                        name = c.String(nullable: false),
                        price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.purchases",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        customer = c.String(nullable: false),
                        customerAddress = c.String(),
                        bookId = c.Int(nullable: false),
                        dt_purchased = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.books", t => t.bookId)
                .Index(t => t.bookId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.purchases", "bookId", "dbo.books");
            DropIndex("dbo.purchases", new[] { "bookId" });
            DropTable("dbo.purchases");
            DropTable("dbo.books");
        }
    }
}
