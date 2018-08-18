# Bank Account Ledger

A simple web application for users to log in, record deposits and withdrawal transactions for multiple bank accounts and log off.

The application is written in C# using ASP.NET MVC Entity Framework.

When downloaded locally, follow these steps:

  * Web.config: 
    * Comment out the current connection string and uncomment LocalDb
    
  * Tools / Nuget Package Manager / Package Manager console
    * enable-migrations -Verbose
    * update-database -Verbose


