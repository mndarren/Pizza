using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaModels.Report
{
    public class EFTReport
    {
        private int _providerID;
        private string _providerName;
        private double _totalFee;

        public EFTReport()
        {
            _providerID = 0;
            _providerName = null;
            _totalFee = 0;
        }

        public EFTReport(int PID, string PName, double TFee)
        {
            _providerID = PID;
            _providerName = PName;
            _totalFee = TFee;
        }

        public int providerID
        {
            get { return _providerID; }
            set { _providerID = value; }
        }

        public string providerName
        {
            get { return _providerName; }
            set { _providerName = value; }
        }

        public double totalFee
        {
            get { return _totalFee; }
            set { _totalFee = value; }
        }
    }
}