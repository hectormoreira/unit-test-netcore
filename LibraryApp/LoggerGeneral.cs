using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    public interface ILoggerGeneral
    {
        void Message(string message);
        bool LogDatabase(string message);
        bool LogBalanceAfterWithdrawal(int balance);
    }

    public class LoggerGeneral : ILoggerGeneral
    {
        public bool LogBalanceAfterWithdrawal(int balance)
        {
            if (balance >= 0)
            {
                Console.WriteLine("Sucesss Withdrawal");
                return true;
            }
            Console.WriteLine("Error Withdrawal");
            return false;
        }

        public bool LogDatabase(string message)
        {
            Console.WriteLine(message);
            return true;
        }

        public void Message(string message)
        {
            Console.WriteLine(message);
        }
    }

    public class LoggerFake : ILoggerGeneral
    {
        public bool LogBalanceAfterWithdrawal(int balance)
        {
            return false;
        }

        public bool LogDatabase(string message)
        {
            return false;
        }

        public void Message(string message)
        {

        }
    }
}
