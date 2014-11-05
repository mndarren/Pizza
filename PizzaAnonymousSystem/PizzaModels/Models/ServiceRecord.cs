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
        private int providerNumber;
        private int memberNumber;
        private string comments;

        public ServiceRecord()
        {

        }

    }
}