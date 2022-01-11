using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    public class BankAccount
    {
        public int balance { get; set; }
        private readonly ILoggerGeneral _loggerGeneral;

        public BankAccount(ILoggerGeneral loggerGeneral)
        {
            balance = 0;
            _loggerGeneral = loggerGeneral;
        }

        public bool Deposit(int amount)
        {
            _loggerGeneral.Message("You are deposit: " + amount);
            _loggerGeneral.Message("This is another text");
            _loggerGeneral.Message("This is another text 2");
            _loggerGeneral.PriorityLog = 100;

            var priority = _loggerGeneral.PriorityLog;

            balance = +amount;            
            return true;
        }

        public bool Withdrawal(int amount)
        {
            if (amount <= balance)
            {
                _loggerGeneral.LogDatabase("Withdrawal Amount: " + amount.ToString());
                balance -= amount;
                return _loggerGeneral.LogBalanceAfterWithdrawal(balance);
            }
            return _loggerGeneral.LogBalanceAfterWithdrawal(balance - amount);
        }

        public int GetBalance()
        {
            return balance;
        }
    }
}
