namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "UserTitle", c => c.String(maxLength: 100));
            AddColumn("dbo.Users", "UserAboutShort", c => c.String(maxLength: 100));
            AddColumn("dbo.Users", "Mail", c => c.String(maxLength: 300));
            AddColumn("dbo.Users", "Password", c => c.String(maxLength: 250));
            AddColumn("dbo.Users", "UserNo", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "UserNo");
            DropColumn("dbo.Users", "Password");
            DropColumn("dbo.Users", "Mail");
            DropColumn("dbo.Users", "UserAboutShort");
            DropColumn("dbo.Users", "UserTitle");
        }
    }
}
