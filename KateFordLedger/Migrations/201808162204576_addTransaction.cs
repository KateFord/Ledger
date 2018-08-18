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
                .PrimaryKey(t => t.TransactionId);
                
        }

        public override void Down()
        {
              DropTable("dbo.Transactions");
        }
    }
}
