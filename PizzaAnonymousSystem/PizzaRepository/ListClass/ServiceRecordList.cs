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
        private LinkedList<ServiceRecord> _serviceRecords = new LinkedList<ServiceRecord>();
        private static ServiceRecordList _serviceRecordList;

        public ServiceRecordList(){}
        
        //create a service record list instance
        public static ServiceRecordList Instance() {
            if (_serviceRecordList == null) { return _serviceRecordList = new ServiceRecordList(); }
            else { return _serviceRecordList; }
        }

        //add service record into list
        public Boolean InsertServiceRecord(ServiceRecord _serviceRecord) { 
            _serviceRecords.AddLast(_serviceRecord); 
            return true; 
        }

        public LinkedList<ServiceRecord> GetServiceRecord() { return _serviceRecords; }
        
    }
}