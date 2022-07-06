namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_geridonusuolmayanyollar : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "ZiyaretciAdi", c => c.Binary());
            AddColumn("dbo.Users", "ZiyaretciPasswordHash", c => c.Binary());
            AddColumn("dbo.Users", "ZiyaretciPasswordSalt", c => c.Binary());
            DropColumn("dbo.Users", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Password", c => c.String(maxLength: 250));
            DropColumn("dbo.Users", "ZiyaretciPasswordSalt");
            DropColumn("dbo.Users", "ZiyaretciPasswordHash");
            DropColumn("dbo.Users", "ZiyaretciAdi");
        }
    }
}
