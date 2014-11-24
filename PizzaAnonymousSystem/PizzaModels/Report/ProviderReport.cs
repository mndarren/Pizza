using PizzaModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaModels.Report
{
    public class ProviderReport
    {
        #region Private Members

        private Provider _provider;
        private IList<ProviderReportService> _providerReportService;

        private int _numberOfMemberConsultations;
        private decimal _totalWeeklyFee;

        #endregion
        
        public Provider Provider { get { return _provider; } set { _provider = value; } }
        public IList<ProviderReportService> ProviderReportServices { get { return _providerReportService; } set { _providerReportService = value; } }

        public int NumberOfMemberConsultations { get { return _numberOfMemberConsultations; } set { _numberOfMemberConsultations = value; } }
        public decimal TotalWeeklyFee { get { return _totalWeeklyFee; } set { _totalWeeklyFee = value; } }


        public ProviderReport() { }

        public ProviderReport(Provider provider, IList<ProviderReportService> providerReportServices,
            int numberOfMemberConsultations, decimal totalWeeklyFee)
        {
            this.Provider = provider;
            this.ProviderReportServices = providerReportServices;

            this.NumberOfMemberConsultations = numberOfMemberConsultations;
            this.TotalWeeklyFee = totalWeeklyFee;
        }
    }

    public class ProviderReportService
    {
        #region Private Members

        private DateTime _dateProvided;
        private DateTime _timeStamp;

        private string _name;
        private int _memberNumber;

        private int _serviceCode;
        private decimal _fee;

        #endregion

        public DateTime DateProvided { get { return _dateProvided; } set { _dateProvided = value; } }
        public DateTime TimeStamp { get { return _timeStamp; } set { _timeStamp = value; } }

        public string Name { get { return _name; } set { _name = value; } }
        public int MemberNumber { get { return _memberNumber; } set { _memberNumber = value; } }

        public int ServiceCode { get { return _serviceCode; } set { _serviceCode = value; } }
        public decimal Fee { get { return _fee; } set { _fee = value; } }


        public ProviderReportService() { }

        public ProviderReportService(DateTime dateProvided, DateTime timeStamp, 
            string name, int memberNumber, int serviceCode, decimal fee)
        {
            this.DateProvided = dateProvided;
            this.TimeStamp = timeStamp;

            this.Name = name;
            this.MemberNumber = memberNumber;

            this.ServiceCode = serviceCode;
            this.Fee = fee;
        }
    }
}