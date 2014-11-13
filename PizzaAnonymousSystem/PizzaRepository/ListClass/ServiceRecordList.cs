using PizzaCommon.Tools;
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
                AppDomain.CurrentDomain.SetData("DataDirectory", PathFactory.DatabasePath());

                if (_serviceRecord != null)
                {
                    var tempRecord = pizzDB.ServiceRecords.Where(node => node.ID == _serviceRecord.ID).FirstOrDefault();
                    if (tempRecord == null)
                    {
                        pizzDB.ServiceRecords.Add(MapRecordToEntity(_serviceRecord));
                        pizzDB.SaveChanges();
                        success = true;
                    }
                    else success = false;
                }
                else success = false;
            }
            catch (Exception e)
            {
                success = false;
                throw new Exception(e.Message);
            } return success;
        }

        public ServiceRecord GetServiceRecord(int serviceRecordID) {
            var serviceRecord = new ServiceRecord();
            try
            {
                var pizzDB = new Entity.PizzaDBEntities();
                AppDomain.CurrentDomain.SetData("DataDirectory", PathFactory.DatabasePath());

                var tempRecord = pizzDB.ServiceRecords.Where(node => node.ID == serviceRecordID).FirstOrDefault();

                if (null != tempRecord) serviceRecord = MapEntityToRecord(tempRecord);
                else serviceRecord = null;
            }
            catch (Exception e)
            {
                serviceRecord = null;
                throw new Exception(e.Message);
            }
            return serviceRecord;
        }

        #region Entity DataType Mapping

        private Entity.ServiceRecord MapRecordToEntity(ServiceRecord serviceRecord)
        {
            var tempRecord = new Entity.ServiceRecord();

            if (null != serviceRecord)
            {
                tempRecord.ID = serviceRecord.ID;
                tempRecord.ServiceCode = serviceRecord.ServiceCode;
                tempRecord.MemberID = serviceRecord.MemberNumber;
                tempRecord.ProviderID = serviceRecord.ProviderNumber;
                tempRecord.TimeStamp = serviceRecord.TimeStamp;
                tempRecord.Comments = serviceRecord.Comments;
                tempRecord.DateProvided = serviceRecord.DateProvided;
            }

            return tempRecord;
        }

        private ServiceRecord MapEntityToRecord(Entity.ServiceRecord tempRecord)
        {
            var serviceRecord = new ServiceRecord();

            if (null != tempRecord)
            {
                serviceRecord.ID = tempRecord.ID;
                serviceRecord.ServiceCode = tempRecord.ServiceCode;
                serviceRecord.MemberNumber = tempRecord.MemberID;
                serviceRecord.ProviderNumber = tempRecord.ProviderID;
                serviceRecord.TimeStamp = tempRecord.TimeStamp;
                serviceRecord.DateProvided = tempRecord.DateProvided;
                serviceRecord.Comments = tempRecord.Comments;
            }

            return serviceRecord;
        }

        #endregion
        
    }
}