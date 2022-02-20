namespace EnverSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyAnnotationsToCompanyInfo : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CompanyInfoes", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.CompanyInfoes", "PhoneNumber", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CompanyInfoes", "PhoneNumber", c => c.String());
            AlterColumn("dbo.CompanyInfoes", "Name", c => c.String());
        }
    }
}
