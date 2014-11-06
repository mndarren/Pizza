/*
 Author:Cheng Luo
 */
using PizzaModels.Models;
using PizzaRepository.ListInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaRepository.ListClass
{
    public class ServiceRecordList : IServiceRecordList
    {
        private List<ServiceRecord> _serviceRecords = new List<ServiceRecord>();
        private static ServiceRecordList _serviceRecordList;

        public ServiceRecordList(){}
        
        //create a service record list instance
        public static ServiceRecordList Instance() {
            if (_serviceRecordList == null) { return _serviceRecordList = new ServiceRecordList(); }
            else { return _serviceRecordList; }
        }

        //add service record into list
        public Boolean InsertServiceRecord(ServiceRecord _serviceRecord) {
            if (_serviceRecord != null)
            {
                _serviceRecords.Add(_serviceRecord);
                return true;
            }
            else { return false; }
        }

        public List<ServiceRecord> GetServiceRecords() { return _serviceRecords; }
        
    }
}