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
            var serviceRecordId = new int?();

            try
            {
                serviceRecordId = serviceRecordList.InsertServiceRecord(newServiceRecord);
                if (serviceRecordId == null) throw new Exception("Enable add service record!");
            }
            catch (Exception e)
            {
                serviceRecordId = null;
                var error = e.Message;
                throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message));
            }

            return serviceRecordId;

        }

        [EnableCors("*", "*", "*")]
        [HttpPost]
        [POST("api/servicemanager/services/")]
        public int? AddService([FromBody]Service newService)
        {
            try { return providerDirectory.AddService(newService); }
            catch (Exception e)
            {  throw new HttpRequestException(e.Message);}
        }

        [EnableCors("*", "*", "*")]
        [HttpPost] //temp fix for CORS PUT
        [POST("api/servicemanager/put/services/")]
        public Service UpdateService([FromBody]Service newService)
        {
            var result = new Service();
            try
            {
                result = providerDirectory.UpdateService(newService);
                if (null == result) throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.NotFound, "service not found"));
            }
            catch (Exception e)
            {
                result = null;
                var error = e.Message;
                throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message));
            }
            return result;
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
