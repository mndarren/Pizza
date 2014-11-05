using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaModels.Models
{
    public class Member:Person
    {
        private int _status;
        public Member(){}
        public int Status { get { return _status;} set{_status = value;} }

    }
}