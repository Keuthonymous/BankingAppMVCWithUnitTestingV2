using BankingAppMVCWithUnitTestingV2.DataAccess;
using BankingAppMVCWithUnitTestingV2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BankingAppMVCWithUnitTestingV2.Repositories
{
    public class AccountRepository
    {
        BankContext db = new BankContext();

        public void Add(Account account)
        {
            if (!db.Accounts.Contains(account))
            {
                db.Accounts.Add(account);
                db.SaveChanges();
            }
        }

        public void Remove(Account account)
        {
            if (db.Accounts.Contains(account))
            {
                db.Accounts.Remove(account);
                db.SaveChanges();
            }
        }

        public void Edit(Account account)
        {
            if(db.Accounts.Contains(account))
            {
                db.Entry(account).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public Account Find(int? id)
        {
            return db.Accounts.Find(id);
        }

        public IEnumerable<Account> GetAccounts()
        {
            return db.Accounts;
        }
    }
}