namespace KateFordLedger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addFkTransactionBankBank : DbMigration
    {
        public override void Up()
        {
 
            AddForeignKey("dbo.Transactions", "BankAccount_BankAccountId", "dbo.BankAccounts", "bankAccountId", cascadeDelete: true);
            CreateIndex("dbo.Transactions",  "BankAccount_BankAccountId");
 
        }
        
        public override void Down()
        {

            DropForeignKey("dbo.Transactions", "BankAccount_BankAccountId", "dbo.BankAccounts");
            DropIndex("dbo.Transactions", new[] { "BankAccount_BankAccountId" });
 
        }
    }
}
