namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class guncelllllleme : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Blogs", "User_UserID", "dbo.Users");
            DropIndex("dbo.Blogs", new[] { "User_UserID" });
            RenameColumn(table: "dbo.Blogs", name: "User_UserID", newName: "UserID");
            AlterColumn("dbo.Blogs", "UserID", c => c.Int(nullable: false));
            CreateIndex("dbo.Blogs", "UserID");
            AddForeignKey("dbo.Blogs", "UserID", "dbo.Users", "UserID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Blogs", "UserID", "dbo.Users");
            DropIndex("dbo.Blogs", new[] { "UserID" });
            AlterColumn("dbo.Blogs", "UserID", c => c.Int());
            RenameColumn(table: "dbo.Blogs", name: "UserID", newName: "User_UserID");
            CreateIndex("dbo.Blogs", "User_UserID");
            AddForeignKey("dbo.Blogs", "User_UserID", "dbo.Users", "UserID");
        }
    }
}
