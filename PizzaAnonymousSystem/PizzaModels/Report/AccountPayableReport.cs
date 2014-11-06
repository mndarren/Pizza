using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaModels.Report
{
    public class AccountPayableReport
    {
        private int _providerID;
        private string _providerName;
        private int _providerCount;
        private int _consultationCount;
        private double _toatlFee;
        private double _overallFee;

        public AccountPayableReport()
        {
            _providerID = 0;
            _providerName = null;
            _providerCount = 0;
            _consultationCount = 0;
            _toatlFee = 0;
            _overallFee = 0;
        }

        public AccountPayableReport(int PID, string PName, int PCount, int CsuCount, double TFee, double OvaFee)
        {
            _providerID = PID;
            _providerName = PName;
            _providerCount = PCount;
            _consultationCount = CsuCount;
            _toatlFee = TFee;
            _overallFee = OvaFee;
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

        public int providerCount
        {
            get { return _providerCount; }
            set { _providerCount = value; }
        }

        public int consoltationCount
        {
            get { return _consultationCount; }
            set { _consultationCount = value; }
        }

        public double totalFee
        {
            get { return _toatlFee; }
            set { _toatlFee = value; }
        }

        public double overallFee
        {
            get { return _overallFee; }
            set { _overallFee = value; }
        }
    }
}