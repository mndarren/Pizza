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

                if (null != eService)
                    pizzaDB.Services.Remove(eService);
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
        public bool UpdateService(Service newService)
        {
            var schedule = new Schedule();
            try
            {
                var pizzaDB = new Entity.PizzaDBEntities();//EntitiesRepository
                if (null != updatedSchedule)
                {
                    var eSchedule = pizzaDB.ReportSchedules
                        .Where(es => es.ReportType == updatedSchedule.ReportType).FirstOrDefault();

                    var updatedWeek = new byte();
                    if (null != eSchedule
                        && byte.TryParse(updatedSchedule.Week.ToString(), out updatedWeek))
                    {
                        foreach (var es in pizzaDB.ReportSchedules
                            .Where(es => es.ReportType == updatedSchedule.ReportType))
                        {
                            es.WeekDay = updatedWeek;
                            es.Time = updatedSchedule.Time.Ticks;
                        }

                        schedule = GetSchedule(updatedSchedule.ReportType);
                    }
                    else schedule = null;
                }
                else schedule = null;
            }
            catch (Exception e)
            {
                schedule = null;
                //If we have time, record the exception
                throw new Exception(e.Message);
            }

            return schedule;
        }
    }
}