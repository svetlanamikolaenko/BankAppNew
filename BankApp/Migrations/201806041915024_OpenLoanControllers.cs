namespace BankApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OpenLoanControllers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "FullName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clients", "FullName");
        }
    }
}
