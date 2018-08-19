Simple online banking Ledger


A simple online web application for users to log in, create multiple accounts, record deposits and withdrawals and log out. The account
balance is automatically adjusted each time a transaction is created or deleted.

This is a sample code demonstration that does not include many frontend and backend additions necessary for a usable ledger. I pla
n to add column sort capability, record ordering, comprehensive exception handling, realistic bank account number entry (10-12 digits),
transaction description and record editing, bank account unique keys and front end design.

Steps to run locally:

  *Web.config
    *Connection string: Use LocalDb and comment out Remote
    
  *Nuget Package Manager / Package Manager Console
    *enable-migrations - Verbose
    *update-database - Verbose
    
Created in Visual Studio 2015 (.NET Framework 4.6.1 MVC 5)
