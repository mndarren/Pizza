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
        private bool _returnError;

        public ServiceRecordListFake(bool returnError = false){
            this._returnError = returnError;
        }

        public bool ReturnError { get { return _returnError; } set { _returnError = value; } }

        public Boolean InsertServiceRecord(ServiceRecord _serviceRecord)
        {
            return _returnError;
        }
        //public List<ServiceRecord> GetServiceRecords();



        public ServiceRecord GetServiceRecord(int serviceCodeID)
        {
            throw new NotImplementedException();
        }
    }
}