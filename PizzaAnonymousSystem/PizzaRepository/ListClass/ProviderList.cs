using PizzaModels.Models;
using PizzaRepository.ListInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaRepository.ListClass
{
    public class ProviderList : IProviderList
    {
        private List<Provider> providers;
        
        public ProviderList(){}
        public List<Provider> Providers{get {return providers;}}
        public Boolean AddProvider(Provider newItem)
        {
            providers.Add(newItem);
            return true;
        }
        public Boolean Deleteprovider(int providerID)
        {
            Provider temp = providers.Where(p => p.ID == providerID).FirstOrDefault() ;
            if(temp != null)
            {
                  providers.Remove(temp);
                  return true;
            }
            return false;
        }
        public Boolean UpdateProvider(string name, int ID, string streetAddress,
                                     string city, string state, string ZIPcode, long bankAccount)
        {
            Provider temp = providers.Where(p => p.ID == ID).FirstOrDefault();
            if (temp != null)
            {
                 temp.Name = name;
                 temp.ID = ID;
                 temp.StreetAddress = streetAddress;
                 temp.City = city;
                 temp.State = state;
                 temp.ZipCode = ZIPcode;
                 temp.BankAccount = bankAccount;
                 return true;
            }
            return false;
        }
    }
}