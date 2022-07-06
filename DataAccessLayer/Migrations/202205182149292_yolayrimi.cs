namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yolayrimi : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Blogs", "UserID", "dbo.Users");
            DropIndex("dbo.Blogs", new[] { "UserID" });
            RenameColumn(table: "dbo.Blogs", name: "UserID", newName: "User_UserID");
            AddColumn("dbo.Blogs", "OlusturanKisi", c => c.String());
            AlterColumn("dbo.Blogs", "User_UserID", c => c.Int());
            CreateIndex("dbo.Blogs", "User_UserID");
            AddForeignKey("dbo.Blogs", "User_UserID", "dbo.Users", "UserID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Blogs", "User_UserID", "dbo.Users");
            DropIndex("dbo.Blogs", new[] { "User_UserID" });
            AlterColumn("dbo.Blogs", "User_UserID", c => c.Int(nullable: false));
            DropColumn("dbo.Blogs", "OlusturanKisi");
            RenameColumn(table: "dbo.Blogs", name: "User_UserID", newName: "UserID");
            CreateIndex("dbo.Blogs", "UserID");
            AddForeignKey("dbo.Blogs", "UserID", "dbo.Users", "UserID", cascadeDelete: true);
        }
    }
}
