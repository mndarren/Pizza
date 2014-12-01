/*@Class: CSCU531
 *@Author: Zhao Xie
 *@Date:11/6/2014
 *@File: ManageService.cs
 *@Description: this class control service and service record
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
using System.Web.Http.Cors;

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

        [EnableCors("*", "*", "*")]
        [HttpPost] //temp fix for CORS GET
        [POST("api/servicemanager/get/services")]
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

        [EnableCors("*", "*", "*")]
        [HttpPost]
        [POST("api/servicemanager/servicerecords/")]
        public int? AddServiceRecord([FromBody]ServiceRecord newServiceRecord) 
        {
            return serviceRecordList.InsertServiceRecord(newServiceRecord);
        }

        [EnableCors("*", "*", "*")]
        [HttpPost]
        [POST("api/servicemanager/services/")]
        public int? AddService([FromBody]Service newService)
        {
            return providerDirectory.AddService(newService);
        }

        [EnableCors("*", "*", "*")]
        [HttpPost] //temp fix for CORS PUT
        [POST("api/servicemanager/put/services/")]
        public Service UpdateService([FromBody]Service newService)
        {
            return providerDirectory.UpdateService(newService);
        }

        [EnableCors("*", "*", "*")]
        [HttpDelete]
        [DELETE("api/servicemanager/services/{serviceCode}")]
        public bool DeleteService([FromUri]int serviceCode)
        {
            var success = providerDirectory.DeleteService(serviceCode);
            if (!success) throw new Exception("unable to delete member.");
            return success;
        }

        [EnableCors("*", "*", "*")]
        [HttpPost] //temp fix for CORS GET
        [POST("api/servicemanager/get/servicerecords/{serviceRecordID}")]
        public ServiceRecord GetServiceRecord([FromUri]int serviceRecordID)
        {
            return serviceRecordList.GetServiceRecord(serviceRecordID);
        }
    }
}
