using BankingAppMVCWithUnitTestingV2.Models;
using BankingAppMVCWithUnitTestingV2.Repositories;
using BankingAppMVCWithUnitTestingV2.ViewModels;
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
        public ActionResult GetAccounts(int? id)
        {
            Person person = pr.Person(id);
            return View(new PersonAccountVM { PersonID = person.ID, Accounts = person.Accounts});
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Type")] Account account, int personID)
        {
            if (ModelState.IsValid)
            {
                Person person = pr.Person(personID);
                pr.AccountsAdd(person, account);
                return RedirectToAction("GetAccounts", new { id = personID});
            }
            return View(account);
        }

        public ActionResult Transfer()
        {
            return View(new PersonCheckBoxVM { People = pr.Persons()});
        }

        public ActionResult SelectAccount(int?[] id)
        {
            List<Person> People = new List<Person>();
            foreach (int i in id)
            {
                People.Add(pr.Person(i)); 
            }

            
            return View(People);
        }
    }
}