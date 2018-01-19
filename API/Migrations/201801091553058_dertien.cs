namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dertien : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.Status", "OperatorLiId", "dbo.Operators");
            //DropForeignKey("dbo.Status", "Operator_Id", "dbo.Operators");
            //DropForeignKey("dbo.Status", "LineInspector_Id", "dbo.LineInspectors");
            //DropIndex("dbo.Status", new[] { "OperatorId" });
            //DropIndex("dbo.Status", new[] { "OperatorLiId" });
            //DropIndex("dbo.Status", new[] { "Operator_Id" });
            //DropIndex("dbo.Status", new[] { "LineInspector_Id" });
            //DropColumn("dbo.Status", "OperatorId");
            //RenameColumn(table: "dbo.Status", name: "Operator_Id", newName: "OperatorId");
            //RenameColumn(table: "dbo.Status", name: "LineInspector_Id", newName: "LiId");
            //AlterColumn("dbo.Status", "OperatorId", c => c.Guid(nullable: false));
            //AlterColumn("dbo.Status", "LiId", c => c.Guid(nullable: false));
            //CreateIndex("dbo.Status", "OperatorId");
            //CreateIndex("dbo.Status", "LiId");
            //AddForeignKey("dbo.Status", "OperatorId", "dbo.Operators", "Id", cascadeDelete: true);
            //AddForeignKey("dbo.Status", "LiId", "dbo.LineInspectors", "Id", cascadeDelete: true);
            //DropColumn("dbo.Status", "OperatorLiId");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.Status", "OperatorLiId", c => c.Guid(nullable: false));
            //DropForeignKey("dbo.Status", "LiId", "dbo.LineInspectors");
            //DropForeignKey("dbo.Status", "OperatorId", "dbo.Operators");
            //DropIndex("dbo.Status", new[] { "LiId" });
            //DropIndex("dbo.Status", new[] { "OperatorId" });
            //AlterColumn("dbo.Status", "LiId", c => c.Guid());
            //AlterColumn("dbo.Status", "OperatorId", c => c.Guid());
            //RenameColumn(table: "dbo.Status", name: "LiId", newName: "LineInspector_Id");
            //RenameColumn(table: "dbo.Status", name: "OperatorId", newName: "Operator_Id");
            //AddColumn("dbo.Status", "OperatorId", c => c.Guid(nullable: false));
            //CreateIndex("dbo.Status", "LineInspector_Id");
            //CreateIndex("dbo.Status", "Operator_Id");
            //CreateIndex("dbo.Status", "OperatorLiId");
            //CreateIndex("dbo.Status", "OperatorId");
            //AddForeignKey("dbo.Status", "LineInspector_Id", "dbo.LineInspectors", "Id");
            //AddForeignKey("dbo.Status", "Operator_Id", "dbo.Operators", "Id");
            //AddForeignKey("dbo.Status", "OperatorLiId", "dbo.Operators", "Id", cascadeDelete: true);
        }
    }
}
