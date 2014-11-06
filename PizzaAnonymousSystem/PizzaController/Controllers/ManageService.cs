﻿using AttributeRouting.Web.Http;
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
        private readonly IMemberList memberList;
        private readonly IProviderList providerList;
        private readonly IProviderDirectory providerDirectory;
        private readonly IServiceRecordList serviceRecordList;

        public ManageService(IMemberList memberList, IProviderList providerList,
            IProviderDirectory providerDirectory, IServiceRecordList serviceRecordList)
        {
            this.memberList = memberList;
            this.providerList = providerList;
            this.providerDirectory = providerDirectory;
            this.serviceRecordList = serviceRecordList;
        }

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
    }
}