using PizzaRepository.ListInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PizzaModels.Models;

namespace PizzaRepository.ListClassFake
{
    public class ProviderListFake : IProviderList
    {
         private bool _returnError;

         public ProviderListFake(bool returnError = false)
        {
            this._returnError = returnError;
        }


        public bool ReturnError { get { return _returnError; } set { _returnError = value; } }


        public bool AddProvider(Provider newProvider)
        {
            return !_returnError;
        }

        public Provider GetProvider(int providerID)
        {
            if (!_returnError)
            {
                return new Provider();
            }
            else return null;
        }

        public Provider UpdateProvider(Provider newProvider)
        {
            if (!_returnError)
            {
                return newProvider;
            }
            else return null;
        }

        public bool DeleteProvider(int providerID)
        {
            return !_returnError;
        }
    }
}