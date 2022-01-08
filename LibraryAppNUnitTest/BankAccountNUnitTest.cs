using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    [TestFixture]
    public class BankAccountNUnitTest
    {
        private BankAccount bankAccount;
        [SetUp]
        public void SetUp()
        {
            bankAccount = new BankAccount(new LoggerFake());
        }

        [Test]
        public void Deposit_InputAmount100_ReturnsTrue()
        {
            var result = bankAccount.Deposit(100);

            Assert.IsTrue(result);
            Assert.That(bankAccount.GetBalance, Is.EqualTo(100));
        }

    }
}
