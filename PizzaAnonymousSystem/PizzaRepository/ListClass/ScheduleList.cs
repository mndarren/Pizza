using PizzaRepository.ListInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaRepository.ListClass
{
    public class ScheduleList : IScheduleList
    {
        public bool AddSchedule(PizzaModels.Models.Schedule newSchedule)
        {
            throw new NotImplementedException();
        }

        public PizzaModels.Models.Schedule GetSchedule(int reportType)
        {
            throw new NotImplementedException();
        }

        public PizzaModels.Models.Schedule UpdateSchedule(PizzaModels.Models.Schedule updatedSchedule)
        {
            throw new NotImplementedException();
        }

        public bool DeleteSchedule(int reportType)
        {
            throw new NotImplementedException();
        }
    }
}