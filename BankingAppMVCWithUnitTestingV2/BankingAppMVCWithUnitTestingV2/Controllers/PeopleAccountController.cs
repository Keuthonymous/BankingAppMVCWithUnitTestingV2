using BankingAppMVCWithUnitTestingV2.Models;
using BankingAppMVCWithUnitTestingV2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BankingAppMVCWithUnitTestingV2.Controllers
{
    public class PeopleAccountController : Controller
    {
        AccountRepository ar = new AccountRepository();
        PersonRepository pr = new PersonRepository();

        // GET: PeopleAccount
        public ActionResult GetAccounts(int? personID)
        {
            Person person = pr.Person(personID);
            IEnumerable<Account> accounts = person.Accounts.ToList();
            return View(accounts);
        }
    }
}