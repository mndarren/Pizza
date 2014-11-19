/*@Class: CSCU531
 *@Author: Zhao Xie
 *@Date:11/6/2014
 *@File: Provider.cs
 *@Description: this class contains Provider's info
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PizzaModels.Models;

namespace PizzaModels.Models
{
    public class Provider:Person
    {
        #region Private Members
        private long _bankAccount;
        #endregion

        public Provider(){}
        public Provider(string name, string streetAddress, string state, string city, string zipCode,long bankAccount)
        {
            BankAccount = bankAccount;
            Name = name;
            StreetAddress = streetAddress;
            State = state;
            City = city;
            ZipCode = zipCode;
        }
        public Provider(Provider p) 
        {
            BankAccount = p.BankAccount;
            ID = p.ID;
            Name = p.Name;
            StreetAddress = p.StreetAddress;
            State = p.State;
            City = p.City;
            ZipCode = p.ZipCode;
        }
        public long BankAccount{get {return _bankAccount;} set {_bankAccount = value;}}
        public override string ToString()
        {
            return base.ToString() + "BankAccount: " + _bankAccount;
        }
    }
}