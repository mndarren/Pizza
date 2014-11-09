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
        bool AddProvider(Provider newItem);
        List<Provider> GetProviders();
        bool DeleteProvider(int providerID);
        bool UpdateProvider(string name, int ID, string streetAddress,
                            string city, string state, string ZIPcode, long bankAccount);
    }
}
