using BankingAppMVCWithUnitTestingV2.Models;
using BankingAppMVCWithUnitTestingV2.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingAppMVCWithUnitTestingV2.Tests.Repositories
{
    [TestClass]
    public class AccountRepositoryTest
    {
        [TestMethod]
        public void Deposit()
        {
            //Arrange
            AccountRepository ar = new AccountRepository();

            double beginningBalance = 0;
            double depositAmount = 100.00;
            double expected = 100.00;
            Account account = new Account { ID = 1, Type = Account.AccountType.Savings, Balance = beginningBalance };

            //Act
            ar.Deposit(account, depositAmount);

            //Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual);
        }
    }
}
