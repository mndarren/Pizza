using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaModels.Models;

namespace PizzaRepository.ListInterface
{
    public interface IProviderList
    {
        bool AddProvider(Provider newProvider);
        bool DeleteProvider(int ProviderID);
        Provider UpdateProvider(string name, int providerID, string streetAddress,
                                string city, string state, string ZIPcode, long bankAccount);
        Provider GetProvider(int providerID);
    }
}
