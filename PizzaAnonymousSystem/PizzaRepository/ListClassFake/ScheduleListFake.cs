using PizzaModels.Models;
using PizzaRepository.ListInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaRepository.ListClassFake
{
    public class ScheduleListFake : IScheduleList
    {
        private bool _returnError;

        public ScheduleListFake(bool returnError = false)
        {
            this._returnError = returnError;
        }


        public bool ReturnError { get { return _returnError; } set { _returnError = value; } }


        public bool AddSchedule(Schedule newSchedule)
        {
            return !_returnError;
        }

        public Schedule GetSchedule(int reportType)
        {
            if (!_returnError)
            {
                return new Schedule(reportType, 1, new TimeSpan(23, 59, 59));
            }
            else return null;
        }

        public Schedule UpdateSchedule(Schedule updatedSchedule)
        {
            if (!_returnError)
            {
                return updatedSchedule;
            }
            else return null;
        }

        public bool DeleteSchedule(int reportType)
        {
            return !_returnError;
        }
    }
}