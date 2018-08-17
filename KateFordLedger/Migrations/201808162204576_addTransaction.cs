namespace KateFordLedger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTransaction : DbMigration
    {

        public override void Up()
        {
            CreateTable(
                "dbo.Transactions",
                c => new
                {
                    TransactionId = c.Guid(nullable: false),
                    TransactionDateCreated = c.DateTimeOffset(nullable: false, precision: 7),
                    TransactionType = c.Int(nullable: false),
                    TransactionAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    BankAccount_BankAccountId = c.Guid(),
                })
                .PrimaryKey(t => t.TransactionId)
                .ForeignKey("dbo.BankAccounts", t => t.BankAccount_BankAccountId, cascadeDelete: true)
                .Index(t => t.BankAccount_BankAccountId);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "BankAccount_BankAccountId", "dbo.BankAccounts");
            DropIndex("dbo.Transactions", new[] { "BankAccount_BankAccountId" });
            DropTable("dbo.Transactions");
        }
    }
}
