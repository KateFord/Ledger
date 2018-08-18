using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using KateFordLedger.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Data;

namespace KateFordLedger.Controllers
{
    public class BankAccountController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BankAccount
        public async Task<ActionResult> Index()
        {
            if (User.Identity.GetUserId() == null)
            {
                return RedirectToAction("Index","Home");
            }
                        
            var bankAccounts = db.BankAccounts.Where(x => x.User.Id == User.Identity.GetUserId(););
            return View(await bankAccounts.ToListAsync());
        }

        // GET: BankAccount/Details/5
        public async Task<ActionResult> Details(Guid? bankAccountId)
        {
            if (bankAccountId == null)
            {
                return RedirectToAction("Index");
            }
            BankAccount bankAccount = await db.BankAccounts.FindAsync(bankAccountId);
            if (bankAccount == null)
            {
                return HttpNotFound();
            }
            return View(bankAccount);
        }

        // GET: BankAccount/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BankAccount/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "bankAccountNumber,bankAccountDateCreated,bankAccountType,bankAccountBalance")] BankAccount bankAccount)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index");
            try
            {
                if (ModelState.IsValid)
                {
                    bankAccount.User = db.Users.Single(u => u.Id == User.Identity.GetUserId());
                    bankAccount.BankAccountId = Guid.NewGuid();
                    bankAccount.BankAccountDateCreated = DateTime.Today;
                    db.BankAccounts.Add(bankAccount);
                    await db.SaveChangesAsync();
                }
            }
            catch (DataException)
            {
                // error handling structure only
                ModelState.AddModelError("", "Unable to save changes.");
             }
            return RedirectToAction("Index");
        }

        // GET: BankAccount/Edit/5
        public async Task<ActionResult> Edit(Guid? bankAccountId)
        {
            if (bankAccountId == null)
            {
                return RedirectToAction("Index");
            }

            BankAccount bankAccount = await db.BankAccounts.FindAsync(bankAccountId);

            if (bankAccount == null)
            {
                return HttpNotFound();
            }
          return View(bankAccount);
        }

        // POST: BankAccount/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "BankAccountId,BankAccountNumber,BankAccountDateCreated,BankAccountType,BankAccountBalance")] BankAccount bankAccount)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index");
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(bankAccount).State = EntityState.Modified;
                   await db.SaveChangesAsync();
                }
            }
            catch (DataException)
            {
                // error handling structure only
                ModelState.AddModelError("", "Unable to save changes");
             }
            return RedirectToAction("Index");
        }

        // GET: BankAccount/Delete/5
        public async Task<ActionResult> Delete(Guid? bankAccountId)
        {
            if (bankAccountId == null)
            {
                return RedirectToAction("Index");
            }

            BankAccount bankAccount = await db.BankAccounts.FindAsync(bankAccountId);

            if (bankAccount == null)
            {
                return HttpNotFound();
            }
          return View(bankAccount);
        }

        // POST: BankAccount/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid bankAccountId)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index");
            try
            {
                if (ModelState.IsValid)
                {
                   BankAccount bankAccount = await db.BankAccounts.FindAsync(bankAccountId);
                   db.BankAccounts.Remove(bankAccount);
                   await db.SaveChangesAsync();
                }
            }
            catch (DataException)
            {
                // error handling structure only
                ModelState.AddModelError("", "Unable to save changes");
            }
          return RedirectToAction("Index");
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
