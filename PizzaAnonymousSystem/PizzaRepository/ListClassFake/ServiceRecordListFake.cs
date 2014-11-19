using PizzaRepository.ListInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PizzaModels.Models;

namespace PizzaRepository.ListClassFake
{
    public class ServiceRecordListFake : IServiceRecordList
    {

        public int? InsertServiceRecord(ServiceRecord _serviceRecord)
        {
            throw new NotImplementedException();
        }



        public ServiceRecord GetServiceRecord(int serviceCodeID)
        {
            throw new NotImplementedException();
        }


        public List<ServiceRecord> GetAllServiceRecordForMember(int memberID)
        {
            throw new NotImplementedException();
        }

        public List<ServiceRecord> GetAllServiceRecordForProvider(int providerID)
        {
            throw new NotImplementedException();
        }
    }
}