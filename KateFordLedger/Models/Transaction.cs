using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KateFordLedger.Models
{

    public enum TransactionType { Deposit = 0, Withdrawal = 1 }

    public class Transaction
    {
 
        [Key]
        public Guid TransactionId { get; set; }

        [Display(Name = "Transaction Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTimeOffset TransactionDateCreated { get; set; }

        [Display(Name = "Transaction Type")]
        public TransactionType TransactionType { get; set; }

        [Display(Name = "Amount")]
        [DataType(DataType.Currency)]
        [Range(0, (double)decimal.MaxValue, ErrorMessage = "Value should be between {1} and {2}.")]
        public decimal TransactionAmount { get; set; }

        public virtual BankAccount BankAccount { get; set; }

    }

    
}