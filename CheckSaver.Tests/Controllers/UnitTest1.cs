using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using CheckSaver.Controllers;
using CheckSaver.Models;
using System.Collections.Generic;

namespace CheckSaver.Tests.Controllers
{
    [TestClass]
    public class TransactionAPITestController
    {
        [TestMethod]
        public void TestMethod1()
        {
            var controller = new TransactionsAPIController();

            var transactions = controller.GetTransactions();
            Assert.AreEqual(0, transactions);
        }
    }
}
