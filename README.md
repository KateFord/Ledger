<h1>Online Banking Ledger</h1>


<p>A simple online web application for users to log in, create multiple checking and savings accounts, record deposits and withdrawals against those accounts and log out. The account balance is automatically adjusted each time a transaction is created or deleted.</p> 
 
<p>The Ledger can be viewed here - <a href="http://katefordledger.azurewebsites.net/">Online Bank Account Ledger</a></p>

<p>This is a sample code demonstration that does not include many front and backend functionality necessary for a usable ledger. A few tasks at hand are model views, column sort capability, record ordering, comprehensive exception handling, realistic bank account number entry (10-12 digits), transaction description and record editing, bank account number on the transaction index, bank account unique keys, transaction count on the bank account index and front end design.</p>

<h3>Steps to run locally:</h3>

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
    
<p>Created using Visual Studio 2015,.NET Framework 4.6.1 and ASP.NET MVC 5</p>
