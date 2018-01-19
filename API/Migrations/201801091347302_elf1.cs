namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class elf1 : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.Status", "OperatorLiId", "dbo.Operators");
            //DropForeignKey("dbo.Status", "OrderId", "dbo.Orders");
            //DropForeignKey("dbo.Status", "OperatorId", "dbo.Operators");
            //CreateTable(
            //    "dbo.LineInspectors",
            //    c => new
            //        {
            //            Id = c.Guid(nullable: false),
            //            Nummer = c.String(),
            //            Naam = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //AddColumn("dbo.Status", "Operator_Id", c => c.Guid());
            //AddColumn("dbo.Status", "LineInspector_Id", c => c.Guid());
            //CreateIndex("dbo.Status", "Operator_Id");
            //CreateIndex("dbo.Status", "LineInspector_Id");
            //AddForeignKey("dbo.Status", "LineInspector_Id", "dbo.LineInspectors", "Id");
            //AddForeignKey("dbo.Status", "OperatorLiId", "dbo.Operators", "Id", cascadeDelete: true);
            //AddForeignKey("dbo.Status", "OrderId", "dbo.Orders", "Id", cascadeDelete: true);
            //AddForeignKey("dbo.Status", "Operator_Id", "dbo.Operators", "Id");
            //DropColumn("dbo.Operators", "LineInspector");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.Operators", "LineInspector", c => c.Boolean(nullable: false));
            //DropForeignKey("dbo.Status", "Operator_Id", "dbo.Operators");
            //DropForeignKey("dbo.Status", "OrderId", "dbo.Orders");
            //DropForeignKey("dbo.Status", "OperatorLiId", "dbo.Operators");
            //DropForeignKey("dbo.Status", "LineInspector_Id", "dbo.LineInspectors");
            //DropIndex("dbo.Status", new[] { "LineInspector_Id" });
            //DropIndex("dbo.Status", new[] { "Operator_Id" });
            //DropColumn("dbo.Status", "LineInspector_Id");
            //DropColumn("dbo.Status", "Operator_Id");
            //DropTable("dbo.LineInspectors");
            //AddForeignKey("dbo.Status", "OperatorId", "dbo.Operators", "Id", cascadeDelete: true);
            //AddForeignKey("dbo.Status", "OrderId", "dbo.Orders", "Id");
            //AddForeignKey("dbo.Status", "OperatorLiId", "dbo.Operators", "Id");
        }
    }
}
