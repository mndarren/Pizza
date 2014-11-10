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

        public bool InsertServiceRecord(ServiceRecord _serviceRecord)
        {
            throw new NotImplementedException();
        }

        public ServiceRecord GetServiceRecord(int serviceCodeID)
        {
            throw new NotImplementedException();
        }
    }
}