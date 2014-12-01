using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaController.Models
{
    public class VerifyReportViewModel
    {
        #region Private Members

        private int _providerNumber;

        private DateTime _startDate;
        private DateTime _endDate;

        #endregion

        public int ProviderNumber { get { return _providerNumber; } set { _providerNumber = value; } }

        public DateTime StartDate { get { return _startDate; } set { _startDate = value; } }
        public DateTime EndDate { get { return _endDate; } set { _endDate = value; } }


        public VerifyReportViewModel() { }

        public VerifyReportViewModel(int providerID, DateTime startDate, DateTime endDate)
        {
            this.ProviderNumber = providerID;
            this.StartDate = startDate;
            this.EndDate = endDate;
        }
    }
}