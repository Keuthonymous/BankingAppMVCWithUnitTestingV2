using BankingAppMVCWithUnitTestingV2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BankingAppMVCWithUnitTestingV2.DataAccess
{
    public class BankContext : DbContext
    {
        public BankContext() : base("DefaultConnection") { }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}