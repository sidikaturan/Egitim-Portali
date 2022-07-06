namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig_hakkimizdadegisiklikler : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Abouts", "AboutContent2");
            DropColumn("dbo.Abouts", "AboutImage2");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Abouts", "AboutImage2", c => c.String(maxLength: 100));
            AddColumn("dbo.Abouts", "AboutContent2", c => c.String(maxLength: 500));
        }
    }
}
