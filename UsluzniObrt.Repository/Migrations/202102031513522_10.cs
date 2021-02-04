namespace UsluzniObrt.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _10 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MenuItems", "CategoryId", "dbo.Categories");
            DropIndex("dbo.MenuItems", new[] { "CategoryId" });
            AlterColumn("dbo.MenuItems", "CategoryId", c => c.Int());
            CreateIndex("dbo.MenuItems", "CategoryId");
            AddForeignKey("dbo.MenuItems", "CategoryId", "dbo.Categories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MenuItems", "CategoryId", "dbo.Categories");
            DropIndex("dbo.MenuItems", new[] { "CategoryId" });
            AlterColumn("dbo.MenuItems", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.MenuItems", "CategoryId");
            AddForeignKey("dbo.MenuItems", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
    }
}
