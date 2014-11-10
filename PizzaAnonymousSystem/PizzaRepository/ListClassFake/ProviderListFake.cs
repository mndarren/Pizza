using PizzaRepository.ListInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaRepository.ListClassFake
{
    public class ProviderListFake : IProviderList
    {
        public bool AddProvider(PizzaModels.Models.Provider newItem)
        {
            throw new NotImplementedException();
        }

        public List<PizzaModels.Models.Provider> GetProviders()
        {
            throw new NotImplementedException();
        }

        public bool DeleteProvider(int providerID)
        {
            throw new NotImplementedException();
        }

        public bool UpdateProvider(string name, int ID, string streetAddress, string city, string state, string ZIPcode, long bankAccount)
        {
            throw new NotImplementedException();
        }
    }
}