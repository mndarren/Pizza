using PizzaRepository.ListInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaRepository.ListClass
{
    public class ProviderList : IProviderList
    {
        private LinkedList<Provider> providers;
        private Provider SearchProvider(int providerID)
        {
            LinkedListNode<Provider> temp = providers.First;
            for (; temp != providers.Last; temp = temp.Next)
                if (temp.Value.ID == providerID)
                    return temp;
            return null;
        }
        public ProviderList(){}
        public LinkedList<Provider> Providers{get {return providers;}}
        public Boolean AddProvider(Provider newItem)
        {
            providers.AddLast(newItem);
            return true;
        }
        public Boolean Deleteprovider(int providerID)
        {
            LinkedListNode<Provider> temp = SearchProvider(providerID);
            if(temp != null)
            {
                  providers.Remove(temp);
                  return true;
            }
            return false;
        }
        public Boolean UpdateProvider(string name, int ID, string streetAddress,
                                     string city, string state, int ZIPcode, long bankAccount)
        {
            LinkedListNode<Provider> temp = SearchProvider(ID);
            if (temp != null)
            {
                 temp.Value.Name = name;
                 temp.Value.ID = ID;
                 temp.Value.StreetAddress = streetAddress;
                 temp.Value.City = city;
                 temp.Value.State = state;
                 temp.Value.ZipCode = ZIPcode;
                 temp.Value.BankAccount = bankAccount;
                 return true;
            }
            return false;
        }
    }
}