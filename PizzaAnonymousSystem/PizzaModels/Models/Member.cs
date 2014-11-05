using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaModels.Models
{
    public class Member:Person
    {
        private int _statues;
        public Member()
        {
                
        }

        public int Statues { get { return _statues;} set{_statues = value;} }

    }
}