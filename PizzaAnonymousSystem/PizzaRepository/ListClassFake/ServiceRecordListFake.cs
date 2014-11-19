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

        public ServiceRecordListFake(bool returnError = false)
        {
            this._returnError = returnError;
        }


        public bool ReturnError { get { return _returnError; } set { _returnError = value; } }


        public int? InsertServiceRecord(ServiceRecord _serviceRecord)
        {
            if (!ReturnError) return 10000;
            else return null;
        }

        public ServiceRecord GetServiceRecord(int serviceCodeID)
        {
            var serviceRecord = new ServiceRecord();

            if (!ReturnError)
            {
                serviceRecord.ID = serviceCodeID;
                serviceRecord.MemberNumber = 1000;
                serviceRecord.ProviderNumber = 1000;
                serviceRecord.DateProvided = DateTime.Today;
                serviceRecord.TimeStamp = DateTime.Now;
            }
            else serviceRecord = null;

            return serviceRecord;
        }

        public List<ServiceRecord> GetAllServiceRecordForMember(int memberID)
        {
            var serviceRecords = new List<ServiceRecord>();

            if (!ReturnError)
            {
                serviceRecords.Add(new ServiceRecord()
                {
                    ID = 1000,
                    MemberNumber = memberID,
                    ProviderNumber = 100,
                    ServiceCode = 1200,
                    DateProvided = DateTime.Today,
                    TimeStamp = DateTime.Now
                });
            }
            else serviceRecords = null;

            return serviceRecords;
        }

        public List<ServiceRecord> GetAllServiceRecordForProvider(int providerID)
        {
            var serviceRecords = new List<ServiceRecord>();

            if (!ReturnError)
            {
                serviceRecords.Add(new ServiceRecord()
                {
                    ID = 1000,
                    MemberNumber = 100,
                    ProviderNumber = providerID,
                    ServiceCode = 1200,
                    DateProvided = DateTime.Today,
                    TimeStamp = DateTime.Now
                });
            }
            else serviceRecords = null;

            return serviceRecords;
        }

        public bool VerifyServiceRecords(int providerID, DateTime startDate, DateTime endDate,
            bool? verifyFee = true, bool? verifyService = true)
        {
            return !ReturnError;
        }
    }
}