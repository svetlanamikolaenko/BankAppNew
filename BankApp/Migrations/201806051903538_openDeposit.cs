namespace BankApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class openDeposit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OpenDeposits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                        Amount = c.Double(nullable: false),
                        DepositId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Deposits", t => t.DepositId, cascadeDelete: true)
                .Index(t => t.ClientId)
                .Index(t => t.DepositId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OpenDeposits", "DepositId", "dbo.Deposits");
            DropForeignKey("dbo.OpenDeposits", "ClientId", "dbo.Clients");
            DropIndex("dbo.OpenDeposits", new[] { "DepositId" });
            DropIndex("dbo.OpenDeposits", new[] { "ClientId" });
            DropTable("dbo.OpenDeposits");
        }
    }
}
