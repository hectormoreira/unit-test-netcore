using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LibraryApp
{
    public class BankAccountXUnitTest
    {
        private BankAccount bankAccount;

        [Fact]
        public void Deposit_InputAmount100Loggerfake_ReturnsTrue()
        {
            BankAccount bankAccount = new BankAccount(new LoggerFake());

            var result = bankAccount.Deposit(100);

            Assert.True(result);
            Assert.Equal(100, bankAccount.GetBalance());
        }

        [Fact]
        public void Deposit_InputAmount100Mocking_ReturnsTrue()
        {
            // unsing mocking
            var mocking = new Mock<ILoggerGeneral>();
            BankAccount bankAccount = new BankAccount(mocking.Object);

            var result = bankAccount.Deposit(100);

            Assert.True(result);
            Assert.Equal(100, bankAccount.GetBalance());
        }

        [Theory]
        [InlineData(200, 100)]
        [InlineData(200, 150)]
        public void Withdrawal_100Balance200_ReturnsTrue(int balance, int withdrawal)
        {
            var loggerMock = new Mock<ILoggerGeneral>();
            //simulation operation
            loggerMock.Setup(u => u.LogDatabase(It.IsAny<string>())).Returns(true);
            loggerMock.Setup(u => u.LogBalanceAfterWithdrawal(It.Is<int>(x => x > 0))).Returns(true);


            BankAccount bankAccount = new BankAccount(loggerMock.Object);
            bankAccount.Deposit(balance);

            var result = bankAccount.Withdrawal(withdrawal);

            Assert.True(result);
        }

        [Theory]
        [InlineData(200, 300)]
        public void Withdrawal_300Balance200_ReturnsFalse(int balance, int withdrawal)
        {
            var loggerMock = new Mock<ILoggerGeneral>();
            //simulation operation
            //loggerMock.Setup(u => u.LogBalanceAfterWithdrawal(It.Is<int>(x => x < 0))).Returns(false);

            //by range
            loggerMock.Setup(u => u.LogBalanceAfterWithdrawal(It.IsInRange<int>(int.MinValue, -1, Moq.Range.Inclusive))).Returns(false);


            BankAccount bankAccount = new BankAccount(loggerMock.Object);
            bankAccount.Deposit(balance);

            var result = bankAccount.Withdrawal(withdrawal);

            Assert.False(result);
        }

        [Fact]
        public void BankAccountLoggerGeneral_LogMoccking_ReturnTrue()
        {
            var loggerGeneralMock = new Mock<ILoggerGeneral>();
            string textTest = "hello world";
            loggerGeneralMock.Setup(u => u.MessageWithReturnString(It.IsAny<string>())).Returns<string>(str => str.ToLower());

            var result = loggerGeneralMock.Object.MessageWithReturnString("Hello World");

            Assert.Equal(textTest, result);
        }

        [Fact]
        public void BankAccountLoggerGeneral_LogMockingOutput_ReturnTrue()
        {
            var loggerGeneral = new Mock<ILoggerGeneral>();
            string textTest = "hello";
            loggerGeneral.Setup(u => u.MessageWithOutParameterReturnBoolean(It.IsAny<string>(), out textTest)).Returns(true);

            string parameterOut = "";
            var result = loggerGeneral.Object.MessageWithOutParameterReturnBoolean("Gold", out parameterOut);

            Assert.True(result);
        }

        [Fact]
        public void BankAccountLoggerGeneral_LogMockingObjectRef_ReturnTrue()
        {
            var loggerGeneralMock = new Mock<ILoggerGeneral>();

            Client client = new();
            Client clientNoUse = new();

            loggerGeneralMock.Setup(u => u.MessageWithObjectReferenceReturnBoolean(ref client)).Returns(true);

            Assert.True(loggerGeneralMock.Object.MessageWithObjectReferenceReturnBoolean(ref client));

            Assert.False(loggerGeneralMock.Object.MessageWithObjectReferenceReturnBoolean(ref clientNoUse));
        }

        [Fact]
        public void BankAccountLoggerGeneral_LogMockingPropertiesPriorityType_ReturnsTrue()
        {
            var loggerGeneralMock = new Mock<ILoggerGeneral>();
            loggerGeneralMock.SetupAllProperties();

            loggerGeneralMock.Setup(u => u.TypeLog).Returns("warning");
            loggerGeneralMock.Setup(u => u.PriorityLog).Returns(10);

            loggerGeneralMock.Object.PriorityLog = 100;

            Assert.Equal("warning", loggerGeneralMock.Object.TypeLog);
            Assert.Equal(100, loggerGeneralMock.Object.PriorityLog);

            // Callbacks
            string tempText = "Gold ";
            loggerGeneralMock.Setup(u => u.LogDatabase(It.IsAny<string>()))
                .Returns(true)
                .Callback((string parameter) => tempText += parameter);


            loggerGeneralMock.Object.LogDatabase("Roger"); // Gold Roger

            Assert.Equal("Gold Roger", tempText);
        }

        [Fact]
        public void BankAccountLoggerGeneral_VerifyExample()
        {
            var loggerGeneralMock = new Mock<ILoggerGeneral>();

            BankAccount bankAccount = new BankAccount(loggerGeneralMock.Object);
            bankAccount.Deposit(100);

            Assert.Equal(100, bankAccount.GetBalance());

            // verify how many times .message methods is called
            loggerGeneralMock.Verify(u => u.Message(It.IsAny<string>()), Times.Exactly(3));
            loggerGeneralMock.Verify(u => u.Message("This is another text"), Times.AtLeastOnce);

            loggerGeneralMock.VerifySet(u => u.PriorityLog = 100, Times.Once());
            loggerGeneralMock.VerifyGet(u => u.PriorityLog, Times.Once());
        }
    }
}
