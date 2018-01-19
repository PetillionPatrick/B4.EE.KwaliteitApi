namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class elf : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Status", "OperatorLiId", "dbo.Operators");
            DropForeignKey("dbo.Status", "OrderId", "dbo.Orders");
            AddForeignKey("dbo.Status", "OperatorLiId", "dbo.Operators", "Id");
            AddForeignKey("dbo.Status", "OrderId", "dbo.Orders", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Status", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Status", "OperatorLiId", "dbo.Operators");
            AddForeignKey("dbo.Status", "OrderId", "dbo.Orders", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Status", "OperatorLiId", "dbo.Operators", "Id", cascadeDelete: true);
        }
    }
}
