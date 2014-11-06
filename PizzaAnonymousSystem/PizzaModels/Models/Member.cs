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
        private int _status;
        public Member() { _status = -1; }
        public Member(int _newStatus) { _status = _newStatus; }
        public int Status { get { return _status;} set{_status = value;} }

    }
}