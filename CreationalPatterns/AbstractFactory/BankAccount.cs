using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPatterns.AbstractFactory
{
    public class BankAccount
    {
        private int _maxWithdrawalSum;

        private BankAccount(bool isForChildren)
        {
            if (isForChildren)
            {
                _maxWithdrawalSum = 1000;
            }
            else
            {
                _maxWithdrawalSum = 10000;
            }
        }
        public int GetMaxWithdrawalSum()
        {
            return _maxWithdrawalSum;
        }
        public static BankAccount ForChildren()
        {
            return new BankAccount(true);
        }

        public static BankAccount Regular()
        {
            return new BankAccount(false);
        }
    }
}
