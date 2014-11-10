/*@Class: CSCU531
 *@Author: Zhao Xie
 *@Date:11/6/2014
 *@File: ManageService.cs
 *@Description: this class contains service info
 */
using AttributeRouting.Web.Http;
using PizzaModels.Models;
using PizzaRepository.ListInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PizzaController.Controllers
{
    public class ManageService : ApiController
    {
        #region Private Members
        private readonly IMemberList memberList;
        private readonly IProviderList providerList;
        private readonly IProviderDirectory providerDirectory;
        private readonly IServiceRecordList serviceRecordList;
        #endregion

        public ManageService(IMemberList memberList, IProviderList providerList,
            IProviderDirectory providerDirectory, IServiceRecordList serviceRecordList)
        {
            this.memberList = memberList;
            this.providerList = providerList;
            this.providerDirectory = providerDirectory;
            this.serviceRecordList = serviceRecordList;
        }

        /// <summary>
        /// Get all services
        /// </summary>
        /// <returns>returns all services</returns>
        [GET("/servicemanager/services/")]
        public List<Service> GetAllServices()
        {
            var services = new List<Service>();

            try
            {

            }
            catch (Exception e)
            {
                throw new HttpRequestException(e.Message);
            }

            return services;
        }
        [GET("/servicemanager/services/")]
        public bool AddServiceRecord([FromBody]ServiceRecord newServiceRecord) 
        {
            return serviceRecordList.InsertServiceRecord(newServiceRecord);
        }
        [GET("/servicemanager/services/")]
        public bool AddService([FromBody]Service newService)
        {
            return providerDirectory.AddService(newService);
        }
        [GET("/servicemanager/services/")]
        public Service UpdateService([FromBody]Service newService)
        {
            return providerDirectory.UpdateService(newService);
        }
        [GET("/servicemanager/services/")]
        public bool DeleteService([FromBody]int serviceCode)
        {
            return providerDirectory.DeleteService(serviceCode);
        }
        [GET("/servicemanager/services/")]
        public ServiceRecord GetServiceRecord(int serviceRecordID)
        {
            return serviceRecordList.GetServiceRecord(serviceRecordID);
        }
    }
}
