using PizzaModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaRepository.ListInterface
{
    public interface IScheduleList
    {
        bool AddSchedule(Schedule newSchedule);
        Schedule GetSchedule(int reportType);
        Schedule UpdateSchedule(Schedule updatedSchedule);
        bool DeleteSchedule(int reportType);
    }
}
