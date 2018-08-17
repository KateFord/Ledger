namespace KateFordLedger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bankAccount : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BankAccounts",
                c => new
                {
                    BankAccountId = c.Guid(nullable: false),
                    BankAccountNumber = c.Int(nullable: false),
                    BankAccountDateCreated = c.DateTimeOffset(nullable: false, precision: 7),
                    BankAccountType = c.Int(nullable: false),
                    BankAccountBalance = c.Decimal(nullable: false, precision: 18, scale: 2),
                    User_Id = c.String(maxLength: 128),
                })
                .PrimaryKey(t => t.BankAccountId)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BankAccounts", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.BankAccounts", new[] { "User_Id" });
            DropTable("dbo.BankAccounts");
        }
    }
}
