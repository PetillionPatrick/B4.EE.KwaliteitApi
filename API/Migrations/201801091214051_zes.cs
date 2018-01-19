namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class zes : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Status", "OrderId");
            AddForeignKey("dbo.Status", "OrderId", "dbo.Orders", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Status", "OrderId", "dbo.Orders");
            DropIndex("dbo.Status", new[] { "OrderId" });
        }
    }
}
