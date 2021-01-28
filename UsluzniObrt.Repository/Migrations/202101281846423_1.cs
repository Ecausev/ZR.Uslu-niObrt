namespace UsluzniObrt.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderItems", "Order_Id", "dbo.Orders");
            DropIndex("dbo.OrderItems", new[] { "Order_Id" });
            RenameColumn(table: "dbo.OrderItems", name: "Order_Id", newName: "OrderId");
            DropPrimaryKey("dbo.OrderItems");
            AlterColumn("dbo.OrderItems", "OrderId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.OrderItems", new[] { "OrderId", "MenuItemId" });
            CreateIndex("dbo.OrderItems", "OrderId");
            AddForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders", "Id", cascadeDelete: true);
            DropColumn("dbo.OrderItems", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderItems", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders");
            DropIndex("dbo.OrderItems", new[] { "OrderId" });
            DropPrimaryKey("dbo.OrderItems");
            AlterColumn("dbo.OrderItems", "OrderId", c => c.Int());
            AddPrimaryKey("dbo.OrderItems", "Id");
            RenameColumn(table: "dbo.OrderItems", name: "OrderId", newName: "Order_Id");
            CreateIndex("dbo.OrderItems", "Order_Id");
            AddForeignKey("dbo.OrderItems", "Order_Id", "dbo.Orders", "Id");
        }
    }
}
