namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vijf : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Status", "OrderId", "dbo.Orders");
            DropIndex("dbo.Status", new[] { "OrderId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Status", "OrderId");
            AddForeignKey("dbo.Status", "OrderId", "dbo.Orders", "Id");
        }
    }
}
