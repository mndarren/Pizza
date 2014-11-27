/*
 Author:Cheng Luo
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace PizzaModels.Models
{
    public class Member:Person
    {
        #region Private Members
        private int _status;
        #endregion

        public Member() { _status = 1; }
        public Member(string name, string streetAddress,  string city,string state, string zipCode)
        {
            Name = name;
            StreetAddress = streetAddress;
            State = state;
            City = city;
            ZipCode = zipCode;
            _status = 1;
        }

        public Member(int _newStatus) { _status = _newStatus; }
        public int Status { get { return _status;} set{_status = value;} }

    }
}