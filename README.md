<h1>Online banking Ledger</h1>


<p>A simple online web application for users to log in, create multiple accounts, record deposits and withdrawals and log out. The account
balance is automatically adjusted each time a transaction is created or deleted. Created using Visual Studio 2015,.NET Framework 4.6.1 ASP.NET MVC 5.)</p>
 
<p>The Ledger can be viewed here - <a href="http://katefordledger.azurewebsites.net/">Online Bank Account Ledger</a></p>

<p>This is a sample code demonstration that does not include many frontend and backend additions necessary for a usable ledger. A few tasks at hand are column sort capability, record ordering, comprehensive exception handling, realistic bank account number entry (10-12 digits), transaction description and record editing, bank account number on the transaction index, bank account unique keys, transaction count on the bank account index and front end design.</p>

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
    

