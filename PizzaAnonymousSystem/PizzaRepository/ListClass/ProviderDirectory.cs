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
        private const int OK = 1;
        public ProviderDirectory(){}
        public ProviderDirectory()
        {

        }
        public List<Service> ServiceItems{get {return serviceItems;}}
        public int AddServiceItem(Service newItem)
        {
            serviceItems.Add(newItem);
            return OK;
        }
        public int deleteServiceItem(int serviceID)
        { 
           if(serviceItems._serviceID == serviceID)
           serviceItems.Remove(serviceItem);
            return OK;
        }
        public List get
        public int updateService()
    }
}