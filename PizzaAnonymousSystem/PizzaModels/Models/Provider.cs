using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaModels.Models
{
    public class Provider
    {
        private long _bankAccount;
        public Provider()
        {
            _bankAccount = 0;
        }
        public Provider(long num)
        {
            _bankAccount = num;
        }
        public BankAccount{get {return _bankAccount;} set {_bankAccount = value;}}
    }
}