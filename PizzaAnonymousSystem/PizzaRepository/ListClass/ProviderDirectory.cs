using PizzaRepository.ListInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PizzaModels.Models;
using PizzaRepository.ListInterface;

namespace PizzaRepository.ListClass
{
    public class ProviderDirectory : IProviderDirectory
    {
        private List<Service> serviceItems;

    }
}