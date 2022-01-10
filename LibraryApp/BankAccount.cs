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
            balance = +amount;
            _loggerGeneral.Message("Está depositando la cantidad de: " + amount);
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
