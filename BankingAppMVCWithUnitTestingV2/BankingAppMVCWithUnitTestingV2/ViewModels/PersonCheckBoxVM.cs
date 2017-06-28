using BankingAppMVCWithUnitTestingV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankingAppMVCWithUnitTestingV2.ViewModels
{
    public class PersonCheckBoxVM
    {
        public IEnumerable<Person> People { get; set; }
        public bool IsChecked { get; set; }
    }
}