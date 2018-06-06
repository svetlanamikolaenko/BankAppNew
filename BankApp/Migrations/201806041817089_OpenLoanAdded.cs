namespace BankApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OpenLoanAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OpenLoans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                        Amount = c.Double(nullable: false),
                        LoanId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Loans", t => t.LoanId, cascadeDelete: true)
                .Index(t => t.ClientId)
                .Index(t => t.LoanId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OpenLoans", "LoanId", "dbo.Loans");
            DropForeignKey("dbo.OpenLoans", "ClientId", "dbo.Clients");
            DropIndex("dbo.OpenLoans", new[] { "LoanId" });
            DropIndex("dbo.OpenLoans", new[] { "ClientId" });
            DropTable("dbo.OpenLoans");
        }
    }
}
