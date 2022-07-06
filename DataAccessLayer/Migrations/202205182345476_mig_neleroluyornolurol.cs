namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_neleroluyornolurol : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "ZiyaretciAdi");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "ZiyaretciAdi", c => c.Binary());
        }
    }
}
