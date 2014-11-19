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
    public class ManageServiceController : ApiController
    {
        #region Private Members
        private readonly IMemberList memberList;
        private readonly IProviderList providerList;
        private readonly IProviderDirectory providerDirectory;
        private readonly IServiceRecordList serviceRecordList;
        #endregion

        public ManageServiceController(IMemberList memberList, IProviderList providerList,
            IProviderDirectory providerDirectory, IServiceRecordList serviceRecordList)
        {
            this.memberList = memberList;
            this.providerList = providerList;
            this.providerDirectory = providerDirectory;
            this.serviceRecordList = serviceRecordList;
        }

        [HttpGet]
        [GET("api/servicemanager/services")]
        public List<Service> GetAllServices()
        {
            //var services = new List<Service>();

            try
            {
                return providerDirectory.GetServices();
            }
            catch (Exception e)
            {
                throw new HttpRequestException(e.Message);
            }
        }

        [HttpPost]
        [POST("api/servicemanager/servicerecords/")]
        public int? AddServiceRecord([FromBody]ServiceRecord newServiceRecord) 
        {
            return serviceRecordList.InsertServiceRecord(newServiceRecord);
        }
        
        [HttpPost]
        [POST("api/servicemanager/services/")]
        public bool AddService([FromBody]Service newService)
        {
            return providerDirectory.AddService(newService);
        }

        [HttpPut]
        [PUT("api/servicemanager/services/")]
        public Service UpdateService([FromBody]Service newService)
        {
            return providerDirectory.UpdateService(newService);
        }

        [HttpDelete]
        [DELETE("api/servicemanager/services/{serviceCode}")]
        public bool DeleteService([FromUri]int serviceCode)
        {
            return providerDirectory.DeleteService(serviceCode);
        }

        [HttpGet]
        [GET("api/servicemanager/servicerecords/{serviceRecordID}")]
        public ServiceRecord GetServiceRecord([FromUri]int serviceRecordID)
        {
            return serviceRecordList.GetServiceRecord(serviceRecordID);
        }
    }
}
