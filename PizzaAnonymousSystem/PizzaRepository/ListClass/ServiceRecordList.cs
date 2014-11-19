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
        //private static ServiceRecordList _serviceRecordList;

        public ServiceRecordList() { }

        //get servicerecord list by member ID / provider id.
        public List<ServiceRecord> GetAllServiceRecordForMember(int memberID)
        {
            List<ServiceRecord> recordList = new List<ServiceRecord>();
            var serviceRecord = new ServiceRecord();
            var pizzDB = new Entity.PizzaDBEntities();
            AppDomain.CurrentDomain.SetData("DataDirectory", PathFactory.DatabasePath());

            foreach (var result in pizzDB.ServiceRecords.Where(node => node.MemberID == memberID))
            {
                serviceRecord = MapEntityToRecord(result);
                recordList.Add(serviceRecord);
            }

            return recordList;
        }

        public List<ServiceRecord> GetAllServiceRecordForProvider(int providerID)
        {
            List<ServiceRecord> recordList = new List<ServiceRecord>();
            var serviceRecord = new ServiceRecord();
            var pizzDB = new Entity.PizzaDBEntities();
            AppDomain.CurrentDomain.SetData("DataDirectory", PathFactory.DatabasePath());

            foreach (var result in pizzDB.ServiceRecords.Where(node => node.ProviderID == providerID))
            {
                serviceRecord = MapEntityToRecord(result);
                recordList.Add(serviceRecord);
            }

            return recordList;
        }

        //add service record into list
        public int? InsertServiceRecord(ServiceRecord _serviceRecord)
        {
            var serviceRecordId = new int?();
            try
            {
                var pizzDB = new Entity.PizzaDBEntities();
                AppDomain.CurrentDomain.SetData("DataDirectory", PathFactory.DatabasePath());

                if (_serviceRecord != null)
                {
                    var tempRecord = pizzDB.ServiceRecords.Where(node => node.ID == _serviceRecord.ID).FirstOrDefault();
                    if (tempRecord == null)
                    {
                        var eServiceRecord = MapRecordToEntity(_serviceRecord);
                        pizzDB.ServiceRecords.Add(eServiceRecord);
                        pizzDB.SaveChanges();
                        serviceRecordId = eServiceRecord.ID;
                    }
                    else serviceRecordId = new int?();
                }
                else serviceRecordId = new int?();
            }
            catch (Exception e)
            {
                serviceRecordId = new int?();
                throw new Exception(e.Message);
            }

            return serviceRecordId;
        }

        public ServiceRecord GetServiceRecord(int serviceRecordID)
        {
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

        public bool VerifyServiceRecords(int providerID, DateTime startDate, DateTime endDate,
            bool? verifyFee = true, bool? verifyService = true)
        {
            var success = false;

            try
            {
                var pizzDB = new Entity.PizzaDBEntities();
                AppDomain.CurrentDomain.SetData("DataDirectory", PathFactory.DatabasePath());

                if (null == startDate) startDate = DateTime.Today;
                if (null == endDate) endDate = DateTime.Today.AddDays(1);

                foreach (var eServiceRecord in pizzDB.ServiceRecords
                    .Where(sr => sr.DateProvided >= startDate
                        && sr.DateProvided <= endDate && sr.ProviderID == providerID))
                {
                    if (verifyService.HasValue) eServiceRecord.ServiceVerified = verifyService.Value;
                    if (verifyFee.HasValue) eServiceRecord.FeeVerified = verifyFee.Value;
                }
                pizzDB.SaveChanges();

                success = true;
            }
            catch (Exception e)
            {
                success = false;
                throw new Exception(e.Message);
            }

            return success;
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
                tempRecord.ServiceVerified = serviceRecord.ServiceVerified;
                tempRecord.FeeVerified = serviceRecord.FeeVerified;
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
                serviceRecord.ServiceVerified = tempRecord.ServiceVerified;
                serviceRecord.FeeVerified = tempRecord.FeeVerified;
            }

            return serviceRecord;
        }

        #endregion
    }
}