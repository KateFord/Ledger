<h1>Simple online banking Ledger</h1>


<p>A simple online web application for users to log in, create multiple accounts, record deposits and withdrawals and log out. The account
balance is automatically adjusted each time a transaction is created or deleted.</p>

<a href="http://katefordledger.azurewebsites.net/"></a>

<p>This is a sample code demonstration that does not include many frontend and backend additions necessary for a usable ledger. A few tasks at hand are column sort capability, record ordering, comprehensive exception handling, realistic bank account number entry (10-12 digits), transaction description and record editing, bank account number on the transaction index, bank account unique keys, transaction count on the bank account index and front end design.</p>

<h4>Steps to run locally:</h4>

 <ul>
 <li>Web.config</li>
   <ul>
    <li>Connection string: Use LocalDb and comment out Remote</li>
   </ul>
 </ul>
 
 <ul>
 <li>Nuget Package Manager / Package Manager Console</li>
   <ul>
    <li>enable-migrations - Verbose</li>
    <li>update-database - Verbose</li>
   </ul>
 </ul>
    
Created in Visual Studio 2015 (.NET Framework 4.6.1 MVC 5)
