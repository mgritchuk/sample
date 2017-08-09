namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDiscountTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.discount",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        percentage = c.Int(nullable: false),
                        description = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.purchases", "discountId", c => c.Int(nullable: false));
            CreateIndex("dbo.purchases", "discountId");
            AddForeignKey("dbo.purchases", "discountId", "dbo.discount", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.purchases", "discountId", "dbo.discount");
            DropIndex("dbo.purchases", new[] { "discountId" });
            DropColumn("dbo.purchases", "discountId");
            DropTable("dbo.discount");
        }
    }
}
