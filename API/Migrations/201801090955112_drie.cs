namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class drie : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.Status", "Order_Id", "dbo.Orders");
            //DropIndex("dbo.Status", new[] { "Order_Id" });
            //RenameColumn(table: "dbo.Status", name: "Order_Id", newName: "OrderId");
            //AlterColumn("dbo.Status", "OrderId", c => c.Guid(nullable: false));
            //CreateIndex("dbo.Status", "OrderId");
            //AddForeignKey("dbo.Status", "OrderId", "dbo.Orders", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.Status", "OrderId", "dbo.Orders");
            //DropIndex("dbo.Status", new[] { "OrderId" });
            //AlterColumn("dbo.Status", "OrderId", c => c.Guid());
            //RenameColumn(table: "dbo.Status", name: "OrderId", newName: "Order_Id");
            //CreateIndex("dbo.Status", "Order_Id");
            //AddForeignKey("dbo.Status", "Order_Id", "dbo.Orders", "Id");
        }
    }
}
