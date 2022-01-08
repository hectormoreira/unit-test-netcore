using Moq;
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

        }

        [Test]
        public void Deposit_InputAmount100Loggerfake_ReturnsTrue()
        {
            BankAccount bankAccount = new BankAccount(new LoggerFake());

            var result = bankAccount.Deposit(100);

            Assert.IsTrue(result);
            Assert.That(bankAccount.GetBalance, Is.EqualTo(100));
        }

        [Test]
        public void Deposit_InputAmount100Mocking_ReturnsTrue()
        {
            // unsing mocking
            var mocking = new Mock<ILoggerGeneral>();
            BankAccount bankAccount = new BankAccount(mocking.Object);

            var result = bankAccount.Deposit(100);

            Assert.IsTrue(result);
            Assert.That(bankAccount.GetBalance, Is.EqualTo(100));
        }

    }
}
