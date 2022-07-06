namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig_sanirimartikoldu : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Iceriks", "IcerikAciklamasi", c => c.String());
            DropColumn("dbo.Iceriks", "Aciklama");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Iceriks", "Aciklama", c => c.String());
            DropColumn("dbo.Iceriks", "IcerikAciklamasi");
        }
    }
}
