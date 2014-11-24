using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaModels.Models
{
    public class Schedule
    {
        #region Private Members

        private int _reportType;
        private int _week;
        private TimeSpan _time;

        #endregion
        
        public int ReportType { get { return _reportType; } set { _reportType = value; } }
        public int Week { get { return _week; } set { _week = value; } }
        public TimeSpan Time { get { return _time; } set { _time = value; } }


        public Schedule() { }

        public Schedule(int reportType, int week, TimeSpan time)
        {
            this.ReportType = reportType;
            this.Week = week;
            this.Time = time;
        }
    }
}