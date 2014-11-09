/*@Class: CSCU531
 *@Author: Zhao Xie
 *@Date:11/6/2014
 *@File: ProviderDirectory.cs
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
        private List<Service> services = new List<Service>();
        public ProviderDirectory(){}
        public List<Service> Services{get {return services;}}
        public bool AddService(Service newService)
        {
            var success = false;
            try
            {
                var pizzaDB = new Entity.PizzaDBEntities();//EntitiesRepository
                if (null != newService)
                {
                    var eService = pizzaDB.Services
                        .Where(es => es.ServiceCode == newService.ServiceCode).FirstOrDefault();
                    if (null == eService)
                    {
                        pizzaDB.Services.Add(MapServiceToEntity(newService));
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
        public bool DeleteServiceItem(int serviceID)
        {
            var success = false;
            try
            {
                var pizzaDB = new Entity.PizzaDBEntities();//EntitiesRepository
                var eService = pizzaDB.Services
                    .Where(es => es.ServiceCode == serviceID).FirstOrDefault();

                if (null != eService){
                    pizzaDB.Services.Remove(eService);
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
        public Service UpdateService(Service newService)
        {
            var service = new Service();
            try
            {
                var pizzaDB = new Entity.PizzaDBEntities();//EntitiesRepository
                if (null != newService)
                {
                    var eService = pizzaDB.Services
                        .Where(es => es.ServiceCode == newService.ServiceCode).FirstOrDefault();

                    if (null != eService)
                    {
                        foreach (var es in pizzaDB.Services
                            .Where(es => es.ServiceCode == newService.ServiceCode))
                        {
                            es.ServiceName = newService.ServiceName;
                            es.ServiceFee = newService.ServiceFee;
                        }
                        pizzaDB.SaveChanges(); //Apply changes to DB
                        service = GetService(newService.ServiceName);
                    }
                    else service = null;
                }
                else service = null;
            }
            catch (Exception e)
            {
                service = null;
                //If we have time, record the exception
                throw new Exception(e.Message);
            }

            return service;
        }
        public Service GetService(string serviceName)
        {
            var service = new Service();
            try
            {
                var pizzaDB = new Entity.PizzaDBEntities();//EntitiesRepository
                var eService = pizzaDB.Services
                    .Where(es => es.ServiceName == serviceName).FirstOrDefault();

                if (null != eService)
                   service = MapEntityToService(eService);
                else service = null;
            }
            catch (Exception e)
            {
                service = null;
                //If we have time, record the exception
                throw new Exception(e.Message);
            }

            return service;
        }

        #region Entity DataType Mapping

        private Entity.Service MapServiceToEntity(Service service)
        {
            var eService = new Entity.Service();

            if (null != service)
            {
                eService.ServiceCode = service.ServiceCode;
                eService.ServiceName = service.ServiceName;
                eService.ServiceFee = service.ServiceFee;
            }

            return eService;
        }

        private Service MapEntityToService(Entity.Service eService)
        {
            var service = new Service();

            if (null != eService)
            {
                service.ServiceCode = eService.ServiceCode;
                service.ServiceName = eService.ServiceName;
                service.ServiceFee = eService.ServiceFee;
            }

            return service;
        }

        #endregion
    }
}
    