using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    public class BankAccount
    {
        public int Balance { get; set; }
        private readonly ILoggerGeneral _loggerGeneral;

        public BankAccount(ILoggerGeneral loggerGeneral)
        {
            Balance = 0;
            _loggerGeneral = loggerGeneral;
        }

        public bool Deposit(int amount)
        {            
            Balance = +amount;
            _loggerGeneral.Message("Está depositando la cantidad de: " + amount);
            return true;
        }

        public bool Withdrawal(int amount)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
                return true;
            }
            return false;
        }

        public int GetBalance()
        {
            return Balance;
        }
    }
}
