using System;
using System.ComponentModel.DataAnnotations;

namespace KateFordLedger.Models
{

    public enum TransactionType { Deposit = 0, Withdrawal = 1 }

    public class Transaction
    {
 
        [Key]
        public Guid TransactionId { get; set; }

        [Display(Name = "Transaction Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTimeOffset TransactionDateCreated { get; set; }

        [Display(Name = "Transaction Type")]
        public TransactionType TransactionType { get; set; }

        [Display(Name = "Amount")]
        [DataType(DataType.Currency)]
        [Range(0, (double)decimal.MaxValue, ErrorMessage = "Value should be between {1} and {2}.")]
        public decimal TransactionAmount { get; set; }

        public virtual BankAccount BankAccount { get; set; }

        /// Updates bank account balance when deposits and withdrawals are are
        /// created and deleted. 
        public void AdjustBankAccountBalance(string action)
        {
            if ((action.ToLower() == "create" && this.TransactionType.ToString().ToLower() == "deposit") ||
               (action.ToLower() == "delete" && this.TransactionType.ToString().ToLower() == "withdrawal"))
                this.BankAccount.BankAccountBalance += this.TransactionAmount;

            else if ((action.ToLower() == "create" && this.TransactionType.ToString().ToLower() == "withdrawal") ||
            (action.ToLower() == "delete" && this.TransactionType.ToString().ToLower() == "deposit"))
                this.BankAccount.BankAccountBalance -= this.TransactionAmount;

            //TODO: Add functionality for edit

            //TODO: Add error handling

        }

    }

}