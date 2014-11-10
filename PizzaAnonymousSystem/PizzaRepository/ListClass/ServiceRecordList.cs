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
            var success = false;
            try
            {
                var pizzDB = new Entity.PizzaDBEntities();
                if (_serviceRecord != null)
                {
                    var tempRecord = pizzDB.Members.Where()
                }
            }
        }

        public ServiceRecord GetServiceRecord(int serviceRecordID) {
            ServiceRecord serviceRecord = _serviceRecords.Where(node => node.ServiceRecordID == serviceRecordID).FirstOrDefault();
            return serviceRecord;
        }
        
    }
}