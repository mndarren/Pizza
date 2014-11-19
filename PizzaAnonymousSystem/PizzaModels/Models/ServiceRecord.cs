/*
 Author:Cheng Luo
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaModels.Models
{
    public class ServiceRecord
    {
        private int _serviceCode;
        private int _serviceRecordID;

        private DateTime _timeStamp;
        private DateTime _dateProvided;

        private int _providerNumber;
        private int _memberNumber;

        private string _comments;

        private bool _serviceVerified;
        private bool _feeVerified;

        public ServiceRecord(){}
        
        public ServiceRecord(int serviceCode, DateTime timeStamp, DateTime dateProvided, int providerNumber, int memberNumber, string comments){
            _serviceCode = serviceCode;
            _timeStamp = timeStamp;
            _dateProvided = dateProvided;
            _providerNumber = providerNumber;
            _memberNumber = memberNumber;
            _comments = comments;
            _serviceVerified = false;
            _feeVerified = false;
        }

        public int ServiceCode { get { return _serviceCode; } set { _serviceCode = value; } }
        public int ID { get { return _serviceRecordID; } set { _serviceRecordID = value; } }

        public DateTime TimeStamp { get { return _timeStamp; } set { _timeStamp = value; } }
        public DateTime DateProvided { get { return _dateProvided; } set { _dateProvided = value; } }

        public int ProviderNumber { get { return _providerNumber; } set { _providerNumber = value; } }
        public int MemberNumber { get { return _memberNumber; } set { _memberNumber = value; } }

        public string Comments { get { return _comments; } set { _comments = value; } }

        public bool ServiceVerified { get { return _serviceVerified; } set { _serviceVerified = value; } }
        public bool FeeVerified { get { return _feeVerified; } set { _feeVerified = value; } }
    }
}