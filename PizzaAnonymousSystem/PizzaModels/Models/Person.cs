using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaModels.Models
{
    public class Person
    {
        private int _id;
        private String _name;
        private String _streeAddress;
        private String _state;
        private String _city;
        private String _zipCode;

        public Person(){
        }
        public Person(int _id, String _name, String _streeAddress, String _state, String _city, String _zipCode)
        {
        }
        public int ID { get { return _id; } set { _id = value; } }
        public String Name { get { return _name; } set { _name = value; } }
        public String StreeAddress { get { return _streeAddress; } set { _streeAddress = value; } }
        public String State { get { return _state; } set { _state = value; } }
        public String City { get { return _city; } set { _city = value; } }
        public String ZipCode { get { return _zipCode; } set { _zipCode = value; } }
    }
}