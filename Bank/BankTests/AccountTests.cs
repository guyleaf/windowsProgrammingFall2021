using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Tests
{
    [TestClass()]
    public class AccountTests
    {
        const uint INIT_AMOUNT = 100;
        const uint DEPOSITED = 200;
        const uint BIG_WITHDRAW = 300;
        PrivateObject _accountPrivate;
        Account _account;

        [TestInitialize()]
        public void Initialize()
        {
            _account = new Account(INIT_AMOUNT);
            _accountPrivate = new PrivateObject(_account);
        }

        [TestMethod()]
        public void AccountTest()
        {
            Assert.AreEqual(INIT_AMOUNT, (double)_accountPrivate.GetFieldOrProperty("Balance"), 0.0001);
        }

        [TestMethod()]
        public void DepositTest()
        {
            Assert.AreEqual(INIT_AMOUNT, (double)_accountPrivate.GetFieldOrProperty("Balance"), 0.0001);
            _account.Deposit(DEPOSITED);
            Assert.AreEqual(INIT_AMOUNT + DEPOSITED, (double)_accountPrivate.GetFieldOrProperty("Balance"), 0.0001);
        }

        [TestMethod()]
        [DataRow(INIT_AMOUNT)]
        public void WithdrawTest(double currentBalance)
        {
            Assert.AreEqual(currentBalance, (double)_accountPrivate.GetFieldOrProperty("Balance"), 0.0001);
            _account.Withdraw(BIG_WITHDRAW);
            currentBalance -= BIG_WITHDRAW;
            Assert.AreEqual(currentBalance, (double)_accountPrivate.GetFieldOrProperty("Balance"), 0.0001);
            _account.Deposit(DEPOSITED);
            currentBalance += DEPOSITED;
            Assert.AreEqual(currentBalance, (double)_accountPrivate.GetFieldOrProperty("Balance"), 0.0001);
            _account.Withdraw(BIG_WITHDRAW);
            currentBalance -= BIG_WITHDRAW;
            Assert.AreEqual(currentBalance, (double)_accountPrivate.GetFieldOrProperty("Balance"), 0.0001);
        }
    }
}