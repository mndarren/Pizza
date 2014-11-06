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
        private LinkedList<Service> serviceItems;
        private Service SearchService(int serviceID)
        {
            LinkedListNode<Service> temp = serviceItems.First;
            for (; temp != serviceItems.Last; temp = temp.Next)
                if (temp.Value.ServiceCode == serviceID)
                    return temp;
            return null;
        }
        public ProviderDirectory(){}
        public LinkedList<Service> ServiceItems{get {return serviceItems;}}
        public Boolean AddServiceItem(Service newItem)
        {
            serviceItems.AddLast(newItem);
            return true;
        }
        public Boolean DeleteServiceItem(int serviceID)
        { 
            LinkedListNode<Service> temp = SearchService(serviceID);
            if(temp != null)
            {
                  serviceItems.Remove(temp);
                  return true;
            }
            return false;
        }
        public Boolean UpdateService(int id,string name,decimal money)
        {
            LinkedListNode<Service> temp = SearchService(serviceID);
            if (temp != null)
            {
                    temp.Value.ServiceName = name;
                    temp.Value.ServiceFee = (decimal)money;
                    return true;
            }
            return false;
        }
    }
}