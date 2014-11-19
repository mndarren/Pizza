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


        public int? AddProvider(Provider newProvider)
        {
            if (!_returnError) return 100;
            else return null;
        }

        public Provider GetProvider(int providerID)
        {
            if (!_returnError)
            {
                return new Provider();
            }
            else return null;
        }

        public Provider UpdateProvider(string name, int providerID, string streetAddress,
                                     string city, string state, string ZIPcode, long bankAccount)
        {
            if (!_returnError)
            {
                return new Provider();
            }
            else return null;
        }

        public bool DeleteProvider(int providerID)
        {
            return !_returnError;
        }


        public List<Provider> GetAllProviders()
        {
            return new List<Provider>();
        }
    }
}