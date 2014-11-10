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
        private List<Provider> providers = new List<Provider>();
        
        public ProviderList(){}
        public List<Provider> GetProviders() {return providers;}
      
        public bool AddProvider(Provider newProvider)
        {
            var success = false;
            try
            {
                var pizzaDB = new Entity.PizzaDBEntities();//EntitiesRepository
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

        public Provider UpdateProvider(Provider newProvider)
        {
            var Provider = new Provider();
            try
            {
                var pizzaDB = new Entity.PizzaDBEntities();//EntitiesRepository
                if (null != newProvider)
                {
                    var eProvider = pizzaDB.Providers
                        .Where(es => es.ID == newProvider.ID).FirstOrDefault();

                    if (null != eProvider)
                    {
                        foreach (var es in pizzaDB.Providers
                            .Where(es => es.ID == newProvider.ID))
                        {
                            es.Name = newProvider.Name;
                            es.StreetAddress = newProvider.StreetAddress;

                        }
                        pizzaDB.SaveChanges(); //Apply changes to DB
                        Provider = GetProvider(newProvider.ID);
                    }
                    else Provider = null;
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
            }

            return eProvider;
        }

        private Provider MapEntityToProvider(Entity.Provider eProvider)
        {
            var Provider = new Provider();

            if (null != eProvider)
            {
                Provider.ID = eProvider.ID;
                Provider.Name = eProvider.Name;
                Provider.StreetAddress = eProvider.StreetAddress;
            }

            return Provider;
        }

        #endregion
    }
}