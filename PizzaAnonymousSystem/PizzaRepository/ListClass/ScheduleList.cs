using PizzaCommon.Tools;
using PizzaModels.Models;
using PizzaRepository.ListInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaRepository.ListClass
{
    public class ScheduleList : IScheduleList
    {
        public bool AddSchedule(Schedule newSchedule)
        {
            var success = false;

            try
            {
                var pizzaDB = new Entity.PizzaDBEntities();//EntitiesRepository
                AppDomain.CurrentDomain.SetData("DataDirectory", PathFactory.DatabasePath());

                if (null != newSchedule)
                {
                    var eSchedule = pizzaDB.ReportSchedules
                        .Where(es => es.ReportType == newSchedule.ReportType).FirstOrDefault();

                    var newWeek = new byte();
                    if (null == eSchedule
                        && byte.TryParse(newSchedule.Week.ToString(), out newWeek))
                    {
                        Validator.ValidateSchedule(newSchedule);
                        pizzaDB.ReportSchedules.Add(MapScheduleToEntity(newSchedule));
                        pizzaDB.SaveChanges(); //Apply changes to DB
                        success = true;
                    }
                    else success = false;
                }
                else success = false;
            }
            catch (Exception e)
            {
                success = false;
                //If we have time, record the exception
                throw new Exception(e.Message);
            }

            return success;
        }

        public Schedule GetSchedule(int reportType)
        {
            var schedule = new Schedule();

            try
            {
                var pizzaDB = new Entity.PizzaDBEntities();//EntitiesRepository
                AppDomain.CurrentDomain.SetData("DataDirectory", PathFactory.DatabasePath());

                var eSchedule = pizzaDB.ReportSchedules
                    .Where(es => es.ReportType == reportType).FirstOrDefault();

                if (null != eSchedule)
                    schedule = MapEntityToSchedule(eSchedule);
                else schedule = null;
            }
            catch (Exception e)
            {
                schedule = null;
                //If we have time, record the exception
                throw new Exception(e.Message);
            }

            return schedule;
        }

        public Schedule UpdateSchedule(Schedule updatedSchedule)
        {
            var schedule = new Schedule();

            try
            {
                var pizzaDB = new Entity.PizzaDBEntities();//EntitiesRepository
                AppDomain.CurrentDomain.SetData("DataDirectory", PathFactory.DatabasePath());

                if (null != updatedSchedule)
                {
                    var eSchedule = pizzaDB.ReportSchedules
                        .Where(es => es.ReportType == updatedSchedule.ReportType).FirstOrDefault();
                    
                    var updatedWeek = new byte();
                    if (null != eSchedule 
                        && byte.TryParse(updatedSchedule.Week.ToString(), out updatedWeek))
                    {
                        Validator.ValidateSchedule(updatedSchedule);
                        foreach (var es in pizzaDB.ReportSchedules
                            .Where(es => es.ReportType == updatedSchedule.ReportType))
                        {
                            es.WeekDay = updatedWeek;
                            es.Time = updatedSchedule.Time.Ticks;
                        }

                        pizzaDB.SaveChanges(); //Apply changes to DB
                        schedule = GetSchedule(updatedSchedule.ReportType);
                    }
                    else schedule = null;
                }
                else schedule = null;
            }
            catch (Exception e)
            {
                schedule = null;
                //If we have time, record the exception
                throw new Exception(e.Message);
            }

            return schedule;
        }

        public bool DeleteSchedule(int reportType)
        {
            var success = false;

            try
            {
                var pizzaDB = new Entity.PizzaDBEntities();//EntitiesRepository
                AppDomain.CurrentDomain.SetData("DataDirectory", PathFactory.DatabasePath());

                var eSchedule = pizzaDB.ReportSchedules
                    .Where(es => es.ReportType == reportType).FirstOrDefault();

                if (null != eSchedule)
                {
                    pizzaDB.ReportSchedules.Remove(eSchedule);
                    pizzaDB.SaveChanges(); //Apply changes to DB
                    success = true;
                }
                else success = false;
            }
            catch (Exception e)
            {
                success = false;
                //If we have time, record the exception
                throw new Exception(e.Message);
            }

            return success;
        }


        #region Entity DataType Mapping

        private Entity.ReportSchedule MapScheduleToEntity(Schedule schedule)
        {
            var eSchedule = new Entity.ReportSchedule();

            if (null != schedule)
            {
                eSchedule.ReportType = schedule.ReportType;
                eSchedule.WeekDay = byte.Parse(schedule.Week.ToString());
                eSchedule.Time = null != schedule.Time ? schedule.Time.Ticks : 0;
            }

            return eSchedule;
        }

        private Schedule MapEntityToSchedule(Entity.ReportSchedule eSchedule)
        {
            var schedule = new Schedule();

            if (null != eSchedule)
            {
                schedule.ReportType = eSchedule.ReportType;
                schedule.Week = eSchedule.WeekDay;
                schedule.Time = new TimeSpan(eSchedule.Time);
            }

            return schedule;
        }

        #endregion
    }
}