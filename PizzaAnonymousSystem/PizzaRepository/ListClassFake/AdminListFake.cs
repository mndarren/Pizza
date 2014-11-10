using PizzaRepository.ListInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PizzaModels.Models;

namespace PizzaRepository.ListClassFake
{
    public class AdminListFake : IAdminList
    {
        private bool _returnError;

        public AdminListFake(bool returnError = false)
        {
            this._returnError = returnError;
        }

        public bool ReturnError { get { return _returnError; } set { _returnError = value; } }

        public Boolean addAdmin(Admin admin)
        {
            return !_returnError;
        }

        public Boolean DeleteAdmin(int adminID)
        {
            return !_returnError;
        }
        public Boolean UpdateAdmin(int adminID)
        {
            return !_returnError;
        }

        public Admin GetAdmin(int adminID)
        {
            throw new NotImplementedException();
        }

        public Admin UpdateAdmin(string name, int adminID, string streetAddress, string city, string state, string ZIPcode)
        {
            throw new NotImplementedException();
        }
    }
}