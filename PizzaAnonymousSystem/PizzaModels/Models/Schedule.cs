using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaModels.Models
{
    public class Schedule
    {
        private int _reportType;
        private int _week;
        private TimeSpan _time;

        public int ReportType { get { return _reportType; } set { _reportType = value; } }
        public int Week { get { return _week; } set { _week = value; } }
        public TimeSpan Time { get { return _time; } set { _time = value; } }


        public Schedule()
        {
                
        }
    }
}