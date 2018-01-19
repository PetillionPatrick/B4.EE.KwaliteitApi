namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class twaalf : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Status", "OrderId", "dbo.Orders");
            AddForeignKey("dbo.Status", "OrderId", "dbo.Orders", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Status", "OrderId", "dbo.Orders");
            AddForeignKey("dbo.Status", "OrderId", "dbo.Orders", "Id", cascadeDelete: true);
        }
    }
}
