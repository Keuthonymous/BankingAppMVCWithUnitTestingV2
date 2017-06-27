using BankingAppMVCWithUnitTestingV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankingAppMVCWithUnitTestingV2.ViewModels
{
    public class PersonAccountVM
    {
        public int PersonID { get; set; }
        public IEnumerable<Account> Accounts { get; set; }
    }
}