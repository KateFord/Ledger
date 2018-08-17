using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using KateFordLedger.Models;
using System.Linq;
using System.Data;
using System.Web.Configuration;

namespace KateFordLedger.Controllers
{
    public class TransactionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Transaction
        public async Task<ActionResult> Index(Guid? bankAccountId)
        {
            if (bankAccountId == null)  return Redirect("Home/Index");
           
            // Store bank account id in session variable for CRUD operations
            Session["BankAccountId"] = bankAccountId;
            var transactions = db.Transactions.Where(x => x.BankAccount.BankAccountId == bankAccountId);
            return View(await transactions.ToListAsync());
   
        }

        // GET: Transaction/Details/5
        public async Task<ActionResult> Details(Guid? transactionId)
        {
            if (transactionId == null)  return RedirectToAction("Index");
            Transaction transaction = await db.Transactions.FindAsync(transactionId);
            if (transaction == null)  return HttpNotFound();
            return View(transaction);
        }

        // GET: Transaction/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Transaction/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "TransactionId,TransactionDateCreated,TransactionType,TransactionAmount")] Transaction transaction)
        {
            if(!ModelState.IsValid)
                return RedirectToAction("Index");
            try
            {
                transaction.TransactionId = Guid.NewGuid();
                transaction.TransactionDateCreated = DateTime.Today;
                Guid bankAccountId = (Guid)Session["bankAccountId"];
                transaction.BankAccount = db.BankAccounts.FirstOrDefault(x => x.BankAccountId == bankAccountId);
                db.Transactions.Add(transaction);
                await db.SaveChangesAsync();

                // Update Bank Account Balance after Debit or Credit Transaction Creation ... place code in a method!!!
                if (transaction.TransactionType.ToString().ToLower() == "deposit")
                    transaction.BankAccount.BankAccountBalance += transaction.TransactionAmount;
                else
                    transaction.BankAccount.BankAccountBalance -= transaction.TransactionAmount;

                db.Entry(transaction.BankAccount).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }

             catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes.");
            }

            return RedirectToAction("Index", "Transaction", new { BankAccountId = (Guid)Session["BankAccountId"] });
        }

        // GET: Transaction/Edit/5
        public async Task<ActionResult> Edit(Guid? transactionId)
        {
            if (transactionId == null)
            {
                return RedirectToAction("Index");
            }
            Transaction transaction = await db.Transactions.FindAsync(transactionId);
            if (transaction == null)
            {
                return HttpNotFound();
            }
          return View(transaction);
        }

        // POST: Transaction/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "TransactionId,TransactionDateCreated,TransactionType,TransactionAmount")] Transaction transaction)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index");
            try
            {
                if (ModelState.IsValid)
                 {
                    db.Entry(transaction).State = EntityState.Modified;
                    await db.SaveChangesAsync();

                    //TODO: Adjust Bank Account Balance 

                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes.");
            }
            return RedirectToAction("Index", "Transaction", new { BankAccountId = (Guid)Session["BankAccountId"] });
        }

        // GET: Transaction/Delete/5
        public async Task<ActionResult> Delete(Guid? transactionId)
        {
            if (transactionId == null)
            {
                return RedirectToAction("Index");
            }
            Transaction transaction = await db.Transactions.FindAsync(transactionId);
            if (transaction == null)
            {
                return HttpNotFound();
            }
          return View(transaction);
        }

        // POST: Transaction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid transactionId)
        {

            if (!ModelState.IsValid)
                return RedirectToAction("Index");
            try
            {
                Transaction transaction = await db.Transactions.FindAsync(transactionId);
                db.Transactions.Remove(transaction);
                await db.SaveChangesAsync();

                // Update Bank Account Balance after Transaction Deletion ... place code in a method!!!
                Guid bankAccountId = (Guid)Session["bankAccountId"];
                transaction.BankAccount = db.BankAccounts.FirstOrDefault(x => x.BankAccountId == bankAccountId);

                if (transaction.TransactionType.ToString().ToLower() == "deposit")
                    transaction.BankAccount.BankAccountBalance -= transaction.TransactionAmount;
                else
                    transaction.BankAccount.BankAccountBalance += transaction.TransactionAmount;
 
                db.Entry(transaction.BankAccount).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes.");
            }
          return RedirectToAction("Index", "Transaction", new { BankAccountId = (Guid)Session["bankAccountId"] });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
