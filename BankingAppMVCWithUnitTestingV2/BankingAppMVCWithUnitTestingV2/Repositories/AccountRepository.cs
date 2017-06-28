using BankingAppMVCWithUnitTestingV2.DataAccess;
using BankingAppMVCWithUnitTestingV2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BankingAppMVCWithUnitTestingV2.Repositories
{
    public class AccountRepository : IDisposable
    {
        BankContext db = new BankContext();

        public void Add(Account account)
        {
            db.Accounts.Add(account);
            db.SaveChanges();
        }

        public void Remove(Account account)
        {
            db.Accounts.Remove(account);
            db.SaveChanges();
        }

        public void Edit(Account account)
        {
            db.Entry(account).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Deposit(Account account, double amount)
        {
            account.Balance = account.Balance + amount;
            account.TransHistory.Add(new Transaction { Type = Transaction.EventType.Deposit, EventTime = DateTime.Now, Amount = amount });
            db.SaveChanges();
        }

        public void Withdraw(Account account, double amount)
        {
            account.Balance = account.Balance - amount;
            account.TransHistory.Add(new Transaction { Type = Transaction.EventType.WithDrawl, EventTime = DateTime.Now, Amount = amount });
            db.SaveChanges();
        }

        public void Transfer(Account acc1, Account acc2, double amount)
        {
            acc1.Balance = acc1.Balance - amount;
            acc2.Balance = acc2.Balance + amount;

            acc1.TransHistory.Add(new Transaction { Type = Transaction.EventType.Transfer, EventTime = DateTime.Now, Amount = amount });
            acc2.TransHistory.Add(new Transaction { Type = Transaction.EventType.Transfer, EventTime = DateTime.Now, Amount = amount });

            db.SaveChanges();

        }

        public Account Find(int? id)
        {
            return db.Accounts.Find(id);
        }

        public IEnumerable<Account> GetAccounts()
        {
            return db.Accounts;
        }

        public IEnumerable<Account> Include()
        {
            return db.Accounts.Include(a => a.Person);
        }


        #region IDisposable Support

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}