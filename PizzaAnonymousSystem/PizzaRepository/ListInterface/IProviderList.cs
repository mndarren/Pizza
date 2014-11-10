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
        Provider UpdateProvider(Provider newProvider);
        Provider GetProvider(int providerID);
    }
}
