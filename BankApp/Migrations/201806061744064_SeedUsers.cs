namespace BankApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'1bfd0fcc-0ad2-4944-a4fe-2e9e488c275e', N'manager@mvcbank.com', 0, N'AADCCybV/lhRDxFDfxzZNqC5tqkVEcSHb5tVib4ER+6IY4jniNVmEKUfPZhw3Pjo3g==', N'44fbbdf6-be9a-4f40-94e4-4acd939ef70f', NULL, 0, 0, NULL, 1, 0, N'manager@mvcbank.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'6d92c8fa-7c06-4f83-a617-b523be205cc8', N'administrator@mvcbank.com', 0, N'AEThvRVVUd7AH7vAzSwxfPrtqSA732Qo55TizyMbQSVghz2UISrfaGTn0cn17M+GwA==', N'00066fe8-c932-4e41-a2df-8dc6b9cb44d7', NULL, 0, 0, NULL, 1, 0, N'administrator@mvcbank.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'e2c94bab-8a03-45f6-ba4d-10cd1467a985', N'Administrator')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'6d92c8fa-7c06-4f83-a617-b523be205cc8', N'e2c94bab-8a03-45f6-ba4d-10cd1467a985')

");
        }
        
        public override void Down()
        {
        }
    }
}
