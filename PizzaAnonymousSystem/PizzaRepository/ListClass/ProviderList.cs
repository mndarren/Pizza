using PizzaCommon.Tools;
/*@Class: CSCU531
 *@Author: Zhao Xie
 *@Date:11/6/2014
 *@File: ProviderList.cs
 *@Description: this class contains Provider objects
 */
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
        public List<Provider> GetAllProviders() 
        {
            List<Provider> providers = new List<Provider>();
            var pizzaDB = new Entity.PizzaDBEntities();//EntitiesRepository
            AppDomain.CurrentDomain.SetData("DataDirectory",
                    System.IO.Path.Combine(PathFactory.SolutionPath(), "PizzaRepository\\App_Data"));

            foreach (var es in pizzaDB.Providers)
            {
                providers.Add(MapEntityToProvider(es));
            }
            return providers;
        }
      
        public bool AddProvider(Provider newProvider)
        {
            var success = false;
            try
            {
                var pizzaDB = new Entity.PizzaDBEntities();//EntitiesRepository
                AppDomain.CurrentDomain.SetData("DataDirectory",
                    System.IO.Path.Combine(PathFactory.SolutionPath(), "PizzaRepository\\App_Data"));

                if (null != newProvider)
                {
                    var eProvider = pizzaDB.Providers
                        .Where(es => es.ID == newProvider.ID).FirstOrDefault();
                    if (null == eProvider)
                    {
                        pizzaDB.Providers.Add(MapProviderToEntity(newProvider));
                        pizzaDB.SaveChanges(); //Apply changes to DB
                        success = true;
                    }
                    else success = false;
                }
                else success = false;
            }
            catch (Exception e)
            {
                success = false;
                //If we have time, record the exception
                throw new Exception(e.Message);
            }

            return success;
        }
        public bool DeleteProvider(int ProviderID)
        {
            var success = false;
            try
            {
                var pizzaDB = new Entity.PizzaDBEntities();//EntitiesRepository
                AppDomain.CurrentDomain.SetData("DataDirectory",
                    System.IO.Path.Combine(PathFactory.SolutionPath(), "PizzaRepository\\App_Data"));

                var eProvider = pizzaDB.Providers
                    .Where(es => es.ID == ProviderID).FirstOrDefault();

                if (null != eProvider)
                {
                    pizzaDB.Providers.Remove(eProvider);
                    pizzaDB.SaveChanges(); //Apply changes to DB
                }
                else success = false;
            }
            catch (Exception e)
            {
                success = false;
                //If we have time, record the exception
                throw new Exception(e.Message);
            }

            return success;
        }

        public Provider UpdateProvider(string name, int providerID, string streetAddress,
                                     string city, string state, string ZIPcode,long bankAccount)
        {
            var Provider = new Provider();
            try
            {
                var pizzaDB = new Entity.PizzaDBEntities();//EntitiesRepository
                AppDomain.CurrentDomain.SetData("DataDirectory",
                    System.IO.Path.Combine(PathFactory.SolutionPath(), "PizzaRepository\\App_Data"));

                var eProvider = pizzaDB.Providers
                        .Where(es => es.ID == providerID).FirstOrDefault();

                if (null != eProvider)
                {
                    foreach (var es in pizzaDB.Providers
                        .Where(es => es.ID == providerID))
                    {
                        es.Name = name;
                        es.StreetAddress = streetAddress;
                        es.City = city;
                        es.State = state;
                        es.ZipCode = ZIPcode;
                        es.BankAccount = bankAccount;
                    }
                    pizzaDB.SaveChanges(); //Apply changes to DB
                    Provider = GetProvider(providerID);
                }
                else Provider = null;
            }
            catch (Exception e)
            {
                Provider = null;
                //If we have time, record the exception
                throw new Exception(e.Message);
            }

            return Provider;
        }
        public Provider GetProvider(int providerID)
        {
            var Provider = new Provider();
            try
            {
                var pizzaDB = new Entity.PizzaDBEntities();//EntitiesRepository
                AppDomain.CurrentDomain.SetData("DataDirectory",
                    System.IO.Path.Combine(PathFactory.SolutionPath(), "PizzaRepository\\App_Data"));

                var eProvider = pizzaDB.Providers
                    .Where(es => es.ID == providerID).FirstOrDefault();

                if (null != eProvider)
                    Provider = MapEntityToProvider(eProvider);
                else Provider = null;
            }
            catch (Exception e)
            {
                Provider = null;
                //If we have time, record the exception
                throw new Exception(e.Message);
            }

            return Provider;
        }

        #region Entity DataType Mapping

        private Entity.Provider MapProviderToEntity(Provider provider)
        {
            var eProvider = new Entity.Provider();

            if (null != provider)
            {
                eProvider.ID = provider.ID;
                eProvider.Name = provider.Name;
                eProvider.StreetAddress = provider.StreetAddress;
                eProvider.State = provider.State;
                eProvider.City = provider.City;
                eProvider.ZipCode = provider.ZipCode;
                eProvider.BankAccount = provider.BankAccount;
            }
            return eProvider;
        }

        private Provider MapEntityToProvider(Entity.Provider eProvider)
        {
            var provider = new Provider();

            if (null != eProvider)
            {
                provider.ID = eProvider.ID;
                provider.Name = eProvider.Name;
                provider.StreetAddress = eProvider.StreetAddress;
                provider.State = eProvider.State;
                provider.City = eProvider.City;
                provider.ZipCode = eProvider.ZipCode;
                provider.BankAccount = (long)eProvider.BankAccount;
            }

            return provider;
        }

        #endregion
    }
}