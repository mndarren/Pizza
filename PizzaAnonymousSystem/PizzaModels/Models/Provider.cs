using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaModels.Models
{
    public class Provider:Person
    {
        private long _bankAccount;
        public Provider(){}
        public Provider(long num){_bankAccount = num;}
        public long BankAccount{get {return _bankAccount;} set {_bankAccount = value;}}
        public override string ToString()
        {
            return base.ToString() + "BankAccount: " + _bankAccount;
        }
    }
}