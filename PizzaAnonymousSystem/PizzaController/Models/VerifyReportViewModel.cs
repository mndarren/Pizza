using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaController.Models
{
    public class VerifyReportViewModel
    {
        #region Private Members

        private int _providerID;

        private DateTime _startDate;
        private DateTime _endDate;

        #endregion

        public int ProviderID { get { return _providerID; } set { _providerID = value; } }

        public DateTime StartDate { get { return _startDate; } set { _startDate = value; } }
        public DateTime EndDate { get { return _endDate; } set { _endDate = value; } }


        public VerifyReportViewModel() { }

        public VerifyReportViewModel(int providerID, DateTime startDate, DateTime endDate)
        {
            this.ProviderID = providerID;
            this.StartDate = startDate;
            this.EndDate = endDate;
        }
    }
}