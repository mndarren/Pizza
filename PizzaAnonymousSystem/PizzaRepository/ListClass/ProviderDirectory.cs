/*@Class: CSCU531
 *@Author: Zhao Xie
 *@Date:11/6/2014
 *@File: Service.cs
 *@Description: this class contains Service objects
 */
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
        private List<Service> serviceItems = new List<Service>();
        public ProviderDirectory(){}
        public List<Service> ServiceItems{get {return serviceItems;}}
        public Boolean AddServiceItem(Service newItem)
        {
            serviceItems.Add(newItem);
            return true;
        }
        public Boolean DeleteServiceItem(int serviceID)
        {
            Service temp = serviceItems.Where(s => s.ServiceCode == serviceID).FirstOrDefault();
            if(temp != null)
            {
                  serviceItems.Remove(temp);
                  return true;
            }
            return false;
        }
        public Boolean UpdateService(int id,string name,decimal money)
        {
            Service temp = serviceItems.Where(s => s.ServiceCode == id).FirstOrDefault();
            if (temp != null)
            {
                    temp.ServiceName = name;
                    temp.ServiceFee = (decimal)money;
                    return true;
            }
            return false;
        }
    }
}