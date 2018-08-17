﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KateFordLedger.Models
{
    public enum AccountType { Checking = 0, Savings = 1, Loan = 3 }

    public class BankAccount
    {
        [Key]
        public Guid BankAccountId { get; set; }

        [Display(Name = "Account Number")]
        [RegularExpression("^[1-9][0-9]*$", ErrorMessage = "Please enter an Account Number greater than zero")]
        public int BankAccountNumber { get; set; }

        [Display(Name = "Opened On")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTimeOffset BankAccountDateCreated { get; set; }

        [Display(Name = "Account Type")]
        public AccountType BankAccountType { get; set; }

        [Display(Name = "Balance")]
        [DataType(DataType.Currency)]
        [Range(0, (double)decimal.MaxValue, ErrorMessage = "Value should be between {1} and {2}.")]
        public decimal BankAccountBalance { get; set; } 
       
        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual ApplicationUser User { get; set; }

        internal void Attach(BankAccount bankAccount)
        {
            throw new NotImplementedException();
        }
    }
}